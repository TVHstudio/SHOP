using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SHOP.DAL;

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for Chitiet.xaml
    /// </summary>
    public partial class Chitiet : Window
    {
        public int TempMKH { get; set; }
        ShopEntities1 p = new ShopEntities1();
        public Chitiet()
        {
            InitializeComponent();
            //SPCungHang bc = new SPCungHang();
            //gridCH.Children.Add(bc);
            //SPCungLoai cl = new SPCungLoai();
            //gridCL.Children.Add(cl);
            loadSPCH();
            loadSPCL();

        }
        private void loadSPCH()
        {
            var data = (from d in p.sanpham
                        where d.MaHangSX == 3
                        select d).Take(5);
            stpanel.ItemsSource = data.ToList();
        }

        private void loadSPCL()
        {

            var data = (from d in p.sanpham
                        where d.MaLoaiSP == 2
                        select d).Take(5);
            stpanel1.ItemsSource = data.ToList();

            // stpanel.ItemsSource = p.SanPham.ToList();
            //  stpanel.SelectedValuePath = "MaSP";

        }
        private void tbGia_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void btnMuaTrongCt_Click(object sender, RoutedEventArgs e)
        {
            //  MessageBox.Show(txtMaTKCT.Text);

            if (txtMaTKCT.Text != "")
            {
                var sp = new DAL.DonHang
                {
                    MaKH = int.Parse(txtMaTKCT.Text),
                    MaSP = int.Parse(txtID.Text),
                    TenSP = tbTenSP.Text,
                    SoLuong = txtsl.Value,
                    NgayLap = DateTime.Now,
                    GiaBan = int.Parse(tbGia.Text),
                    TongTien = int.Parse(tbGia.Text) * txtsl.Value

                };

                using (var ql = new ShopEntities1())
                {
                    // int n = ql.DonHang.Where(m => m.MaSP == sp.MaSP).Count();
                    int n = (from d in ql.DonHang
                             where d.MaSP == sp.MaSP && d.MaKH == sp.MaKH
                             select d).Count();
                    if (n > 0)
                    {
                        try
                        {
                            //   var n1 = ql.DonHang.Where(m => m.MaSP == sp.MaSP).FirstOrDefault();
                            var sql = ql.sanpham.Where(m => m.MaSP == sp.MaSP).FirstOrDefault();
                            var n1 = (from d in ql.DonHang
                                      where d.MaSP == sp.MaSP && d.MaKH == sp.MaKH
                                      select d).FirstOrDefault();
                            n1.SoLuong = n1.SoLuong + sp.SoLuong;
                            n1.TongTien = n1.GiaBan * n1.SoLuong;
                            sql.SoLuongTon = sql.SoLuongTon - sp.SoLuong;
                            if (sql.SoLuongTon < 0)
                            {
                                MessageBox.Show("Sản Phẩm Này Hết rồi!");
                                return;
                            }

                            sql.SoLuongBan = sql.SoLuongBan + sp.SoLuong;

                            ql.SaveChanges();

                            MessageBox.Show("Đã thêm vào giỏ hàng của bạn");
                        }
                        catch
                        {
                            MessageBox.Show("Thêm thất bại!");
                        }

                    }
                    else
                    {
                        //thêm môn học vào database
                        ql.DonHang.Add(sp);
                        if (ql.SaveChanges() > 0)
                        {

                            MessageBox.Show("Đã thêm vào giỏ hàng của bạn");

                        }
                        else
                        {
                            MessageBox.Show("Chưa thêm được!");
                        }
                        //Load lại danh sách môn học
                        // var ocMh = new ObservableCollection<SinhVien>(qlsv.SinhVien.ToList());

                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn Hãy Đăng Nhập để mua!");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(txtTrangChuMatk.Text);
            if (txtMaTKCT.Text == "")
            {
                MessageBox.Show("Bạn Hãy Đăng Nhập Để Mua Hàng Nha!");
                return;
            }
            {
                DH cn = new DH();
                txtMaTKCT.Text = "0";
                //lấy dữ liệu trong datacontex
                Button a = sender as Button;
                sanpham datact = a.DataContext as sanpham;
                cn.TempDH.Text = txtMaTKCT.Text;//biến tạm để lấy mã khách hàng

                // var s = datact as SanPham;
                cn.txtname.Text = datact.TenSP.ToString();
                cn.txtid.Text = datact.MaSP.ToString();
                cn.txtmota.Text = datact.MoTa.ToString();
                cn.txtname.Text = datact.TenSP.ToString();
                cn.txtgia.Text = datact.GiaSP.ToString();
                String stringPath = datact.Hinh.ToString();

                if (File.Exists(stringPath))
                {

                    Uri imageUri = new Uri(stringPath, UriKind.Absolute);
                    BitmapImage imageBitmap = new BitmapImage(imageUri);
                    cn.hinh.Source = new BitmapImage(imageUri);
                }
                else
                {
                    Uri imageUri = new Uri(@"E:\PHONE\PHONE\image\iphone7plus.jpg", UriKind.Absolute);
                    BitmapImage imageBitmap = new BitmapImage(imageUri);
                    cn.hinh.Source = new BitmapImage(imageUri);
                }
                cn.Show();
            }
        }
    }
}

