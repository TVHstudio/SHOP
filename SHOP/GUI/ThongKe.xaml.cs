using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ThongKe.xaml
    /// </summary>
    public partial class ThongKe : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        CThongKe tk = new CThongKe();
        public ThongKe()
        {
            InitializeComponent();
            var md = new Chart {Year =2017, Years=new List<int> { 2016, 2017 },
            CurCatID=-1 };
            md.Cats = new List<DAL.loaisanpham> { new DAL.loaisanpham {TenLoaiSP="Tất Cả", MaLoaiSP=-1 } };
            using (var dc=new ShopEntities1())
            {
                md.Cats.AddRange(dc.loaisanpham);
                
            }
            DataContext = md;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var sp = (from n in p.sanpham
                      join t in p.loaisanpham
                      on n.MaLoaiSP equals t.MaLoaiSP
                      group n by t.TenLoaiSP into g
                      select new
                      {
                          g.Key,
                          ten = g.Key,
                          soluong = g.Sum(x => x.SoLuongBan)
                      }).ToList();
            myReportTheLoai_SoLuong.ItemsSource = sp;
            var sp1 = (from n in p.sanpham
                      join t in p.HangSX
                      on n.MaHangSX equals t.MaHangSX
                      group n by t.TenHangSX into g
                      select new
                      {
                          g.Key,
                          ten = g.Key,
                          soluong = g.Sum(x => x.SoLuongBan)
                      }).ToList();
            myReportTheHang_SoLuong.ItemsSource = sp1;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
