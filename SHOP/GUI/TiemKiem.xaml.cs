using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for TiemKiem.xaml
    /// </summary>
    public partial class TiemKiem : UserControl
    {
        ListCollectionView lcv;
        IQueryable<sanpham> SourceFill;

        ShopEntities1 p = new ShopEntities1();
        public TiemKiem()
        {
            InitializeComponent();

            var dc = new ShopEntities1();
            
            var sql = from p in dc.sanpham
                      from c in dc.HangSX
                      where c.MaHangSX == p.MaHangSX
                      select new {p.MaSP, p.TenSP,p.GiaSP,p.Hinh, c.TenHangSX,c.MaHangSX };

            lst.ItemsSource = sql.ToList();
            // lst.ItemsSource = sql1.ToList();
            //   DataContext = dc.Products.ToList();
            lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(lst.ItemsSource);

            var db = this.FindResource("dbForWd") as Pages;
            db.CurPage = 1;
        }


        private void btnF_Click(object sender, RoutedEventArgs e)
        {
          //  lcv.Filter = p => ((sanpham)p).GiaSP > decimal.Parse(txtPrice.Text);
        }

        private void btnDeleF_Click(object sender, RoutedEventArgs e)
        {
            if (lcv.Filter != null)
            {
                lcv.Filter = null;
            }
        }
        static int m = 0;
        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            m = (m + 1) % 3;
            if (m == 0)
            {
                lcv.SortDescriptions.Clear();
            }
            if (m == 1)
            {
                lcv.SortDescriptions.Add(new SortDescription("GiaSP", ListSortDirection.Descending));

            }

        }

        private void btnGroup_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(lst.ItemsSource);
            view.GroupDescriptions.Add(new PropertyGroupDescription("TenHangSX"));
        }
        //Đánh số trang

        List<sanpham> GetSearchQuery(int curPage, int pageSize, out int totalPage)
        {
            IQueryable<sanpham> q = SourceFill;

            totalPage = (int)Math.Ceiling(q.Count() * 1.0 / pageSize);
            lst.ItemsSource = q.OrderBy(p => p.MaSP).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
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
            else
            {
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ListDSLSP.ItemsSource = p.loaisanpham.ToList();
            ListDSNSX.ItemsSource = p.HangSX.ToList();
            SourceFill = p.sanpham;

            var db = this.FindResource("dbForWd") as Pages;
            int totalPage;
            db.CurPage = 1;
            db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
            db.TotalPage = totalPage;
            ButtunPage(totalPage);
        }

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
                                   select timkiem);

                        SourceFill = sql;
                        var db = this.FindResource("dbForWd") as Pages;
                        int totalPage;
                        db.CurPage = 1;
                        db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
                        db.TotalPage = totalPage;
                        ButtunPage(totalPage);
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
                                 
                                   select timkiem);
                     //   lst.ItemsSource = sql;
                        SourceFill = sql;
                        var db = this.FindResource("dbForWd") as Pages;
                        int totalPage;
                        db.CurPage = 1;
                        db.Products = GetSearchQuery(db.CurPage, Pages.PageSize, out totalPage);
                        db.TotalPage = totalPage;
                        ButtunPage(totalPage);
                    }
                }
            }
            else
            {
                lst.ItemsSource = null;
            }
        }

        private void btnLocDSLSP_Click(object sender, RoutedEventArgs e)
        {
            string chuoi = "MaHangSX == 0";
            //string Tile;
            foreach (var check in FindVisualChildren<CheckBox>(ListDSNSX))
            {
                if (check.Name == "checkHangSX")
                {
                    if (check.IsChecked == true)
                    {
                        chuoi += " or " + "MaHangSX ==  " + check.Tag;
                        //Tile += check.ToolTip + " 。";
                    }
                }
            }
        }

        private void btnLocDSHSX_Click(object sender, RoutedEventArgs e)
        {

        }

        void check()
        {
           
        }
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {

        }
        /// <summary>
        /// Tim Tên 1 Element in DataTemplate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }

        private void ListDSLSP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var checkbox in FindVisualChildren<CheckBox>(lst))
            {
                if (checkbox.Name == "checkLoaiSP")
                {

                    if (checkbox.IsChecked == true)
                    {
                        loaisanpham u = (loaisanpham)ListDSLSP.SelectedItem;
                        MessageBox.Show(u.MaLoaiSP.ToString());

                    }
                }
            }
        }
    }
}
