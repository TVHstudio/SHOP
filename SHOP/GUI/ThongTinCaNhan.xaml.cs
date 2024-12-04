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
    /// Interaction logic for ThongTinCaNhan.xaml
    /// </summary>
    public partial class ThongTinCaNhan : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        public ThongTinCaNhan()
        {
            InitializeComponent();
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //int ma = int.Parse(txtTempMaTK.Text.ToString());
            //var sql = (from t in p.taikhoan
            //           where t.MaTK == ma
            //           select t).SingleOrDefault();
           
        }
    }
}
