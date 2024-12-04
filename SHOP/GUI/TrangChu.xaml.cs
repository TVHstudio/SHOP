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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SHOP.DAL;
using SHOP.GUI;

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class TrangChu : UserControl
    {
        public int Matk;
        //
        ShopEntities1 p = new ShopEntities1();
        public TrangChu()
        {
            InitializeComponent();
     
        }
       

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadSPBanChay();
            loadSPMoiNhat();
            loadSPXemNhieuNhat();
           // MainWindow m = new MainWindow();
            //SPBanChay bc = new SPBanChay();
           
          //  gridBC.Children.Add(bc);
           // SPMoiNhat mn = new SPMoiNhat();
          //  gridnew.Children.Add(mn);
            //SPXemNN x = new SPXemNN();
            //gridlx.Children.Add(x);
            
        }

        private void loadSPBanChay()
        {
            var data = (from d in p.sanpham
                        orderby d.SoLuongBan descending
                        select d).Take(10);
            stpanel.ItemsSource = data.ToList();
        }
        private void loadSPMoiNhat()
        {
            var data = (from d in p.sanpham
                        orderby d.NgayNhap descending
                        where d.TinhTrang == "New"
                        select d).Take(10);
            stpanel1.ItemsSource = data.ToList();
        }

        private void loadSPXemNhieuNhat()
        {
            var data = (from d in p.sanpham
                        orderby d.SoLuotXem descending
                        select d).Take(10);
            stpanel2.ItemsSource = data.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show(txtTrangChuMatk.Text);
            if (Matk == 0)
            {

                MessageBox.Show("Bạn Hãy Đăng Nhập Để Mua Hàng Nha!");
                return;
            }
            {
                DH cn = new DH();

                //lấy dữ liệu trong datacontex
                Button a = sender as Button;
                sanpham datact = a.DataContext as sanpham;
                cn.TempDH.Text = Matk.ToString();//biến tạm để lấy mã khách hàng
               
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

        //lích chuột phải chon đặt hàngh
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            DH cn = new DH();
            // SanPham sp = new SanPham();
            if (stpanel.SelectedIndex > -1)
            {
                string sx = stpanel.SelectedItem.ToString();
                var a = stpanel.SelectedItem;
                //String json = Newtonsoft.Json.JsonConvert.SerializeObject(o);    

                sanpham sp = (sanpham)stpanel.SelectedItem;
                //  var a = stpanel.SelectedItem;
                //Newtonsoft.Json.JsonConvert.DeserializeObject<SanPham>(stpanel.SelectedItem.ToString());

                cn.Focus();
                cn.txtid.Text = sp.MaSP.ToString();
                cn.txtname.Text = sp.TenSP.ToString();
                cn.txtgia.Text = sp.GiaSP.ToString();
                cn.txtmota.Text = sp.MoTa.ToString();
                String stringPath = sp.Hinh;

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
        private void MenuItem_refesh(object sender, RoutedEventArgs e)
        {
            loadSPBanChay();
        }

        private void btnchitiet_Click(object sender, RoutedEventArgs e)
        {
           
            Button t = sender as Button;
            sanpham data = t.DataContext as sanpham;
            int maHSX = int.Parse(data.MaHangSX.ToString());
            int Loai = int.Parse(data.MaLoaiSP.ToString());
            int so = int.Parse(data.SoLuotXem.ToString()) + 1;// mỗi lần xem sex tắng lên
            //slx.Text = so.ToString();
            int ID = data.MaSP;
            var sql = p.sanpham.Where(m => m.MaSP == ID).FirstOrDefault();
            sql.SoLuotXem = int.Parse(so.ToString());
            p.SaveChanges();//lưu thây đổi lượt xem
            var sql1 = p.HangSX.Where(m => m.MaHangSX == maHSX).FirstOrDefault();//lấy hãng ra so sánh
            var sql2 = p.loaisanpham.Where(m => m.MaLoaiSP == Loai).FirstOrDefault();//lây loai ra so sanh

            Chitiet ct = new Chitiet();

            //lấy dữ liệu trong datacontex
            Button a = sender as Button;
            sanpham datact = a.DataContext as sanpham;
            ct.txtID.Text = datact.MaSP.ToString();
            ct.txtMaTKCT.Text = txtTrangChuMatk.Text;
            // var s = datact as SanPham;
            ct.tbTenSP.Text = datact.TenSP.ToString();
            ct.tbGia.Text = datact.GiaSP.ToString();

            ct.tbSLX.Text = so.ToString();
            ct.tbSLB.Text = datact.SoLuongBan.ToString();
            ct.tbMoTa.Text = datact.MoTa.ToString();
            ct.tbXuatXu.Text = datact.XuatXu.ToString();

            string text = datact.ChiTiet.ToString();
            IList<string> lines = text.Split(new string[] { @"\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                ct.txtmotachitiet.Inlines.Add(line);
                ct.txtmotachitiet.Inlines.Add(new LineBreak());
            }
            ct.tbLoai.Text = sql2.TenLoaiSP;
            ct.tbNSX.Text = sql1.TenHangSX;
            String stringPath = datact.Hinh.ToString();

            if (File.Exists(stringPath))
            {

                Uri imageUri = new Uri(stringPath, UriKind.Absolute);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                ct.imghinh.Source = new BitmapImage(imageUri);
            }
            else
            {
                Uri imageUri = new Uri(@"E:\PHONE\PHONE\image\iphone7plus.jpg", UriKind.Absolute);//mặt định nếu khong có ảnh thì sẽ là ảnh này
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                ct.imghinh.Source = new BitmapImage(imageUri);
            }
            ct.Show();
        }
    }
}
