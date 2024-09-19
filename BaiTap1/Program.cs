
class NhanVien
{
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public virtual double TinhLuong()
    {
        return 0;
    }
}

class NhanVienSanXuat : NhanVien
{
    public double LuongCanBan { get; set; }
    public int SoSanPham { get; set; }

    public override double TinhLuong()
    {
        return LuongCanBan + SoSanPham * 5000;
    }
}

class NhanVienVanPhong : NhanVien
{
    public int SoNgayLamViec { get; set; }

    public override double TinhLuong()
    {
        return SoNgayLamViec * 100000;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<NhanVien> danhSachNhanVien = new List<NhanVien>();

        NhanVienSanXuat nvSanXuat = new NhanVienSanXuat
        {
            HoTen = "Thieu Bao Tram",
            NgaySinh = new DateTime(2003, 5, 15),
            LuongCanBan = 3000000,
            SoSanPham = 100
        };
        danhSachNhanVien.Add(nvSanXuat);

        NhanVienVanPhong nvVanPhong = new NhanVienVanPhong
        {
            HoTen = "Hai Tu",
            NgaySinh = new DateTime(2003, 8, 22),
            SoNgayLamViec = 22
        };
        danhSachNhanVien.Add(nvVanPhong);

        foreach (NhanVien nv in danhSachNhanVien)
        {
            Console.WriteLine("Ho ten: " + nv.HoTen);
            Console.WriteLine("Ngay sinh: " + nv.NgaySinh.ToShortDateString());
            Console.WriteLine("Luong: " + nv.TinhLuong() + "\n");
        }
    }
}
