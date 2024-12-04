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
    /// Interaction logic for countDH.xaml
    /// </summary>
    public partial class countDH : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        public countDH()
        {
            InitializeComponent();
            loadf();
        }
        public void loadf()
        {
          
            //đếm số lượng trong giỏ
            var sql = (from s in p.DonHang
                       select s).Count();
            gio.Text = sql.ToString();
        }
    }
}
