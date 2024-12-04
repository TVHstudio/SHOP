
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

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for DSSP.xaml
    /// </summary>
    public partial class SanPham : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        public SanPham()
        {
            InitializeComponent();
            LoadHangSX();
            LoadLoaiSX();
          
        }

        private void LoadHangSX()
        {
            lbHSX.ItemsSource = p.HangSX.ToList();
        }
        private void LoadLoaiSX()
        {
            lbLSX.ItemsSource = p.loaisanpham.ToList();
           
        }
        private void loadSP()
        {
            var data = from d in p.sanpham
                       select d;
            stpanel.ItemsSource = data.ToList();
        }

        // nhấn button đặt hàng
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(tempSP.Text=="")
            {
                MessageBox.Show("Bạn Hãy Đăng Nhập Để Mua Hàng Nha!");
                return;
            }
            {
                DH cn = new DH();
                
                cn.TempDH.Text = tempSP.Text;//biến tạm để lấy mã khách hàng
                //lấy dữ liệu trong datacontex
                Button a = sender as Button;
                sanpham datact = a.DataContext as sanpham;

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
            loadSP();
        }

        //load combobox
        public void loadcbb()
        {
            cbb.ItemsSource = p.HangSX.ToList();
            //var sql = from lh in p.HangSX
            //          select new { lh.MaHangSX, lh.TenHangSX };
            cbb.DisplayMemberPath = "TenHangSX";
            cbb.SelectedValuePath = "MaHangSX";
            //cbb.ItemsSource = sql.ToList();
        }

        //binding san phẩm
        private void cbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var s = int.Parse(cbb.SelectedValue.ToString());
            var sql = from sp in p.sanpham
                      from h in p.HangSX
                      where (sp.MaHangSX == h.MaHangSX) && h.MaHangSX == s
                      select sp;
            stpanel.ItemsSource = sql.ToList();

            ////  loadSach();
            //ShopPhoneEntities4 context = new ShopPhoneEntities4();
            //TextBlock q = new TextBlock();
            //stpanel.DataContext = context.SanPham.ToList();
            //stpanel.SelectedValuePath = "MaSP";
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
           
            loadSP();
         //   loadcbb();
        }

        // sự kiện Hãng sản xuất
        private void lbHSX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HangSX u = (HangSX)lbHSX.SelectedItem;  
            int s = int.Parse(u.MaHangSX.ToString());
            var sql = from sp in p.sanpham
                      from h in p.HangSX
                      where (sp.MaHangSX == h.MaHangSX) && h.MaHangSX == s
                      select sp;
            DSSPtheoten.Text = "                  DANH SÁCH SẢN PHẨM THEO HÃNG               ";
            stpanel.ItemsSource = sql.ToList();
        }

        private void lbLSX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loaisanpham u = (loaisanpham)lbLSX.SelectedItem;
            int s = int.Parse(u.MaLoaiSP.ToString());
            var sql = from sp in p.sanpham
                      from h in p.loaisanpham
                      where (sp.MaLoaiSP == h.MaLoaiSP) && h.MaLoaiSP == s
                      select sp;
            DSSPtheoten.Text = "                  DANH SÁCH SẢN PHẨM THEO LOẠI               ";
            stpanel.ItemsSource = sql.ToList();
        }
        //chi tiết của sản phẩm
        private void btnchitiet_Click(object sender, RoutedEventArgs e)
        {
          
            Button t = sender as Button;
            sanpham data = t.DataContext as sanpham;
            int maHSX = int.Parse(data.MaHangSX.ToString());
            int Loai = int.Parse(data.MaLoaiSP.ToString());
            int so= int.Parse(data.SoLuotXem.ToString()) + 1;// mỗi lần xem sex tắng lên
            slx.Text = so.ToString();
            int ID = data.MaSP;
            var sql = p.sanpham.Where(m => m.MaSP == ID).FirstOrDefault();
            sql.SoLuotXem = int.Parse(slx.Text);
            p.SaveChanges();//lưu thây đổi lượt xem
            var sql1 = p.HangSX.Where(m => m.MaHangSX == maHSX).FirstOrDefault();//lấy hãng ra so sánh
            var sql2 =p.loaisanpham.Where(m => m.MaLoaiSP == Loai).FirstOrDefault();//lây loai ra so sanh

            Chitiet ct = new Chitiet();

            //lấy dữ liệu trong datacontex
            Button a = sender as Button;
            sanpham datact = a.DataContext as sanpham;
            ct.txtID.Text = datact.MaSP.ToString();
            ct.txtMaTKCT.Text = txtMaTKSP.Text;
            // var s = datact as SanPham;
            ct.tbTenSP.Text = datact.TenSP.ToString();
            ct.tbGia.Text = datact.GiaSP.ToString();
         
            ct.tbSLX.Text =slx.Text;
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

        //Tìm Kiếm Sản Phẩm
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                decimal search;
                if (decimal.TryParse(txtTimKiem.Text, out search))
                {
                    using (var BH = new ShopEntities1())
                    {
                        var sql = (from timkiem in BH.sanpham
                                   where timkiem.GiaSP >= search
                                   select timkiem).ToList().Take(5);

                        stpanel.ItemsSource = sql;
                    }
                }
                else
                {
                    using (var BH = new ShopEntities1())
                    {
                        var sql = (from timkiem in BH.sanpham
                                   from tk in BH.loaisanpham
                                   from tk1 in BH.HangSX
                                   where (timkiem.MaLoaiSP == tk.MaLoaiSP && timkiem.MaHangSX == tk1.MaHangSX && timkiem.TenSP.Contains(txtTimKiem.Text))
                                   || (timkiem.MaLoaiSP == tk.MaLoaiSP && timkiem.MaHangSX == tk1.MaHangSX && tk.TenLoaiSP.Contains(txtTimKiem.Text))
                                   || (timkiem.MaHangSX == tk1.MaHangSX && timkiem.MaLoaiSP == tk.MaLoaiSP && tk1.TenHangSX.Contains(txtTimKiem.Text))
                                   select timkiem).ToList().Take(5);
                        stpanel.ItemsSource = sql;

                    }
                }
            }
            else
            {
                stpanel.ItemsSource = null;
            }
        }
        //tự động nó chạy theo list danh sách
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
            //{
            //    btnSearch_Click(sender, e);
            //}
        }

       
        //private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    DH cn = new DH((int)e.Parameter);

        //    //lấy dữ liệu trong datacontex
        //    Button a = sender as Button;
        //    sanpham datact = a.DataContext as sanpham;

        //    // var s = datact as SanPham;
        //    cn.txtname.Text = datact.TenSP.ToString();
        //    cn.txtid.Text = datact.MaSP.ToString();
        //    cn.txtmota.Text = datact.MoTa.ToString();
        //    cn.txtname.Text = datact.TenSP.ToString();
        //    cn.txtgia.Text = datact.GiaSP.ToString();
        //    String stringPath = datact.Hinh.ToString();

        //    if (File.Exists(stringPath))
        //    {

        //        Uri imageUri = new Uri(stringPath, UriKind.Absolute);
        //        BitmapImage imageBitmap = new BitmapImage(imageUri);
        //        cn.hinh.Source = new BitmapImage(imageUri);
        //    }
        //    else
        //    {
        //        Uri imageUri = new Uri(@"E:\PHONE\PHONE\image\iphone7plus.jpg", UriKind.Absolute);
        //        BitmapImage imageBitmap = new BitmapImage(imageUri);
        //        cn.hinh.Source = new BitmapImage(imageUri);
        //    }
        //    cn.Show();
        //}


    }
}
