// MSSV: 202418947
// Ho ten: Dang Ngoc Minh

using System;

namespace LabW05
{
    // May in co ket noi mang: ke thua Printer va thuc thi INetworkable.
    // Dung cach "ke thua + interface" nen no vua la Printer vua co kha nang mang.
    public class NetworkPrinter : Printer, INetworkable
    {
        public string IpAddress { get; private set; } = "";
        public bool IsConnected { get; private set; }

        public NetworkPrinter(string deviceId, string deviceName, int purchaseYear,
                              decimal purchasePrice, PrinterType type, int pagesPrinted,
                              bool isColor)
            : base(deviceId, deviceName, purchaseYear, purchasePrice, type, pagesPrinted, isColor, true)
        {
            // tham so cuoi cung la true = may in nay luon ho tro mang
        }

        public void Connect(string ipAddress)
        {
            // FIX (sua tu v1): kiem tra IP rong va trang thai da ket noi (giong lop Computer)
            if (string.IsNullOrWhiteSpace(ipAddress))
                throw new ArgumentException("Dia chi IP khong duoc de trong!");

            if (IsConnected)
                throw new InvalidOperationException("Thiet bi dang ket noi roi, khong the ket noi lai!");

            IpAddress = ipAddress;
            IsConnected = true;
        }

        public void Disconnect()
        {
            IsConnected = false;
            IpAddress = ""; // FIX (sua tu v1): xoa IP khi ngat ket noi
        }

        public override string ToString()
        {
            return base.ToString() + " [la may in mang]";
        }
    }
}
