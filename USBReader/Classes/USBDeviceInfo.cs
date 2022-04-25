using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBReader
{
    class USBDeviceInfo 
    {
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }

        public USBDeviceInfo(string deviceID, string pnpDeviceInfo, string description)
        {
            DeviceID = deviceID;
            PnpDeviceID = pnpDeviceInfo;
            Description = description;
        }
        
    }
}
