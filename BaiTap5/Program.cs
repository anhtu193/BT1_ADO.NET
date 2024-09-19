using System;

abstract class HinhHoc
{
    public abstract double TinhChuVi();
    public abstract double TinhDienTich();
    public abstract void NhapThongTin();
    public abstract void InThongTin();
}

class HinhThang : HinhHoc
{
    public double DayLon { get; set; }
    public double DayNho { get; set; }
    public double ChieuCao { get; set; }
    public double CanhBen1 { get; set; }
    public double CanhBen2 { get; set; }

    public override void NhapThongTin()
    {
        Console.WriteLine("NHAP THONG TIN HINH THANG");
        Console.Write("Nhap day lon cua hinh thang: ");
        DayLon = double.Parse(Console.ReadLine());
        Console.Write("Nhap day nho cua hinh thang: ");
        DayNho = double.Parse(Console.ReadLine());
        while (DayNho > DayLon) 
        {
            Console.WriteLine("Day nho > Day lon. Vui long nhap lai!");
            Console.Write("Nhap day nho cua hinh thang: ");
            DayNho = double.Parse(Console.ReadLine());
        }
        Console.Write("Nhap chieu cao cua hinh thang: ");
        ChieuCao = double.Parse(Console.ReadLine());
        Console.Write("Nhap canh ben 1 cua hinh thang: ");
        CanhBen1 = double.Parse(Console.ReadLine());
        Console.Write("Nhap canh ben 2 cua hinh thang: ");
        CanhBen2 = double.Parse(Console.ReadLine());
    }

    public override double TinhChuVi()
    {
        return DayLon + DayNho + CanhBen1 + CanhBen2;
    }

    public override double TinhDienTich()
    {
        return (DayLon + DayNho) * ChieuCao / 2;
    }

    public override void InThongTin()
    {
        Console.WriteLine("Hinh Thang - Day lon: " + DayLon + ", Day nho: " + DayNho + ", Chieu cao: " + ChieuCao + ", Canh ben 1: " + CanhBen1 + ", Canh ben 2: " + CanhBen2);
        Console.WriteLine("Chu vi: " + TinhChuVi() + ", Dien tich: " + TinhDienTich());
    }
}

class HinhBinhHanh : HinhHoc
{
    public double Day { get; set; }
    public double CanhBen { get; set; }
    public double ChieuCao { get; set; }

    public override void NhapThongTin()
    {
        Console.WriteLine("NHAP THONG TIN HINH BINH HANH");
        Console.Write("Nhap day cua hinh binh hanh: ");
        Day = double.Parse(Console.ReadLine());
        Console.Write("Nhap canh ben cua hinh binh hanh: ");
        CanhBen = double.Parse(Console.ReadLine());
        Console.Write("Nhap chieu cao cua hinh binh hanh: ");
        ChieuCao = double.Parse(Console.ReadLine());
    }

    public override double TinhChuVi()
    {
        return 2 * (Day + CanhBen);
    }

    public override double TinhDienTich()
    {
        return Day * ChieuCao;
    }

    public override void InThongTin()
    {
        Console.WriteLine("Hinh binh hanh - Day: " + Day + ", Canh ben: " + CanhBen + ", Chieu cao: " + ChieuCao);
        Console.WriteLine("Chu vi: " + TinhChuVi() + ", Dien tich: " + TinhDienTich());
    }
}

class HinhChuNhat : HinhHoc
{
    public double ChieuDai { get; set; }
    public double ChieuRong { get; set; }

    public override void NhapThongTin()
    {
        Console.WriteLine("NHAP THONG TIN HINH CHU NHAT");
        Console.Write("Nhap chieu dai cua hinh chu nhat: ");
        ChieuDai = double.Parse(Console.ReadLine());
        Console.Write("Nhap chieu rong cua hinh chu nhat: ");
        ChieuRong = double.Parse(Console.ReadLine());
        while (ChieuRong > ChieuDai)
        {
            Console.WriteLine("Chieu rong > Chieu dai. Vui long nhap lai!");
            Console.Write("Nhap chieu rong cua hinh chu nhat: ");
            ChieuRong = double.Parse(Console.ReadLine());
        }
    }

    public override double TinhChuVi()
    {
        return 2 * (ChieuDai + ChieuRong);
    }

    public override double TinhDienTich()
    {
        return ChieuDai * ChieuRong;
    }

    public override void InThongTin()
    {
        Console.WriteLine("Hinh chu nhat - Chieu dai: " + ChieuDai + ", Chieu rong: " + ChieuRong);
        Console.WriteLine("Chu vi: " + TinhChuVi() + ", Dien tich: " + TinhDienTich());
    }
}

class HinhVuong : HinhChuNhat
{
    public double Canh { get; set; }

    public override void NhapThongTin()
    {
        Console.WriteLine("NHAP THONG TIN HINH VUONG");
        Console.Write("Nhap canh cua hinh vuong: ");
        Canh = double.Parse(Console.ReadLine());
    }

    public override double TinhChuVi()
    {
        return 4 * Canh;
    }

    public override double TinhDienTich()
    {
        return Canh * Canh;
    }

    public override void InThongTin()
    {
        Console.WriteLine("Hinh vuong - Canh: " + Canh);
        Console.WriteLine("Chu vi: " + TinhChuVi() + ", Dien tich: " + TinhDienTich());
    }
}

class Program
{
    static void Main(string[] args)
    {
        HinhHoc hinh = null;
        Console.WriteLine("Chon loai hinh:");
        Console.WriteLine("1. Hinh thang");
        Console.WriteLine("2. Hinh binh hanh");
        Console.WriteLine("3. Hinh chu nhat");
        Console.WriteLine("4. Hinh vuong");
        Console.Write("Lua chon cua ban: ");
        int luaChon = int.Parse(Console.ReadLine());

        while (luaChon <= 0 || luaChon >= 5)
        {
            Console.WriteLine("Lua chon khong hop le. Vui long nhap lai:");
            luaChon = int.Parse(Console.ReadLine());
        }
        switch (luaChon)
        {
            case 1:
                hinh = new HinhThang();
                break;
            case 2:
                hinh = new HinhBinhHanh();
                break;
            case 3:
                hinh = new HinhChuNhat();
                break;
            case 4:
                hinh = new HinhVuong();
                break;
            default:
                return;
        }

        hinh.NhapThongTin();
        hinh.InThongTin();
    }
}
