using System;
using System.Globalization;
class ConNguoi
{
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public string DiaChi { get; set; }
    public string GioiTinh { get; set; } 
    public virtual void NhapThongTin() {
        Console.Write("Nhap ho ten: ");
        HoTen = Console.ReadLine();
        Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");
        while (true) {
            try 
            {
                NgaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                break;

            } 
            catch 
            {
                Console.WriteLine("Ngay sinh khong dung dinh dang dd/MM/yyyy. Vui long nhap lai: ");
            }
        }
        Console.Write("Nhap dia chi: ");
        DiaChi = Console.ReadLine();
        Console.Write("Nhap gioi tinh: ");
        GioiTinh = Console.ReadLine();
    }
    public virtual void InThongTin() {
        Console.WriteLine();
        Console.WriteLine("Ho ten: " + HoTen);
        Console.WriteLine("Ngay sinh: " + NgaySinh.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
        Console.WriteLine("Dia chi: " + DiaChi);
        Console.WriteLine("Gioi tinh: " + GioiTinh);
    }
}

class SinhVien : ConNguoi 
{
    public int NamDaoTao { get; set; }
    public string NienKhoa { get; set; }
    public string TruongDaiHoc { get; set; }
    public string NganhHoc { get; set; }
    public override void NhapThongTin() 
    {
        base.NhapThongTin();   
        Console.Write("Nhap nam dao tao: ");
        NamDaoTao = Convert.ToInt32(Console.ReadLine());
        while (NamDaoTao <= 0)
        {
            Console.Write("Nam dao tao khong hop le. Vui long nhap lai: ");
            NamDaoTao = Convert.ToInt32(Console.ReadLine());
        }
        Console.Write("Nhap nien khoa: ");
        NienKhoa = Console.ReadLine();
        Console.Write("Nhap truong dai hoc: ");
        TruongDaiHoc = Console.ReadLine();
        Console.Write("Nhap nganh hoc: ");
        NganhHoc = Console.ReadLine();
    }

    public override void InThongTin() 
    {
        Console.WriteLine("THONG TIN SINH VIEN");
        base.InThongTin();
        Console.WriteLine("La sinh vien nam " + NamDaoTao);
        Console.WriteLine("Nien khoa: " + NienKhoa);
        Console.WriteLine("Truong Dai hoc: " + TruongDaiHoc);
        Console.WriteLine("Nganh hoc: " + NganhHoc);
        Console.WriteLine();
    }
}

class HocSinh : ConNguoi 
{
    public string TruongHoc { get; set; }

    public string Lop { get; set; }
    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.Write("Nhap truong học: ");
        TruongHoc = Console.ReadLine();

        Console.Write("Nhap lop: ");
        Lop = Console.ReadLine();
    }
    public override void InThongTin()
    {
        Console.WriteLine("THONG TIN HOC SINH");
        base.InThongTin();
        Console.WriteLine("Truong hoc: " + TruongHoc);
        Console.WriteLine("Lop: " + Lop);
        Console.WriteLine();   
    }
}

class CongNhan : ConNguoi 
{
    public string NoiLamViec { get; set; }
    public double Luong { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();

        Console.Write("Nhap noi lam viec: ");
        NoiLamViec = Console.ReadLine();

        Console.Write("Nhap luong: ");
        Luong = double.Parse(Console.ReadLine());
    }

    public override void InThongTin()
    {
        Console.WriteLine("THONG TIN CONG NHAN");
        base.InThongTin();
        Console.WriteLine("Noi lam viec: " + NoiLamViec);
        Console.WriteLine("Luong: " + Luong);
        Console.WriteLine();   
    }
}

class NgheSi : ConNguoi
{
    public string NgheDanh { get; set; }
    public string LinhVuc { get; set; }

    public override void NhapThongTin()
    {
        base.NhapThongTin();

        Console.Write("Nhap nghe danh: ");
        NgheDanh = Console.ReadLine();

        Console.Write("Nhap linh vuc chuyen mon: ");
        LinhVuc = Console.ReadLine();
    }

    public override void InThongTin()
    {
        Console.WriteLine("THONG TIN NGHE SI/CA SI");
        base.InThongTin();
        Console.WriteLine("Nghe danh: " + NgheDanh);
        Console.WriteLine("Linh vuc: " + LinhVuc);
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConNguoi cn;
        Console.WriteLine("Chon loai doi tuong:");
        Console.WriteLine("1. Sinh vien");
        Console.WriteLine("2. Hoc sinh");
        Console.WriteLine("3. Cong nhan");
        Console.WriteLine("4. Nghe si/ca si");
        Console.Write("Lua chon: ");
        int choice = int.Parse(Console.ReadLine());
        while (choice <= 0 || choice >= 5) 
        {     
            Console.WriteLine("1. Sinh vien");
            Console.WriteLine("2. Hoc sinh");
            Console.WriteLine("3. Cong nhan");
            Console.WriteLine("4. Nghe si/ca si");
            Console.WriteLine("Nhap sai. Vui long chon lai:");
            choice = int.Parse(Console.ReadLine());
        }
        switch (choice)
        {
            case 1:
                cn = new SinhVien();
                Console.WriteLine("Nhap doi tuong sinh vien");
                break;
            case 2:
                cn = new HocSinh();
                Console.WriteLine("Nhap doi tuong hoc sinh");
                break;
            case 3:
                cn = new CongNhan();
                Console.WriteLine("Nhap doi tuong cong nhan");
                break;
            case 4:
                cn = new NgheSi();
                Console.WriteLine("Nhap doi tuong nghe si");
                break;
            default:
                return;
        }
        cn.NhapThongTin();
        cn.InThongTin();
    }
}