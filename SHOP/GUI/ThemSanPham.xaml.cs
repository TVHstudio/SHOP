using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ThémanPham.xaml
    /// </summary>
    public partial class ThemSanPham : Window
    {
        ShopEntities1 p = new ShopEntities1();
        public string TinhTrang;
        public ThemSanPham()
        {
            InitializeComponent();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Loadloai();
            LoadHang();
            rdonew.IsChecked = true;
            var textRange = new TextRange(txtChiTietSP.Document.ContentStart, txtChiTietSP.Document.ContentEnd);
            textRange.Text = textRange.Text.Replace("\\n","\n");
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
        void Loadloai()
        {
            cbbLoai.ItemsSource = p.loaisanpham.ToList();
        }
        void LoadHang()
        {
            cbbNSX.ItemsSource = p.HangSX.ToList();
        }

       

        private void rdonew_Checked(object sender, RoutedEventArgs e)
        {
            TinhTrang = "New";
        }

        private void rdoold_Checked(object sender, RoutedEventArgs e)
        {
            TinhTrang = "Old";
        }

        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {
            var textRange = new TextRange(txtChiTietSP.Document.ContentStart, txtChiTietSP.Document.ContentEnd);
            string gia = txtGiaSP.Text.ToString();
            try {
                Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");

                if (!regex.IsMatch(gia) || gia.Length <5)
                {
                    txtTB.Text = ("bạn nhập giá tiền chưa đúng! ");
                    return;
                }
                sanpham sp = new sanpham();
                sp.TenSP = txtTenSP.Text;
                sp.GiaSP = int.Parse(txtGiaSP.Text);
                if(txtimage.Text=="")
                {
                    sp.Hinh = @"/SHOP;component/img/p2.png";
                }
                else {
                    sp.Hinh = txtimage.Text;
                }
                sp.NgayNhap = DateTime.Parse(datepk.Text);
                sp.SoLuongTon = txtSLT.Value;
                sp.SoLuongBan = 0;
                sp.SoLuotXem = 0;
                sp.TinhTrang = TinhTrang;
                sp.MoTa = TXTMoTa.Text;
                sp.ChiTiet = textRange.Text;
                sp.XuatXu = txtXuatXu.Text;
                sp.MaLoaiSP = int.Parse(cbbLoai.SelectedValue.ToString());
                sp.MaHangSX = int.Parse(cbbNSX.SelectedValue.ToString());
                //thêm môn học vào database
                p.sanpham.Add(sp);
                if (p.SaveChanges() > 0)
                {
                    txtTB.Text = "";
                    MessageBox.Show("Thêm Thành Công !");
                }
                else
                {
                    MessageBox.Show("Chưa thêm được!");
                }

            
            }
            catch {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
           }

        }
    }
}
