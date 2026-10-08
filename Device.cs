// MSSV: 202418947
// Ho ten: Dang Ngoc Minh
using System;

namespace LabW05
{

    {
        // Ma thiet bi: khong duoc rong, chi duoc dat 1 lan khi khoi tao -> dung { get; }
        public string DeviceId { get; }

        // Ten thiet bi (co the thay doi sau nay)
        public string DeviceName { get; set; }

        // Nam dua vao su dung: khong duoc lon hon nam hien tai
        public int PurchaseYear { get; }

        // Gia mua: phai lon hon 0
        public decimal PurchasePrice { get; }

        // Trang thai hoat dong
        public DeviceStatus Status { get; set; }

        // So nam da su dung (tinh tu nam mua den nam hien tai)
        public int YearsInUse
        {
            get { return DateTime.Now.Year - PurchaseYear; }
        }

        public Device(string deviceId, string deviceName, int purchaseYear, decimal purchasePrice)
        {
            // Kiem tra du lieu ngay khi khoi tao
            if (string.IsNullOrWhiteSpace(deviceId))
                throw new ArgumentException("Ma thiet bi khong duoc de trong!");

            if (purchaseYear > DateTime.Now.Year)
                throw new ArgumentException("Nam mua khong duoc lon hon nam hien tai!");

            if (purchasePrice <= 0)
                throw new ArgumentException("Gia mua phai lon hon 0!");

            DeviceId = deviceId;
            DeviceName = deviceName;
            PurchaseYear = purchaseYear;
            PurchasePrice = purchasePrice;
            Status = DeviceStatus.Active;
        }

        // Phuong thuc truu tuong: tinh chi phi bao tri du kien trong 1 nam.
        // Moi lop con phai tu dinh nghia cach tinh rieng.
        public abstract decimal CalculateAnnualMaintenanceCost();

        // Ghi de ToString: tra ve chuoi mo ta thong tin thiet bi
        public override string ToString()
        {
            return "[Ma: " + DeviceId + "] " + DeviceName +
                   " | Nam mua: " + PurchaseYear +
                   " | Gia: " + PurchasePrice.ToString("N0") + " VND" +
                   " | Trang thai: " + Status;
        }
    }
}
