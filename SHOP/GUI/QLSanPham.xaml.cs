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
using SHOP.BUS;
using SHOP.DAL;

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for QLSanPham.xaml
    /// </summary>
    public partial class QLSanPham : UserControl
    {
        IQueryable<sanpham> SourceFill;
        ShopEntities1 p = new ShopEntities1();
        public QLSanPham()
        {
            InitializeComponent();
            var db = this.FindResource("dbForWd") as Pages;
            db.CurPage = 1;
            // LoadDSSP();
            
        }

        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {
            ThemSanPham add = new ThemSanPham();
            add.ShowDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // db.Cats = nw.Categories.ToList();
            // db.Suppliers = nw.Suppliers.ToList();



            SourceFill = p.sanpham;

            var db = this.FindResource("dbForWd") as Pages;
            int totalPage;
            db.CurPage = 1;
            db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
            db.TotalPage = totalPage;
            ButtunPage(totalPage);
        }
        void LoadDSSP()
        {
            DataContext = p.sanpham.ToList();
        }

        //CHức Năng Xóa Sản Phẩm
        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ID = (gridDSSP.SelectedItem as sanpham).MaSP;
                // DonHang temp = new DonHang();
                var xoa = (from s in p.sanpham where s.MaSP == ID select s).SingleOrDefault();
                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa không?", "       Thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    p.sanpham.Remove(xoa);
                    p.SaveChanges();
                    LoadDSSP();
                    //Application.Current.Shutdown();
                }
            }
            catch
            {
                MessageBox.Show("Không có sản phẩm để xóa ! OK");
            }
        }

        //Chức Năng Sữa Sản Phẩm
        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
        try {

        
            UpdateSanPham cn = new UpdateSanPham();
            sanpham a = gridDSSP.SelectedItem as sanpham;//lấy dữ liệu trong datagrid
            int ID = a.MaSP;//lấy ID sản phẩm trong grid
            var sql = (from l in p.loaisanpham
                       where l.MaLoaiSP == a.MaLoaiSP
                       select l).FirstOrDefault();
            var sql1 = (from l in p.HangSX
                        where l.MaHangSX == a.MaHangSX
                        select l).FirstOrDefault();
                cn.MaSP = ID;
            cn.txtTenSP.Text = a.TenSP;
            cn.txtGiaSP.Text = a.GiaSP.ToString();
            cn.TXTMoTa.Text = a.MoTa;
            if (a.TinhTrang == "New")
            {
                cn.rdonew.IsChecked = true;
            }
            else
            {
                cn.rdoold.IsChecked = true;
            }
            cn.txtSLT.Value = int.Parse(a.SoLuongTon.ToString());
            cn.txtXuatXu.Text = a.XuatXu;

            cn.txtTempLoai.Text = sql.TenLoaiSP;
            cn.txtTempHang.Text = sql1.TenHangSX;
            cn.txtTempLoaiMS.Text = sql.MaLoaiSP.ToString();
            cn.txtTempHangMS.Text = sql1.MaHangSX.ToString();
            var textRange = new TextRange(cn.txtChiTietSP.Document.ContentStart, cn.txtChiTietSP.Document.ContentEnd);
             textRange.Text = a.ChiTiet;

            //string text = a.ChiTiet;
            //IList<string> lines = text.Split(new string[] { @"\n" }, StringSplitOptions.None);
            //foreach (string line in lines)
            //{
            //    cn.txtChiTietSP.Inlines.Add(line);
            //    cn.txtChiTietSP.Inlines.Add(new LineBreak());
            //}
            String stringPath = a.Hinh.ToString();

            if (File.Exists(stringPath))
            {

                Uri imageUri = new Uri(stringPath, UriKind.Absolute);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                cn.imghinh.Source = new BitmapImage(imageUri);
            }
            else
            {
                Uri imageUri = new Uri(@"E:\PHONE\PHONE\image\iphone7plus.jpg", UriKind.Absolute);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                cn.imghinh.Source = new BitmapImage(imageUri);
            }
            cn.Show();
            }catch
            {
                MessageBox.Show("Không Có Sản Phẩm! xem lại nha");
            }
        }
        //Đánh số trang

        List<sanpham> GetSearchQuery(int curPage, int pageSize, out int totalPage)
        {
            IQueryable<sanpham> q = SourceFill;

            totalPage = (int)Math.Ceiling(q.Count() * 1.0 / pageSize);
            gridDSSP.ItemsSource = q.OrderBy(p => p.MaSP).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return q.OrderBy(c => c.MaSP).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
        }

        private void ButtunPage(int total)
        {
            int totalPage = total;
            List<PageButton> ListBtn = new List<PageButton>();
            PageButton t;
            for (int i = 0; i < totalPage; i++)
            {
                t = new PageButton();
                t.I = i + 1;
                ListBtn.Add(t);
            }
            ListButton.ItemsSource = ListBtn;

        }
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            var db = this.FindResource("dbForWd") as Pages;
            int temp;
            int totalPage;
            if (db.CurPage > 1 && int.TryParse(btnInPage.Text, out temp) && temp <= Convert.ToInt32(txtTotal.Text) && temp >= 1)
            {
                db.CurPage--;
            }
            else { return; }
            db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
            db.TotalPage = totalPage;
            ListButton.SelectedIndex = db.CurPage - 1;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            var db = this.FindResource("dbForWd") as Pages;

            int totalPage;
            int temp;
            if (db.CurPage < db.TotalPage && int.TryParse(btnInPage.Text, out temp) && temp <= Convert.ToInt32(txtTotal.Text) && temp >= 1)
            {
                db.CurPage++;
            }
            else { 
                return; 
            }
            db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
            db.TotalPage = totalPage;
            ListButton.SelectedIndex = db.CurPage - 1;
        }


        private void btnInPage_KeyDown(object sender, KeyEventArgs e)
        {
            int n;
            if (!int.TryParse(btnInPage.Text, out n))
            {
                n = 1;
            }
            else if (n <= Convert.ToInt32(txtTotal.Text) && n >= 1)
            {
                var db = this.FindResource("dbForWd") as Pages;

                int totalPage;

                db.CurPage = n;

                db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
                db.TotalPage = totalPage;
                ListButton.SelectedIndex = n - 1;
            }
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;

            PageButton D = temp.DataContext as PageButton;
            int Id = D.I;
            var db = this.FindResource("dbForWd") as Pages;
            ListButton.SelectedIndex = Id - 1;
            int totalPage;

            db.CurPage = Id;

            db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
            db.TotalPage = totalPage;
        }
    }
}
