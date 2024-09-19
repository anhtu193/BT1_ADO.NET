using System;
using System.Collections.Generic;

class Ellipse
{
    public double BanTrucLon { get; set; }
    public double BanTrucNho { get; set; }
    public Ellipse(double banTrucLon, double banTrucNho)
    {
        BanTrucLon = banTrucLon;
        BanTrucNho = banTrucNho;
    }
    public virtual double TinhChuVi()
    {
        double h = Math.Pow((BanTrucLon - BanTrucNho), 2) / Math.Pow((BanTrucLon + BanTrucNho), 2);
        return Math.PI * (BanTrucLon + BanTrucNho) * (1 + (3 * h / (10 + Math.Sqrt(4 - 3 * h))));
    }

    public virtual double TinhDienTich()
    {
        return Math.PI * BanTrucLon * BanTrucNho;
    }

    public virtual void InThongTin()
    {
        Console.WriteLine("Ellipse - Ban truc lon: " + BanTrucLon + ", Ban truc nho: " + BanTrucNho);
        Console.WriteLine("Chu vi: " + TinhChuVi() + ", Dien tich: " + TinhDienTich());
    }
}

class Circle : Ellipse
{
    public double BanKinh
    {
        get { return BanTrucLon; } // Vì hình tròn là hình ellipse có bán trục lớn bằng bán trục nhỏ
    }
     public Circle(double banKinh) : base(banKinh, banKinh) {}
    
    public override double TinhChuVi()
    {
        return 2 * Math.PI * BanKinh;
    }

    public override double TinhDienTich()
    {
        return Math.PI * BanKinh * BanKinh;
    }

    public override void InThongTin()
    {
        Console.WriteLine("Hinh tron - Ban kinh: " + BanKinh);
        Console.WriteLine("Chu vi: " + TinhChuVi() + ", Dien tich: " + TinhDienTich());
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Ellipse> danhSachHinh = new List<Ellipse>();
        bool tiepTuc = true;
        int choice;
        while (tiepTuc)
        {
            Console.WriteLine("Chon loai hinh:");
            Console.WriteLine("1. Hinh tron");
            Console.WriteLine("2. Hinh ellipse");
            Console.Write("Lua chon: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Nhap ban kinh hinh tron: ");
                double banKinh = double.Parse(Console.ReadLine());
                Circle hinhTron = new Circle(banKinh);
                danhSachHinh.Add(hinhTron);
            }
            else if (choice == 2)
            {
                Console.Write("Nhap ban truc lon cua ellipse: ");
                double banTrucLon = double.Parse(Console.ReadLine());
                Console.Write("Nhap ban truc nho cua ellipse: ");
                double banTrucNho = double.Parse(Console.ReadLine());
                while (banTrucLon < banTrucNho)
                {
                    Console.Write("Ban truc nho > Ban truc lon. Vui long nhap lai ban truc nho cua ellipse: ");
                    banTrucNho = double.Parse(Console.ReadLine());
                }
                Ellipse ellipse = new Ellipse(banTrucLon, banTrucNho);
                danhSachHinh.Add(ellipse);
            }
            else
            {
                Console.WriteLine("Lua chon khong hop le, vui long nhap lai!");
                continue;
            }

            Console.Write("Ban co muon nhap them hinh khong? (y/n): ");
            string tiepTucNhap = Console.ReadLine().ToLower();
            tiepTuc = tiepTucNhap == "y";
        }

        Console.WriteLine("\nDANH SACH CAC HINH DA NHAP");
        foreach (Ellipse hinh in danhSachHinh)
        {
            Console.WriteLine("------------------------");  
            hinh.InThongTin();
        }
    }
}