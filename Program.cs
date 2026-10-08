// MSSV: 202418947
// Ho ten: Dang Ngoc Minh

using System;
using System.Collections.Generic;

namespace LabW05
{
    class Program
    {
        // In ra danh sach thiet bi can bao tri cua 1 phong
        static void PrintDevicesNeedingMaintenance(LabRoom room)
        {
            List<Device> needFix = room.GetDevicesRequiringMaintenance();
            Console.WriteLine("Phong [" + room.RoomName + "] co " + needFix.Count + " thiet bi can bao tri:");
            foreach (Device d in needFix)
            {
                Console.WriteLine("    - " + d.ToString());
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("========== CHUONG TRINH QUAN LY THIET BI ==========");
            Console.WriteLine();

            // 1. Khoi tao du lieu
            // 2 may tinh (1 may co GPU roi)
            Computer pc1 = new Computer("PC001", "PC phong thuc hanh A", 2023, 15000000m, 16, "Intel Core i5", false);
            Computer pc2 = new Computer("PC002", "PC do hoa", 2017, 25000000m, 32, "Intel Core i7", true);

            // 2 may in (1 may in tren 100.000 trang), pr2 la may in mang
            Printer pr1 = new Printer("PR001", "May in laser", 2021, 5000000m, PrinterType.Laser, 50000, false, false);
            NetworkPrinter pr2 = new NetworkPrinter("PR002", "May in mau da nang", 2018, 8000000m, PrinterType.Inkjet, 150000, true);

            // 1 may chieu (bong den dung tren 3000 gio)
            Projector pj1 = new Projector("PJ001", "May chieu giang duong", 2017, 12000000m, 3500, 4500);

            // 2 phong thuc hanh
            LabRoom room1 = new LabRoom("Phong Lab 1");
            LabRoom room2 = new LabRoom("Phong Lab 2");

            // 2. Them thiet bi vao phong
            room1.AddDevice(pc1);
            room1.AddDevice(pr1);
            room2.AddDevice(pc2);
            room2.AddDevice(pr2);
            room2.AddDevice(pj1);

            // Thu them thiet bi trung ma (de kiem tra xu ly loi)
            Console.WriteLine("--- Thu them thiet bi trung ma ---");
            bool addedAgain = room1.AddDevice(pc1); // PC001 da co san trong room1
            Console.WriteLine("Them PC001 vao Phong Lab 1 lan 2: " + (addedAgain ? "thanh cong" : "that bai (trung ma)"));
            Console.WriteLine();

            // 3. In danh sach thiet bi trong tung phong
            room1.DisplayDevices();
            Console.WriteLine();
            room2.DisplayDevices();
            Console.WriteLine();

            // 4. Tong chi phi bao tri du kien moi phong
            Console.WriteLine("--- Tong chi phi bao tri du kien (1 nam) ---");
            Console.WriteLine("Phong Lab 1: " + room1.CalculateAnnualMaintenanceCost().ToString("N0") + " VND");
            Console.WriteLine("Phong Lab 2: " + room2.CalculateAnnualMaintenanceCost().ToString("N0") + " VND");
            Console.WriteLine();

            // Dat mot so thiet bi vao trang thai can bao tri
            pc2.Status = DeviceStatus.UnderMaintenance;
            pj1.Status = DeviceStatus.UnderMaintenance;

            // 5. Liet ke thiet bi can bao tri
            Console.WriteLine("--- Danh sach thiet bi can bao tri ---");
            PrintDevicesNeedingMaintenance(room1);
            PrintDevicesNeedingMaintenance(room2);
            Console.WriteLine();

            // 6 + 7. Ket noi mang va duyet theo giao dien INetworkable (da hinh)
            Console.WriteLine("--- Ket noi mang cho cac thiet bi INetworkable ---");
            List<INetworkable> networkDevices = new List<INetworkable>();
            networkDevices.Add(pc1);
            networkDevices.Add(pc2);
            networkDevices.Add(pr2); // pr2 la NetworkPrinter, cung thuc thi INetworkable

            foreach (INetworkable dev in networkDevices)
            {
                // Duyet theo giao dien INetworkable ma KHONG can biet lop cu the (da hinh)
                dev.Connect("192.168.1.100");
                Console.WriteLine("Da ket noi thiet bi: " + dev.ToString() +
                                  " -> IP=" + dev.IpAddress + ", IsConnected=" + dev.IsConnected);
            }
            Console.WriteLine();

            Console.WriteLine("--- Ngat ket noi mot thiet bi ---");
            pc1.Disconnect();
            Console.WriteLine("PC001 sau khi ngat ket noi: IsConnected=" + pc1.IsConnected + ", IP='" + pc1.IpAddress + "'");

            Console.WriteLine();
            Console.WriteLine("========== KET THUC ==========");
        }
    }
}
