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
    /// Interaction logic for QLNguoiDung.xaml
    /// </summary>
    public partial class QLNguoiDung : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        public QLNguoiDung()
        {
            InitializeComponent();
            gridDSND.ItemsSource = p.taikhoan.ToList();
        }

        private void btnLSMH_Click(object sender, RoutedEventArgs e)
        {
            LSNguoiDung ls = new LSNguoiDung();
            DAL.taikhoan a = gridDSND.SelectedItem as DAL.taikhoan;//lấy dữ liệu trong datagrid
            ls.TempMatk = a.MaTK;
            ls.txtTenKH.Text = a.HoTen;
            ls.txtMaKH.Text = a.MaTK.ToString();
            ls.ShowDialog();

            
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
