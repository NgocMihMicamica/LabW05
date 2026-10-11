// MSSV: 202418947
// Ho ten: Dang Ngoc Minh

using System;

namespace LabW05
{
    // Loai may in
    public enum PrinterType
    {
        Laser,   // may in laser
        Inkjet   // may in phun
    }

    // May in: ke thua lop Device (lop nay tu no khong ket noi mang)
    public class Printer : Device
    {
        public PrinterType Type { get; set; }       // loai may in
        public int PagesPrinted { get; set; }       // so trang da in
        public bool IsColor { get; set; }           // co phai may in mau khong
        public bool SupportsNetwork { get; set; }   // co ho tro mang hay khong

        public Printer(string deviceId, string deviceName, int purchaseYear,
                       decimal purchasePrice, PrinterType type, int pagesPrinted,
                       bool isColor, bool supportsNetwork)
            : base(deviceId, deviceName, purchaseYear, purchasePrice)
        {
            Type = type;
            PagesPrinted = pagesPrinted;
            IsColor = isColor;
            SupportsNetwork = supportsNetwork;
        }

        public override decimal CalculateAnnualMaintenanceCost()
        {
            decimal cost = PurchasePrice * 4m / 100m;      // 4% gia mua
            if (PagesPrinted > 100000) cost += 500000m;    // + 500.000 VND neu in tren 100.000 trang
            if (IsColor) cost += 300000m;                  // + 300.000 VND neu la may in mau
            return cost;
        }

        public override string ToString()
        {
            return base.ToString() +
                   " | Loai: May in (" + Type + ")" +
                   " | So trang da in: " + PagesPrinted +
                   " | In mau: " + (IsColor ? "Co" : "Khong") +
                   " | Ho tro mang: " + (SupportsNetwork ? "Co" : "Khong");
        }
    }
}
