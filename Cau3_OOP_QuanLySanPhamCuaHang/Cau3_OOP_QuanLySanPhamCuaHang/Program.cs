using System;
using System.Collections.Generic;

namespace Cau3_OOP_QuanLySanPhamCuaHang
{

    class SanPham
        {
            private string _maSP;
            private string _tenSP;
            private decimal _gia;
            private int _soLuongTon;

            // Constructor không tham số
            public SanPham()
            {
                _maSP = "";
                _tenSP = "";
                _gia = 0;
                _soLuongTon = 0;
            }

            // Constructor đầy đủ
            public SanPham(
                string maSP,
                string tenSP,
                decimal gia,
                int soLuongTon)
            {
                _maSP = maSP;
                _tenSP = tenSP;
                _gia = gia;
                _soLuongTon = soLuongTon;
            }

            // Property MaSP
            public string MaSP
            {
                get { return _maSP; }
                set { _maSP = value; }
            }

            // Property TenSP
            public string TenSP
            {
                get { return _tenSP; }
                set { _tenSP = value; }
            }

            // Property Gia
            public decimal Gia
            {
                get { return _gia; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Gia khong duoc am.");

                    _gia = value;
                }
            }

            // Property SoLuongTon
            public int SoLuongTon
            {
                get { return _soLuongTon; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException(
                            "So luong ton khong duoc am.");

                    _soLuongTon = value;
                }
            }

            // Phương thức virtual
            public virtual decimal TinhGiaBan()
            {
                return _gia;
            }

            // Phương thức virtual
            public virtual string MoTa()
            {
                return $"Ma SP: {_maSP}, Ten SP: {_tenSP}, " +
                       $"Gia: {_gia:N0} VNĐ, So luong ton: {_soLuongTon}";
            }
        }


        // ================================
        // CLASS SAN PHAM THUC PHAM
        // ================================
        class SanPhamThucPham : SanPham
        {
            private DateTime _ngayHetHan;
            private int _nhietDoBAoquan;

            // Constructor
            public SanPhamThucPham(
                string maSP,
                string tenSP,
                decimal gia,
                int soLuongTon,
                DateTime ngayHetHan,
                int nhietDoBAoquan)
                : base(maSP, tenSP, gia, soLuongTon)
            {
                _ngayHetHan = ngayHetHan;
                _nhietDoBAoquan = nhietDoBAoquan;
            }

            // Property NgayHetHan
            public DateTime NgayHetHan
            {
                get { return _ngayHetHan; }
                set { _ngayHetHan = value; }
            }

            // Property NhietDoBaoQuan
            public int NhietDoBaoQuan
            {
                get { return _nhietDoBAoquan; }
                set { _nhietDoBAoquan = value; }
            }

            // Override TinhGiaBan
            public override decimal TinhGiaBan()
            {
                // Nếu còn từ 3 ngày trở xuống thì giảm 30%
                TimeSpan thoiGianConLai = _ngayHetHan - DateTime.Now;

                if (thoiGianConLai.TotalDays <= 3 &&
                    thoiGianConLai.TotalDays >= 0)
                {
                    return Gia * 0.7m;
                }

                return Gia;
            }

            // Override MoTa
            public override string MoTa()
            {
                return $"[THỰC PHẨM] {MaSP} - {TenSP} | " +
                       $"Giá gốc: {Gia:N0} VNĐ | " +
                       $"Giá bán: {TinhGiaBan():N0} VNĐ | " +
                       $"HSD: {NgayHetHan:dd/MM/yyyy} | " +
                       $"Nhiệt độ bảo quản: {NhietDoBaoQuan}°C | " +
                       $"Tồn: {SoLuongTon}";
            }
        }


        // ================================
        // CLASS SAN PHAM DIEN TU
        // ================================
        class SanPhamDienTu : SanPham
        {
            private int _baoHanhThang;
            private string _hangSanXuat;

            // Constructor
            public SanPhamDienTu(
                string maSP,
                string tenSP,
                decimal gia,
                int soLuongTon,
                int baoHanhThang,
                string hangSanXuat)
                : base(maSP, tenSP, gia, soLuongTon)
            {
                _baoHanhThang = baoHanhThang;
                _hangSanXuat = hangSanXuat;
            }

            // Property BaoHanhThang
            public int BaoHanhThang
            {
                get { return _baoHanhThang; }
                set { _baoHanhThang = value; }
            }

            // Property HangSanXuat
            public string HangSanXuat
            {
                get { return _hangSanXuat; }
                set { _hangSanXuat = value; }
            }

            // Override TinhGiaBan
            public override decimal TinhGiaBan()
            {
                // Nếu bảo hành > 12 tháng thì cộng thêm 10%
                if (_baoHanhThang > 12)
                {
                    return Gia * 1.10m;
                }

                return Gia;
            }

            // Override MoTa
            public override string MoTa()
            {
                return $"[ĐIỆN TỬ] {MaSP} - {TenSP} | " +
                       $"Giá gốc: {Gia:N0} VNĐ | " +
                       $"Giá bán: {TinhGiaBan():N0} VNĐ | " +
                       $"Hãng SX: {HangSanXuat} | " +
                       $"Bảo hành: {BaoHanhThang} tháng | " +
                       $"Tồn: {SoLuongTon}";
            }
        }


        // ================================
        // PROGRAM
        // ================================
        internal class Program
        {
            static void Main(string[] args)
            {
                // List<SanPham> chứa cả 3 loại sản phẩm
                List<SanPham> danhSach = new List<SanPham>()
            {
                // Sản phẩm thường
                new SanPham()
                {
                    MaSP = "SP001",
                    TenSP = "Nước uống",
                    Gia = 10000,
                    SoLuongTon = 100
                },

                // Sản phẩm thực phẩm
                new SanPhamThucPham(
                    "TP001",
                    "Sữa tươi",
                    30000,
                    50,
                    DateTime.Now.AddDays(2),
                    4
                ),

                // Sản phẩm thực phẩm còn hạn lâu
                new SanPhamThucPham(
                    "TP002",
                    "Bánh quy",
                    50000,
                    30,
                    DateTime.Now.AddDays(20),
                    25
                ),

                // Sản phẩm điện tử bảo hành <= 12 tháng
                new SanPhamDienTu(
                    "DT001",
                    "Tai nghe Bluetooth",
                    500000,
                    20,
                    12,
                    "Sony"
                ),

                // Sản phẩm điện tử bảo hành > 12 tháng
                new SanPhamDienTu(
                    "DT002",
                    "Laptop",
                    20000000,
                    10,
                    24,
                    "Dell"
                )
            };


            // ========================================
            // FOREACH - THỂ HIỆN ĐA HÌNH RUNTIME
            // ========================================
                
                Console.WriteLine("===== DANH SÁCH SẢN PHẨM - 6551071052 =====");
            foreach (SanPham sp in danhSach)
                {
                    Console.WriteLine(sp.MoTa());
                    Console.WriteLine(
                        $"Giá bán thực tế: {sp.TinhGiaBan():N0} VNĐ"
                    );
                    Console.WriteLine();
                }


                // ========================================
                // TÍNH TỔNG GIÁ TRỊ KHO
                // ========================================

                decimal tongGiaTriKho = 0;

                foreach (SanPham sp in danhSach)
                {
                    tongGiaTriKho += sp.Gia * sp.SoLuongTon;
                }

                Console.WriteLine("===============================");
                Console.WriteLine(
                    $"Tổng giá trị kho hàng: " +
                    $"{tongGiaTriKho:N0} VNĐ"
                );

                Console.ReadKey();
            }
        }
    }

