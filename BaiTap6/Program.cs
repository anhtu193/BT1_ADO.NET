class Animal
{
    public int SoLuong { get; set; }
    public int SoLuongCon { get; set; }
    public int TongLuongSua { get; set; }
    public string TiengKeu { get ; set; }

    public Animal()
    {
        SoLuong = 0;
        SoLuongCon = 0;
        TongLuongSua = 0;
    }
    public void sinhCon()
    {
        Console.Write("\nSo luong con sinh duoc cua moi ca the nhu sau: ");
        for (int i = 0; i < SoLuong; i++)
        {
            Random rand = new Random();
            int SoLuongConMoiLanDe = rand.Next(1,10);
            Console.Write(SoLuongConMoiLanDe + " ");
            SoLuongCon += SoLuongConMoiLanDe;
        }
        SoLuong += SoLuongCon;
    }

    public void keu()
    {
        for (int i = 0; i < SoLuong; i++)
        {
            Console.Write(TiengKeu + " ");
        }
    }
    public void NhapSoLuong() {
        SoLuong = int.Parse(Console.ReadLine());
    }

    public void InThongTin()
    {
        Console.WriteLine();
        Console.WriteLine("So luong ca the trong bay: " + SoLuong);
        Console.WriteLine("So luong con sinh duoc: " + SoLuongCon);
        Console.WriteLine("Tong luong sua: " + TongLuongSua);
    }

    public virtual void InThongTinSauKhiSinhConChoSua() {}
    public virtual void choSua() {}
}

class Cow : Animal
{
    public Cow()
    {
        TiengKeu = "Moo";
    }

    public override void InThongTinSauKhiSinhConChoSua()
    {
        Console.WriteLine("\nTHONG TIN DAN BO SAU KHI SINH CON/CHO SUA");
        choSua();
        base.sinhCon();
        base.InThongTin();
    }
    public override void choSua()
    {
        Console.Write("\nSo luong sua moi ca the cho duoc nhu sau: ");
        for (int i = 0; i < SoLuong; i++)
        {
            Random rand = new Random();
            int SoLuongSuaMoiLanCho = rand.Next(0,20);
            Console.Write(SoLuongSuaMoiLanCho + " ");
            TongLuongSua += SoLuongSuaMoiLanCho;
        }
    }
}

class Sheep : Animal
{
    public Sheep()
    {
        TiengKeu = "Bee";
    }
    public override void InThongTinSauKhiSinhConChoSua()
    {
        Console.WriteLine("\nTHONG TIN DAN CUU SAU KHI SINH CON/CHO SUA");
        choSua();
        base.sinhCon();
        base.InThongTin();
    }
    public override void choSua()
    {
        Console.Write("\nSo luong sua moi ca the cho duoc nhu sau: ");
        for (int i = 0; i < SoLuong; i++)
        {
            Random rand = new Random();
            int SoLuongSuaMoiLanCho = rand.Next(0,5);
            Console.Write(SoLuongSuaMoiLanCho + " ");
            TongLuongSua += SoLuongSuaMoiLanCho;
        }
    }
}

class Goat : Animal
{
    public Goat()
    {
        TiengKeu = "Baa";
    }
    public override void InThongTinSauKhiSinhConChoSua()
    {
        Console.WriteLine("\nTHONG TIN DAN DE SAU KHI SINH CON/CHO SUA");
        choSua();
        base.sinhCon();
        base.InThongTin();
    }
    public override void choSua()
    {
        Console.Write("\nSo luong sua moi ca the cho duoc nhu sau: ");
        for (int i = 0; i < SoLuong; i++)
        {
            Random rand = new Random();
            int SoLuongSuaMoiLanCho = rand.Next(0,10);
            Console.Write(SoLuongSuaMoiLanCho + " ");
            TongLuongSua += SoLuongSuaMoiLanCho;
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Animal> TrangTrai = new List<Animal>();
        Cow danBo = new Cow();
        Console.Write("Nhap so luong bo: ");
        danBo.NhapSoLuong();
        TrangTrai.Add(danBo);

        Sheep danCuu = new Sheep();
        Console.Write("Nhap so luong cuu: ");
        danCuu.NhapSoLuong();
        TrangTrai.Add(danCuu);

        Goat danDe = new Goat();
        Console.Write("Nhap so luong de: ");
        danDe.NhapSoLuong();
        TrangTrai.Add(danDe);

        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("\na) Khi chu di vang, nhung tieng keu nghe duoc trong trang trai la:");
        foreach (Animal animal in TrangTrai)
        {
            animal.keu();
            Console.WriteLine();
        }

        Console.WriteLine("\nb) Sau mot lua sinh, mot luoc cho sua, thong tin trang trai nhu sau:");
        foreach (Animal animal in TrangTrai)
        {
            animal.InThongTinSauKhiSinhConChoSua();
        }
    }
}