using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using SHOP.DAL;

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for UpdateTTCN.xaml
    /// </summary>
    public partial class UpdateTTCN : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        public int matk;

        public string ConfigPass { get; private set; }

        public UpdateTTCN()
        {
            InitializeComponent();
             validtion v = new validtion();
           
            grDMK.Visibility = Visibility.Hidden;
        }

        private void btnChonHinh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image File (.jpg)|*.jpg|.png|*.png|All File (*.*)|*.*";
            openFile.FilterIndex = 1;

            openFile.Multiselect = false;

            bool? userOK = openFile.ShowDialog();

            if (userOK == true)
            {
                txtLinkHinh.Text = openFile.FileName;
                String stringPath = txtLinkHinh.Text.ToString();
                if (File.Exists(stringPath))//hàm sử lí hình ảnh
                {
                    Uri imageUri = new Uri(stringPath, UriKind.Absolute);
                    imgHinh.Source = new BitmapImage(imageUri);
                }
                else
                {
                    Uri imageUri = new Uri(@"/SHOP;component/img/p2.png", UriKind.Absolute);
                    imgHinh.Source = new BitmapImage(imageUri);
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
       
            string hoten = txtName.Text;
            string sdt = txtSDT.Text.ToString();
            string dob = txtNS.Text;
            string diachi = txtDC.Text;
            string email = txtEmail.Text;
            try
            {
                Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");

                if (sdt.Length < 10 || sdt.Length > 11 || !regex.IsMatch(sdt))
                {
                    txtTB.Text = ("Số Điện thoại nhập chưa đúng! ");
                    return;
                }

                if (string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(email))
                {
                    
                    txtTB.Text = ("Bạn Chưa Nhập đủ dữ liệu! ");
                    return;
                }
                if (!Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    txtTB.Text = ("Email chưa hợp lệ!");
                    return;
                }
                else
                {
                    var sql = p.taikhoan.Where(m => m.MaTK == matk).FirstOrDefault();
                    if (sql == null)
                    {
                        MessageBox.Show("Lỗi!");
                        return;
                    }
                    sql.HoTen = txtName.Text;
                    sql.SDT = int.Parse(txtSDT.Text.ToString());
                    sql.DOB = txtNS.Text;
                    sql.DiaChi = txtDC.Text;
                    sql.Email = txtEmail.Text;

                    if (txtLinkHinh.Text == "")
                    {
                        sql.Hinh = sql.Hinh;
                    }
                    else
                    {
                        sql.Hinh = txtLinkHinh.Text;
                    }
                    txtTB.Text = "";
                    p.SaveChanges();
                    MessageBox.Show("Update Thành Công rồi!");
                }
              
            }
            catch
            {
                MessageBox.Show("Update Chưa Thành công!");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnThayDoi_Click(object sender, RoutedEventArgs e)
        {

            string MKCu = tbOpass.Password;
            string MKMoi = tbNPass.Password;
            string NhapLai = tbCPass.Password;

            using (ShopEntities1 db = new ShopEntities1())
            {

                var mh = db.taikhoan.Where(m => m.MaTK == matk).Single() as taikhoan;
                if (mh == null)
                {
                    MessageBox.Show("Fail!");
                    return;

                }

                if (string.IsNullOrEmpty(tbOpass.Password) || string.IsNullOrEmpty(tbNPass.Password) || string.IsNullOrEmpty(tbCPass.Password))
                {
                    error.Content = ("dữ liệu còn trống!");
                    return;
                }
                else
                {
                    var password = (from h in p.taikhoan
                                    where h.MaTK == matk
                                    select h.MatKhau).SingleOrDefault();

                    if (tbOpass.Password != password)
                    {
                        error.Content = "Mật khẩu củ bị sai!";
                        return;
                    }
                    if (tbNPass.Password != NhapLai)
                    {
                        error.Content = "xác thực mật khẩu không đúng!";
                        return;
                    }
                    else
                    {
                        mh.MatKhau = tbNPass.Password;
                        if (db.SaveChanges() > 0)
                        {
                            MessageBox.Show("đổi thành công!");
                            error.Content = "";
                         //   Expan.IsExpanded = false;

                        }
                    }

                }

            }
        }

        private void btnTDMK_Click(object sender, RoutedEventArgs e)
        {
            grDMK.Visibility = Visibility.Visible;
        }

    }
}
