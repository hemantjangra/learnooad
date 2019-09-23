using System;
using System.Threading.Tasks;

namespace DogHouse.Models
{
    public class DogDoor
    {
        private Boolean _open;
        public DogDoor()
        {
            _open = false;
        }

        public void Open()
        {
            _open = true;
            ShutGateAutomatically();
        }

        public void Close()
        {
            _open = false;
        }

        public bool IsOpen()
        {
            return _open;
        }

        private void ShutGateAutomatically()
        {
            var asyncGateClose = Task.Run(async delegate {
                await Task.Delay(5000);
                _open = false;
            });
            asyncGateClose.Wait();
        }
    }
}
