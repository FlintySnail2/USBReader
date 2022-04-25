using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Add the following references
using System.Configuration;
using System.Management;

namespace USBReader
{
    class Derp 
    {
        static void Main(string[] args)
        {
            var usbDevices = GetUSBDevices();
            foreach (var usbDevice in usbDevices)
            {
                Console.WriteLine("Device ID: {0}, PNP Device ID:{1}, Description: {2} ",
                    usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description);
            }
            Console.Read();
        }

        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_USBHub"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                    (string)device.GetPropertyValue("DeviceID"),
                    (string)device.GetPropertyValue("PnpDeviceID"),
                    (string)device.GetPropertyValue("Description")
                    ));
            }
            collection.Dispose();
            return devices;
        }

    }
}
