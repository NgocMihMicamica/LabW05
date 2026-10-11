// MSSV: 202418947
// Ho ten: Dang Ngoc Minh

using System;

namespace LabW05
{
    // May chieu: ke thua lop Device, khong ket noi mang
    public class Projector : Device
    {
        public int BrightnessLumen { get; set; }  // do sang (lumen)
        public int LampHoursUsed { get; set; }    // so gio da dung bong den

        public Projector(string deviceId, string deviceName, int purchaseYear,
                         decimal purchasePrice, int brightnessLumen, int lampHoursUsed)
            : base(deviceId, deviceName, purchaseYear, purchasePrice)
        {
            BrightnessLumen = brightnessLumen;
            LampHoursUsed = lampHoursUsed;
        }

        public override decimal CalculateAnnualMaintenanceCost()
        {
            decimal cost = PurchasePrice * 3m / 100m;     // 3% gia mua
            if (LampHoursUsed > 3000) cost += 1500000m;   // + 1.500.000 VND neu bong dang dung tren 3000 gio
            return cost;
        }

        public override string ToString()
        {
            return base.ToString() +
                   " | Loai: May chieu | Do sang: " + BrightnessLumen + " lumen" +
                   " | Gio dung bong: " + LampHoursUsed;
        }
    }
}
