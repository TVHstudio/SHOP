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

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for AD.xaml
    /// </summary>
    public partial class AD : UserControl
    {
        public AD()
        {
            InitializeComponent();
            QLSanPham sp = new QLSanPham();
            txtit.Text = "Quản Lý Sản Phẩm";
            gridtab.Children.Add(sp);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tabgioithieu.Visibility = Visibility.Hidden;
            gtDonHang.Visibility = Visibility.Hidden;
            tabcontrol.SelectedIndex = 0;
        }

        private void btnQLDH_Click(object sender, RoutedEventArgs e)
        {
            QLDonHang DH = new QLDonHang();
            txtit.Text = "Quản Lý Đơn Hàng";
            tabcontrol.SelectedIndex = 1;
            tabgioithieu.Visibility = Visibility.Visible;
            gtDonHang.Visibility = Visibility.Visible;
            gtDonHang.Children.Add(DH);
        }

        private void btnQLSP_Click(object sender, RoutedEventArgs e)
        {
            QLSanPham sp = new QLSanPham();
            txtit.Text = "Quản Lý Sản Phẩm";
            tabcontrol.SelectedIndex = 0;
            gridtab.Children.Add(sp);
        }

        private void btnQLLOAI_Click(object sender, RoutedEventArgs e)
        {
            QLLoai l = new QLLoai();
            txtit.Text = "Quản lý Loại";
            tabcontrol.SelectedIndex = 0;
            gridtab.Children.Add(l);
        }

        private void btnQLH_Click(object sender, RoutedEventArgs e)
        {
            QLHang h = new QLHang();
            txtit.Text = "Quản Lý Hãng";
            tabcontrol.SelectedIndex = 0;
            gridtab.Children.Add(h);   
         }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            QLSanPham sp = new QLSanPham();
            txtit.Text = "Quản Lý Sản Phẩm";
            tabcontrol.SelectedIndex = 0;
            gridtab.Children.Add(sp);
        }

        private void clearDH_Click(object sender, RoutedEventArgs e)
        {
            QLDonHang DH = new QLDonHang();
            txtit.Text = "Quản Lý Đơn Hàng";
            tabcontrol.SelectedIndex = 1;
            gtDonHang.Children.Add(DH);
        }

        private void btnQLND_Click(object sender, RoutedEventArgs e)
        {
            QLNguoiDung nd = new QLNguoiDung();
            tabcontrol.SelectedIndex = 0;
            gridtab.Children.Add(nd);
        }

        private void btnreport_Click(object sender, RoutedEventArgs e)
        {
            ThongKe tk = new ThongKe();
            tabcontrol.SelectedIndex = 0;
            gridtab.Children.Add(tk);
        }
    }
}
