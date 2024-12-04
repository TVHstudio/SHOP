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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SHOP.DAL;

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for QLDonHang.xaml
    /// </summary>
    public partial class QLDonHang : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        public QLDonHang()
        {
            InitializeComponent();
            LoadDH();
        }
        void LoadDH()
        {
            gridDSSP.ItemsSource = p.DONDATHANG.ToList();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnDuyet_Click(object sender, RoutedEventArgs e)
        {
                try
                {


                    DUYETDH cn = new DUYETDH();
                    DAL.DONDATHANG a = gridDSSP.SelectedItem as DAL.DONDATHANG;//lấy dữ liệu trong datagrid
                    int? ID = a.MaKH;//lấy ID sản phẩm trong grid
                    //var sql = (from l in p.loaisanpham
                    //           where l.MaLoaiSP == a.MaLoaiSP
                    //           select l).FirstOrDefault();
                    var sql1 = (from l in p.taikhoan
                                where l.MaTK == a.MaKH
                                select l).FirstOrDefault();
                
                    cn.txtTenKH.Text = sql1.HoTen;
                    cn.txtMaDH.Text = a.MaKH.ToString();
                    cn.txtTongSL.Text = a.TongSoLuong.ToString();
                   if(a.TinhTrangGiao=="false")
                   {
                        cn.txtTinhTrang.Foreground = Brushes.Red;
                        cn.txtTinhTrang.Text = "Chưa Giao Hàng";
                   }
                   else {
                        cn.txtTinhTrang.Foreground = Brushes.Blue;
                        cn.txtTinhTrang.Text = "Đã Giao Hàng";
                   }
                    cn.ma = int.Parse(a.MaKH.ToString());
                    cn.ShowDialog();
                
                }
                catch
                {
                    MessageBox.Show("Không Có Sản Phẩm! xem lại nha");
                }
        }
    }
}
