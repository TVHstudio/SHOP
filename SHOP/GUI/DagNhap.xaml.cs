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
using System.Windows.Shapes;
using SHOP.DAL;

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for DagNhap.xaml
    /// </summary>
    public partial class DagNhap : Window
    {
        public delegate void PassData(string s);
        public event PassData share;
        ShopEntities1 p = new ShopEntities1();
        public DagNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            // SqlCommand command;
            string Ten = txtName.Text;
            string MK = txtMK.Password;
            var nd = (from n in p.taikhoan
                      where (n.TenDN == Ten &&
                            n.MatKhau == MK)
                      select n).FirstOrDefault();

            if (Ten == "" && MK == "")
            {
                lblKT.Content = "Chưa nhập Tài khoản và mật khẩu! ";
            }
            else
            {
                if (Ten == "" && MK != "")
                {


                    lblKT.Content = "Chưa nhập tên đăng nhập ";

                }
                else
                {
                    if (Ten != "" && MK == "")
                    {

                        lblKT.Content = "Chưa nhập Mật Khẩu! ";

                    }
                    else
                    {
                        if (Ten != "" && MK != "")
                        {
                            if(nd !=null)
                            {
                                share?.Invoke(nd.TenDN.ToString());
                                Visibility = Visibility.Collapsed;
                            }
                            else
                            {
                                this.lblKT.Content = "Tên Đăng Nhập hoăc Mật khẩu sai! ";
                            }
                        }

                    }
                }

            }

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnthoat_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow m = new MainWindow();
            m.Visibility = Visibility.Collapsed;
       
        }
    }
}
