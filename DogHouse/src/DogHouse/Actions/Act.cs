using System;
using System.Threading.Tasks;
using System.Timers;
using DogHouse.Enums;

namespace DogHouse.Actions
{
    public class Act
    {

        private bool _gateOpen = false;
        public Act()
        {
        }

        public string ToggleDoorState(GateTriggers trigger)
        {
            string gateState = string.Empty;
            switch (trigger)
            {
                case GateTriggers.Bark:
                    gateState = ToogleGateStatus();
                    break;
                case GateTriggers.Scratch:
                    gateState = ToogleGateStatus();
                    break;
                case GateTriggers.Remote:
                    gateState = ToogleGateStatus();
                    break;
            }
            return gateState;
        }

        private string ToogleGateStatus()
        {
            string gateState = string.Empty;
            if (_gateOpen)
            {
                _gateOpen = true;
                ShutGateAutomatically();
                gateState = "gate Open";
            }
            else
            {
                _gateOpen = false;
                gateState = "gate Closed";
            }
            return gateState;
        }

        private void ShutGateAutomatically()
        {
            var asyncGateClose = Task.Run(async delegate {
                await Task.Delay(5000);
                _gateOpen = false;
            });
            asyncGateClose.Wait();
        }
    }
}
