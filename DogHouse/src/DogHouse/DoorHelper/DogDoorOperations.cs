using System;
using System.Threading.Tasks;
using DBOps.UOW;
using DogHouse.DBRepository;
using DogHouse.Models;
using Microsoft.Extensions.Options;

namespace DogHouse.DoorHelper
{
    public class DogDoorOperations : IDogDoorOperations
    {
        private readonly IDoorRepository _doorDbRepository;

        private readonly IUnitOfWork _uow;

        private readonly IOptionsMonitor<AppSettings> _appSettings;

        public DogDoorOperations(
                        IDoorRepository doorDbRepository,
                        IUnitOfWork uow,
                        IOptionsMonitor<AppSettings> settings)
        {
            _doorDbRepository = doorDbRepository;
            _uow = uow;
            _appSettings = settings;
        }

        private async Task Close(string id)
        {
            var doorState = await _doorDbRepository.GetById(id);
            if (doorState is null) await _doorDbRepository.Add(new Entities.DoorState { Id = id, Open = false });
            else
            {
                doorState.Open = false;
                await _doorDbRepository.Update(doorState);
            }
            await _uow.Commit();
        }
        public async Task<bool> IsOpen(string id)
        {
            var doorState = await _doorDbRepository.GetById(id);
            if (doorState is null) return false;
            return doorState.Open;
        }

        public async Task Act(string id)
        {
            if(await IsOpen(id))
            {
                await Close(id);
                return;
            }
            await Open(id);
        }

        private async Task Open(string id)
        {
            var doorState = await _doorDbRepository.GetById(id);
            if (doorState is null)
            {
                await _doorDbRepository.Add(new Entities.DoorState { Id = id, Open = true });
            }
            else
            {
                doorState.Open = true;
                await _doorDbRepository.Update(doorState);
            }
            await _uow.Commit();
            await DelayedClose(id);
        }

        private async Task DelayedClose(string id)
        {
            await Task.Delay(_appSettings.CurrentValue.DoorCloseTime).ContinueWith(t => Close(id));
        }
    }
}