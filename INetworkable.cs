// MSSV: 202418947
// Ho ten: Dang Ngoc Minh
using System;

namespace LabW05
{
    public interface INetworkable
    {
        string IpAddress { get; }      // dia chi IP hien tai (chi doc)
        bool IsConnected { get; }      // co dang ket noi hay khong (chi doc)

        void Connect(string ipAddress); // ket noi vao dia chi IP
        void Disconnect();              // ngat ket noi
    }
}
