using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Cau1_OOP_QuanLySachCoBan
{
    class Sach
    {
        private string _maSach;
        private string _tenSach;
        private string _tacGia;
        private int _namXB;
        private double _giaBan;

        public Sach(string maSach, string tenSach, string tacGia, int namXB, double giaBan) 
        {
            this._maSach = maSach;
            this._tenSach = tenSach;
            this._tacGia = tacGia;
            this._namXB = namXB;
            this._giaBan = giaBan;
        }

        // Constructor không tham số
        public Sach()
        {
            _maSach = "";
            _tenSach = "";
            _tacGia = "";
            _namXB = 2000;
            _giaBan = 0.0;
        }
        public string TenSach
        {
            get { return _tenSach; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ten sach khong duoc trong.");
                _tenSach = value;
            }
        }

        public string TacGia
        {
            get { return _tacGia; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ten tac gia khong duoc trong.");
                _tacGia = value;
            }
        }
        public int NamXuatBan
        {
            get
            {
                return _namXB;
            }
            set
            {
                if (value < 1900 || value > 2026)
                {
                    throw new ArgumentException("Nam khong hop le.");
                }

                _namXB = value;
            }
        }

        public double GiaBan
        {
            get { return _giaBan; }
            set { _giaBan = value; }

        }
        public string MaSach
        {
            get { return _maSach; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Ma sach khong duoc trong.");
                }
                _maSach = value;
            }

        }

         public void hienThiThongTin()
        {
            Console.WriteLine("===== THÔNG TIN SÁCH =====");
            Console.WriteLine($"Mã sách       : {_maSach}");
            Console.WriteLine($"Tên sách      : {_tenSach}");
            Console.WriteLine($"Tên sách      : {_tacGia}");
            Console.WriteLine($"Năm xuất bản  : {_namXB}");
            Console.WriteLine($"Giá bán       : {_giaBan} VNĐ");
            Console.WriteLine("==========================");
        }

        public override string ToString()
        {
            return $"[{_maSach}] {_tenSach} - {_tacGia} - NXB: {_namXB} - Giá: {_giaBan:N0} VNĐ";
        }
    } 
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("6551071052");
            Sach sach1 = new Sach();
            sach1.TenSach = "Sách tu luyện lq";
            sach1.TacGia = "Bùi Hữu Hùng";
            sach1.NamXuatBan = 2024;



            Sach sach2 = new Sach("2","Sách tu luyện ff","Bùi Hữu Hùng",2025,100000);
            Sach sach3 = new Sach()
            {
                MaSach = "3",
                TenSach = "Lập trình C# cơ bản",
                TacGia = "Nguyễn Văn A",
                NamXuatBan = 2028,
                GiaBan = 150000
            };

            sach1.hienThiThongTin();
            sach2.hienThiThongTin();
            sach3.hienThiThongTin();

            



        }
    }
}
