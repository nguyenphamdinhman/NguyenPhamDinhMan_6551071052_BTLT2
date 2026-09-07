using System;

namespace Cau2_OOP_TinhLuongNhanVien
{
    class NhanVien
    {
        // Khai báo field private
        private string _maNV;
        private string _hoTen;
        private decimal _luongCoBan;
        private int _soNgayLam;
        private int _soNgayNghiPhep;

        // Constructor không tham số
        public NhanVien()
        {
            _maNV = "";
            _hoTen = "";
            _luongCoBan = 5_000_000;
            _soNgayLam = 26;
            _soNgayNghiPhep = 0;
        }

        // Constructor chỉ nhận mã NV và họ tên
        public NhanVien(string maNV, string hoTen)
        {
            _maNV = maNV;
            _hoTen = hoTen;
            _luongCoBan = 5_000_000;
            _soNgayLam = 26;
            _soNgayNghiPhep = 0;
        }

        // Constructor đầy đủ tham số
        public NhanVien(
            string maNV,
            string hoTen,
            decimal luongCoBan,
            int soNgayLam,
            int soNgayNghiPhep)
        {
            _maNV = maNV;
            _hoTen = hoTen;
            _luongCoBan = luongCoBan;
            _soNgayLam = soNgayLam;
            _soNgayNghiPhep = soNgayNghiPhep;
        }

        // Constructor có Optional Parameters
        public NhanVien(
            string maNV,
            string hoTen,
            decimal luong = 5_000_000,
            int soNgayLam = 26)
        {
            _maNV = maNV;
            _hoTen = hoTen;
            _luongCoBan = luong;
            _soNgayLam = soNgayLam;
            _soNgayNghiPhep = 0;
        }

        // Property HoTen
        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        // Property LuongCoBan
        public decimal LuongCoBan
        {
            get { return _luongCoBan; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "Luong co ban khong duoc am.");
                }

                _luongCoBan = value;
            }
        }

        // Property SoNgayLam
        public int SoNgayLam
        {
            get { return _soNgayLam; }
            set
            {
                if (value < 0 || value > 31)
                {
                    throw new ArgumentException(
                        "So ngay lam phai tu 0 den 31.");
                }

                _soNgayLam = value;
            }
        }

        // Property chỉ đọc - tính tự động
        public decimal LuongThucNhan
        {
            get
            {
                decimal khauTruBHXH = _luongCoBan * 8 / 100;

                return _luongCoBan / 26 * _soNgayLam
                       - khauTruBHXH;
            }
        }

        // TinhThuong() - không có tham số
        public decimal TinhThuong()
        {
            return 0;
        }

        // TinhThuong(decimal heSo)
        public decimal TinhThuong(decimal heSo)
        {
            return _luongCoBan * heSo;
        }

        // TinhThuong(decimal heSo, bool coPhucLoi)
        public decimal TinhThuong(decimal heSo, bool coPhucLoi)
        {
            decimal thuong = _luongCoBan * heSo;

            if (coPhucLoi)
            {
                thuong += 500_000;
            }

            return thuong;
        }

        // Hiển thị thông tin
        public void HienThiThongTin()
        {
            Console.WriteLine("===== THÔNG TIN NHÂN VIÊN =====");
            Console.WriteLine($"Mã NV          : {_maNV}");
            Console.WriteLine($"Họ tên         : {_hoTen}");
            Console.WriteLine($"Lương cơ bản   : {_luongCoBan:N0} VNĐ");
            Console.WriteLine($"Số ngày làm    : {_soNgayLam}");
            Console.WriteLine($"Lương thực nhận: {LuongThucNhan:N0} VNĐ");
            Console.WriteLine("================================");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Constructor không tham số
            NhanVien nv1 = new NhanVien();

            nv1.HoTen = "Nguyễn Văn An";
            nv1.LuongCoBan = 6_000_000;
            nv1.SoNgayLam = 26;


            // 2. Constructor chỉ có mã NV và họ tên
            NhanVien nv2 = new NhanVien(
                "NV002",
                "Trần Văn Bình"
            );


            // 3. Constructor đầy đủ tham số
            NhanVien nv3 = new NhanVien(
                "NV003",
                "Lê Văn Cường",
                8_000_000,
                24,
                2
            );


            // 4. Constructor Optional Parameters + Named Arguments
            NhanVien nv4 = new NhanVien(
                maNV: "NV004",
                hoTen: "Phạm Văn Dũng",
                soNgayLam: 20
            );

            Console.WriteLine("6551071052");
            // Hiển thị thông tin
            nv1.HienThiThongTin();
            Console.WriteLine();

            nv2.HienThiThongTin();
            Console.WriteLine();

            nv3.HienThiThongTin();
            Console.WriteLine();

            nv4.HienThiThongTin();


            // =========================================
            // Gọi 3 overload TinhThuong
            // =========================================

            Console.WriteLine("\n===== TÍNH THƯỞNG NV4 =====");

            decimal thuong1 = nv4.TinhThuong();

            decimal thuong2 = nv4.TinhThuong(0.1m);

            decimal thuong3 = nv4.TinhThuong(0.1m, true);

            Console.WriteLine($"TinhThuong()              : {thuong1:N0} VNĐ");
            Console.WriteLine($"TinhThuong(0.1)           : {thuong2:N0} VNĐ");
            Console.WriteLine($"TinhThuong(0.1, true)     : {thuong3:N0} VNĐ");

            Console.WriteLine("\n===== SO SÁNH =====");

            if (thuong1 < thuong2)
            {
                Console.WriteLine("TinhThuong(0.1) cao hơn TinhThuong().");
            }

            if (thuong3 > thuong2)
            {
                Console.WriteLine(
                    "TinhThuong(0.1, true) cao hơn TinhThuong(0.1) " +
                    "do có thêm phúc lợi 500.000 VNĐ."
                );
            }

            Console.ReadKey();
        }
    }
}