// MSSV: 202418947
// Ho ten: Dang Ngoc Minh

using System;
using System.Collections.Generic;

namespace LabW05
{
    // Phong thuc hanh: quan ly danh sach cac thiet bi
    public class LabRoom
    {
        public string RoomName { get; set; }

        private List<Device> _devices = new List<Device>();

        public LabRoom(string roomName)
        {
            RoomName = roomName;
        }

        // Them thiet bi vao phong, tra ve true neu thanh cong
        public bool AddDevice(Device device)
        {
            // TODO: chua kiem tra trung ma thiet bi, can bo sung sau
            _devices.Add(device);
            return true;
        }

        // Tim thiet bi theo ma (tra ve null neu khong tim thay -> dung Device?)
        public Device? FindDevice(string deviceId)
        {
            foreach (Device d in _devices)
            {
                if (d.DeviceId == deviceId)
                {
                    return d;
                }
            }
            return null;
        }

        // In danh sach thiet bi trong phong
        public void DisplayDevices()
        {
            Console.WriteLine("===> Danh sach thiet bi phong [" + RoomName + "] (" + _devices.Count + " thiet bi):");
            if (_devices.Count == 0)
            {
                Console.WriteLine("    (phong trong)");
                return;
            }
            foreach (Device d in _devices)
            {
                Console.WriteLine("    - " + d.ToString());
            }
        }

        // Tong chi phi bao tri du kien trong 1 nam cua ca phong
        public decimal CalculateAnnualMaintenanceCost()
        {
            decimal total = 0m;
            foreach (Device d in _devices)
            {
                total += d.CalculateAnnualMaintenanceCost();
            }
            return total;
        }

        // Danh sach cac thiet bi dang can bao tri (trang thai UnderMaintenance)
        public List<Device> GetDevicesRequiringMaintenance()
        {
            List<Device> result = new List<Device>();
            foreach (Device d in _devices)
            {
                if (d.Status == DeviceStatus.UnderMaintenance)
                {
                    result.Add(d);
                }
            }
            return result;
        }
    }
}
