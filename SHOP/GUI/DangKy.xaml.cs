using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DangKy.xaml
    /// </summary>
    public partial class DangKy : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        public DangKy()
        {
            InitializeComponent();
            validtion v = new validtion();
            v.Phone = "";
            v.Email = "";
            DataContext = v;
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            taikhoan a = new taikhoan();
            string user = txtUser.Text;
            string pass = txtPass.Password;
            string nhaplai = txtNhapLai.Password;
            string hoten = txtName.Text;
            string sdt = txtSDT.Text.ToString();
            string dob = txtNS.Text;
            string diachi = txtDC.Text;
            string email = txtEmail.Text;
            try
            {


                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(nhaplai) || string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(email))
                {

                    txtTB.Text = ("Bạn Chưa Nhập đủ dữ liệu! ");
                    return;
                }
                if (!Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    txtTB.Text = ("Email chưa hợp lệ!");
                    return;
                }
                if (txtPass.Password != nhaplai)
                {
                    txtTB.Text = "xác thực mật khẩu không đúng!";
                    return;
                }
                else
                {
                    a.TenDN = user;
                    a.MatKhau = pass;
                    a.HoTen = txtName.Text;
                    a.SDT = int.Parse(txtSDT.Text.ToString());
                    a.DOB = txtNS.Text;
                    a.DiaChi = txtDC.Text;
                    a.Email = txtEmail.Text;
                    a.MaLoaiTK = 0;
                    txtTB.Text = "";
                    p.taikhoan.Add(a);
                    p.SaveChanges();
                    MessageBox.Show("Đăng Ký Thành Công rồi!");
                }

            }
            catch
            {
                MessageBox.Show("Đăng ký Chưa Thành công!");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
