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
    public partial class QLLoai : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        public QLLoai()
        {
            InitializeComponent();
            LoadLoai();
        }
       
        void LoadLoai()
        {
            gridDSSP.ItemsSource = p.loaisanpham.ToList();
        }

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ID = (gridDSSP.SelectedItem as loaisanpham).MaLoaiSP;
                // DonHang temp = new DonHang();
                var xoa = (from s in p.loaisanpham where s.MaLoaiSP == ID select s).SingleOrDefault();
                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa không?", "       Thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    p.loaisanpham.Remove(xoa);
                    p.SaveChanges();
                    LoadLoai();
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
        private void btnLoaiSP_Click(object sender, RoutedEventArgs e)
        {
        try {
        if(txtTenLoaiSP.Text!="")
        {
                    loaisanpham l = new loaisanpham();
                    l.TenLoaiSP = txtTenLoaiSP.Text;
                    p.loaisanpham.Add(l);
                    p.SaveChanges();
                    LoadLoai();
                    MessageBox.Show("Thêm thành công!");
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập dữ liệu thêm!");
                }
          
            }
            catch {
                MessageBox.Show("Lỗi.Nhập nội dung thêm đi!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                int s = int.Parse(txtMaLoai.Text.ToString());
                var sql = p.loaisanpham.Where(m => m.MaLoaiSP == s).FirstOrDefault();
                sql.TenLoaiSP = txtTenLoaiSP.Text;
                p.SaveChanges();
                LoadLoai();
                txtTenLoaiSP.Clear();
                MessageBox.Show("Update thành công!");

            }
            catch
            {
                MessageBox.Show("Lỗi Rồi ! OK");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtTenLoaiSP.Clear();
            txtMaLoai.Clear();
            
        }
    }
}
