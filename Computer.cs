
// MSSV:202418947
// Ho ten: Dang Ngoc Minh

using System;
namespace LabW05
{
    // May tinh: ke thua lop Device va luon thuc thi interface INetworkable
    public class Computer : Device, INetworkable
    {
        public int RamGB { get; set; }           // dung luong RAM (GB)
        public string CpuType { get; set; }      // loai bo xu ly
        public bool HasDiscreteGpu { get; set; } // co GPU roi hay khong

        // ---------- phan thuc thi INetworkable ----------
        public string IpAddress { get; private set; } = "";
        public bool IsConnected { get; private set; }

        public Computer(string deviceId, string deviceName, int purchaseYear,
                        decimal purchasePrice, int ramGB, string cpuType, bool hasDiscreteGpu)
            : base(deviceId, deviceName, purchaseYear, purchasePrice)
        {
            RamGB = ramGB;
            CpuType = cpuType;
            HasDiscreteGpu = hasDiscreteGpu;
        }

        public override decimal CalculateAnnualMaintenanceCost()
        {
            decimal percent = 5m;                  // 5% gia mua
            if (HasDiscreteGpu) percent += 2m;     // + 2% neu co GPU roi
            // FIX (sua tu v1): de bai yeu cau "tren 5 nam" phai dung > 5, truoc do sai thanh >= 5
            if (YearsInUse > 5) percent += 1m;     // + 1% neu da dung tren 5 nam
            return PurchasePrice * percent / 100m;
        }

        public void Connect(string ipAddress)
        {
            // FIX (sua tu v1): kiem tra dia chi IP khong duoc rong
            if (string.IsNullOrWhiteSpace(ipAddress))
                throw new ArgumentException("Dia chi IP khong duoc de trong!");

            // FIX (sua tu v1): khong cho phep ket noi lai khi dang ket noi
            if (IsConnected)
                throw new InvalidOperationException("Thiet bi dang ket noi roi, khong the ket noi lai!");

            IpAddress = ipAddress;
            IsConnected = true;
        }

        public void Disconnect()
        {
            IsConnected = false;
            IpAddress = ""; // FIX (sua tu v1): xoa dia chi IP khi da ngat ket noi
        }

        public override string ToString()
        {
            return base.ToString() +
                   " | Loai: May tinh | RAM: " + RamGB + "GB | CPU: " + CpuType +
                   " | GPU roi: " + (HasDiscreteGpu ? "Co" : "Khong");
        }
    }
}
