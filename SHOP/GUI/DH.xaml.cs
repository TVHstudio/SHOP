using System;
using System.Collections.Generic;
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
    /// Interaction logic for DonHang.xaml
    /// </summary>
    public partial class DH : Window
    {
        ShopEntities1 p = new ShopEntities1();
        public DH()
        {
            InitializeComponent();
            // loadSach();
            if (txtgia.Text != "")
            {
                loadtien();
            }
        }
        public void loadtien()
        {
            txtgia.Text = string.Format("{0:0,0 VNĐ}", double.Parse(txtgia.Text));
        }
        private void loadSach()
        {
            var l = from c in p.sanpham
                    where c.MaSP == 1
                    select new { MaSP = c.MaSP, TenSP = c.TenSP, Hinh = c.Hinh, GiaSP = c.GiaSP, ChiTiet = c.ChiTiet };
            //  lstdonhang.ItemsSource = l.ToList();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
       

        }

        private void btbThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnmua_Click(object sender, RoutedEventArgs e)
        {
            try {
                var sp = new DAL.DonHang
                {
                    MaKH = int.Parse(TempDH.Text),
                    MaSP = int.Parse(txtid.Text),
                    TenSP = txtname.Text,
                    SoLuong = txtsl.Value,
                    NgayLap = DateTime.Parse(datepk.Text),
                    GiaBan = int.Parse(txtgia.Text),
                    TongTien = int.Parse(txtgia.Text) * txtsl.Value

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

            }catch {
                MessageBox.Show("mua không thành công !");
            }
            

        }
    }
}
