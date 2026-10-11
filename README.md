# Lab W05A - Quan ly thiet bi (Device + INetworkable)

Bai thuc hanh OOP C#: lop truu tuong `Device`, interface `INetworkable`, tinh da hinh.

## Cau truc thu muc

- `v1/` : ban DRAFT - co loi co y (xem TODO trong code).
- `v2/` : ban FINAL - da sua loi + comment ly do sua.

## Cach chay (Windows + Visual Studio hoac .NET SDK)

### Cach 1: Visual Studio
1. Mo Visual Studio -> `File > Open > Project/Solution` -> chon file `LabW05.csproj`.
2. Bam `F5` (hoac nut Start) de chay.

### Cach 2: dotnet CLI
```
cd v2
dotnet run
```

> Neu ban chua co .NET 8, mo file `LabW05.csproj` va doi `net8.0` thanh
> phien ban ban da cai (vd `net6.0`, `net7.0`). Kiem tra bang `dotnet --list-sdks`.

## Quy trinh git (upload GitHub)

1. Khoi tao repo va commit PHIEN BAN 1 (draft)
```
git init
git add .
git commit -m "feat: khoi tao khung va code ban dau cho module quan ly thiet bi, con loi validate va chua kiem tra trung ma"
git branch -M main
git remote add origin <LINK_REPO>
git push -u origin main
```

2. Ngay sau, copy toan bo file trong `v2/` de len `v1/` (hoac sua truc tiep),
   roi commit PHIEN BAN 2 (da sua loi)
```
git add .
git commit -m "fix: khac phuc loi validate connect IP, kiem tra trung ma thiet bi va dieu kien tren 5 nam, hoan thien commit v1"
git push
```

## Luu y
- Nho thay `MSSV: SV00001` va `Ho ten: Nguyen Van A` trong dau moi file bang
  ma sinh vien va ten cua ban truoc khi nop.