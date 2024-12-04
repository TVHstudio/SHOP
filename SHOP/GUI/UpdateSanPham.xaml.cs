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
using Microsoft.Win32;
using SHOP.DAL;

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for UpdateSanPham.xaml
    /// </summary>
    public partial class UpdateSanPham : Window
    {
        ShopEntities1 p = new ShopEntities1();
        public int MaSP;
        public UpdateSanPham()
        {
            
            InitializeComponent();
            
            rdonew.IsChecked = true;
            Loadloai();
            LoadHang();
           
        }
        public string TinhTrang;
       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var textRange = new TextRange(txtChiTietSP.Document.ContentStart, txtChiTietSP.Document.ContentEnd);
            textRange.Text = textRange.Text.Replace("\\n","\n");
            cbbLoai.SelectedItem = txtTempLoai.Text;
          //  textRange.Text = txtChiTietSP.Text;

        }
        void Loadloai()
        {
            cbbLoai.ItemsSource = p.loaisanpham.ToList();
        }
        void LoadHang()
        {
            cbbNSX.ItemsSource = p.HangSX.ToList();
        }

        private void rdoold_Checked(object sender, RoutedEventArgs e)
        {
            TinhTrang = "Old";
        }

        private void rdonew_Checked(object sender, RoutedEventArgs e)
        {
            TinhTrang = "New";
        }
        private void btnUpdateSanPham_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var textRange = new TextRange(txtChiTietSP.Document.ContentStart, txtChiTietSP.Document.ContentEnd);

                var sql = p.sanpham.Where(m => m.MaSP == MaSP).FirstOrDefault();
                sanpham sp = new sanpham();
                sql.TenSP = txtTenSP.Text;
                sql.GiaSP = int.Parse(txtGiaSP.Text);
                if (txtimage.Text == "")
                {
                    sql.Hinh = sql.Hinh;
                }
               else
               {
                    sql.Hinh = txtimage.Text;
               }
                sql.NgayNhap = DateTime.Parse(datepk.Text);
                sql.SoLuongTon = txtSLT.Value;
                sql.SoLuongBan = 0;
                sql.SoLuotXem = 0;
                sql.TinhTrang = TinhTrang;
                sql.MoTa = TXTMoTa.Text;
                 sp.ChiTiet = textRange.Text;
                sql.XuatXu = txtXuatXu.Text;
                sql.MaLoaiSP = int.Parse(txtTempLoaiMS.Text);
                sql.MaHangSX = int.Parse(txtTempHangMS.Text);
                p.SaveChanges();
                MessageBox.Show("Update Thành Công rồi!");
            }
            catch
            {
                MessageBox.Show("Update Chưa Thành công!");
            }

        }

        private void btnChonHinh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image File (.jpg)|*.jpg|.png|*.png|All File (*.*)|*.*";
            openFile.FilterIndex = 1;

            openFile.Multiselect = false;

            bool? userOK = openFile.ShowDialog();

            if (userOK == true)
            {
                txtimage.Text = openFile.FileName;
                String stringPath = txtimage.Text.ToString();
                if (File.Exists(stringPath))//hàm sử lí hình ảnh
                {
                    Uri imageUri = new Uri(stringPath, UriKind.Absolute);
                    imghinh.Source = new BitmapImage(imageUri);
                }
                else
                {
                    Uri imageUri = new Uri(@"/SHOP;component/img/p2.png", UriKind.Absolute);
                    imghinh.Source = new BitmapImage(imageUri);
                }
            }
        }

        private void cbbLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }
    }
}
