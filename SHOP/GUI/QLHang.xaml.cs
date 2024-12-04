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
    /// Interaction logic for QLLoai.xaml
    /// </summary>
    public partial class QLHang : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        public QLHang()
        {
            InitializeComponent();
            LoadHang();
        }

        void LoadHang()
        {
            gridDSSP.ItemsSource = p.HangSX.ToList();
        }

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ID = (gridDSSP.SelectedItem as HangSX).MaHangSX;
                // DonHang temp = new DonHang();
                var xoa = (from s in p.HangSX where s.MaHangSX == ID select s).SingleOrDefault();
                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa không?", "       Thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    p.HangSX.Remove(xoa);
                    p.SaveChanges();
                    LoadHang();
                    //Application.Current.Shutdown();
                }
            }
            catch
            {
                MessageBox.Show("Không xóa được ! OK");
            }
        }

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {

        }
        //Thêm Loại Sản Phẩm
        private void btnHangSP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtTenHangSP.Text!="")
                {
                    HangSX l = new HangSX();
                    l.TenHangSX = txtTenHangSP.Text;
                    p.HangSX.Add(l);
                    p.SaveChanges();
                    LoadHang();
                    MessageBox.Show("Thêm thành công!");
                }
                else {
                    MessageBox.Show("chưa nhập dữ liệu thêm!");
                }
              
            }
            catch
            {
                MessageBox.Show("Lỗi.Nhập nội dung thêm đi!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int s = int.Parse(txtMaHang.Text.ToString());
                var sql = p.HangSX.Where(m => m.MaHangSX == s).FirstOrDefault();
                sql.TenHangSX = txtTenHangSP.Text;
                p.SaveChanges();
                LoadHang();
                txtTenHangSP.Clear();
                MessageBox.Show("Update thành công!");

            }
            catch
            {
                MessageBox.Show("Lỗi Rồi ! OK");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtTenHangSP.Clear();
            txtMaHang.Clear();

        }
    }
}
