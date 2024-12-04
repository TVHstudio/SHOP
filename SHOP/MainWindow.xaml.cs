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
using System.Windows.Threading;
using SHOP.DAL;
using SHOP.GUI;

namespace SHOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int mataikhoan;
        public delegate void Data(int makh);
        public event Data sharema;
       
        ShopEntities1 p = new ShopEntities1();
        DagNhap login = new DagNhap();
        SanPham sp = new SanPham();
        ThongTinCaNhan ttcn = new ThongTinCaNhan();
        Chitiet ctsp = new Chitiet();
        public MainWindow()
        {
            InitializeComponent();
            
           

            //Lấy ngày hiện tại
            DispatcherTimer RunTime = new DispatcherTimer();
            RunTime.Tick += new EventHandler(RunTime_Clock);
            RunTime.Interval = new TimeSpan(0, 0, 1);
            RunTime.Start();
           
            //nếu chưa đăng nhập thì cho ẩn mấy cái đám này
            btnDH.Visibility = Visibility.Hidden;
            txtGH.Visibility = Visibility.Hidden;
            imghau.Visibility = Visibility.Hidden;
            imgonline.Visibility = Visibility.Hidden;
            btnUpadateTT.Visibility = Visibility.Hidden;
            btnttct.Visibility = Visibility.Hidden;
            btnDX.Visibility = Visibility.Hidden;
            txtThongTinNguoiDung.Text = "        Quảng Cáo       ";
            txtThongTinNguoiDung.VerticalAlignment = VerticalAlignment.Center;
            //ĐƠN HÀNG
            
     
            tabgioithieu.Visibility = Visibility.Hidden;//lúc chưa đăng nhập thì cho ẩn don hang đi
            gtDonHang.Visibility = Visibility.Hidden;
            btnDXad.Visibility = Visibility.Hidden;//mới vào cho đăng xuất admin ẩn
         

        }

        private void RunTime_Clock(object sender, EventArgs e)
        {
            txtdh.Text = DateTime.Now.ToString();         //hàm lấy date now
        }
        // Xử Lí Chưc năng đăng nhập
        string Loged = "";
        void Share(string t)
        {
       
            Loged = t;
            var User = (from n in p.taikhoan
                        where n.TenDN == Loged
                        select n).FirstOrDefault();

            if (User != null)
            {
               
                if (User.MaLoaiTK == 0)//Kiểm tra nếu quyền =0 thì đăng nhập là theo quyền
                {
                    UpdateTTCN ud = new UpdateTTCN();
                    ttcn.txtVaiTro.Text ="Khách Hàng";
                    ttcn.txtName.Text = User.HoTen.ToString();
                    ttcn.txtEmail.Text = User.Email.ToString();
                    ttcn.txtNS.Text = User.DOB.ToString();
                    ttcn.txtSDT.Text = User.SDT.ToString();
                   
                    //lúc chạy window thì chạy mặc đinh là trang chủ
                    TrangChu sp = new TrangChu();
                    txtit.Text = "Trang Chủ";
                    gridtab.Children.Clear();
                    sp.txtTrangChuMatk.Text = MaTK.Text;
                    gridtab.Children.Add(sp);
                    //
                    //Xử lí trên trang chủ.
                    txtGH.Visibility = Visibility.Visible;
                    btnDH.Visibility = Visibility.Visible;
                    btnDN.Visibility = Visibility.Hidden;
                    btndk.Visibility = Visibility.Hidden;
                    imghau.Visibility = Visibility.Visible;
                    imgonline.Visibility = Visibility.Visible;
                    imghdd.Visibility = Visibility.Hidden;
                    btnttct.Visibility = Visibility.Visible;
                    btnUpadateTT.Visibility = Visibility.Visible;
                    btnDX.Visibility = Visibility.Visible;
                    imgquangcao.Visibility = Visibility.Hidden;
                    imgquangcao1.Visibility = Visibility.Hidden;
                    txtTenDN.Text = User.HoTen;
                    txtMavt.Text = User.MaLoaiTK.ToString();
                    MaTK.Text = User.MaTK.ToString();
                    txtvaitro.Text = "(Khách Hàng)";
                    txtThongTinNguoiDung.Text = "Thông Tin Người Dùng";
                    sharema?.Invoke(User.MaTK);
                    mataikhoan = User.MaTK;
                    sp.Matk = User.MaTK;
                    ud.matk = User.MaTK;
                    ctsp.TempMKH = User.MaTK;
                    SanPham s = new SanPham();
                   
                    String stringPath = User.Hinh.ToString();
                    if (File.Exists(stringPath))//hàm sử lí hình ảnh
                    {
                        Uri imageUri = new Uri(stringPath, UriKind.Absolute);     
                        imghau.Source = new BitmapImage(imageUri);
                    }
                    else
                    {
                        Uri imageUri = new Uri(@"E:\khoa học tự nhiên\LTUDQL2\WPF_DOAN\SHOP\SHOP\img\nguoid.png", UriKind.Absolute);    
                        imghau.Source = new BitmapImage(imageUri);
                    }
                }
                else// ngược lại thì vào trang admin
                {

                    //stackmain.Children.Clear();
                    mai.Visibility = Visibility.Collapsed;
                    btnDXad.Visibility = Visibility.Visible;
                    AD f = new AD();
                    f.Width = 1380;
                    f.Height = 788;
                    //stackmain.Width = 1500;
                    //stackmain.Height = 788;
                    stackmain.Children.Add(f);

                }
            }
            else {
                return;
            }
          
        }



        private void wd_Loaded(object sender, RoutedEventArgs e)
        {
            login.share += new DagNhap.PassData(Share);//chạy hàm đăng nhập

            TrangChu sp = new TrangChu();
            gridtab.Children.Clear();
            txtit.Text = "Trang Chủ";
            tabcontrol.SelectedIndex = 0;
            sp.txtTrangChuMatk.Text = MaTK.Text;
            gridtab.Children.Add(sp);
        }
        private void btnDN_Click(object sender, RoutedEventArgs e)
        {
            login.Show();
        }
        private void btnDX_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow m = new MainWindow();
            m.Show();
        }
        //xử lí đăng nhâp


        //gọi các Usercontrol
        public void btnTC_Click(object sender, RoutedEventArgs e)
        {
     
            TrangChu sp = new TrangChu();
            gridtab.Children.Clear();
            txtit.Text = "Trang Chủ";
            if(MaTK.Text =="")
            {
                sp.Matk = 0;
            }
            else {
                sp.Matk = int.Parse(MaTK.Text.ToString());
            }
            
            tabcontrol.SelectedIndex = 0;
            sp.txtTrangChuMatk.Text = MaTK.Text;
            gridtab.Children.Add(sp);
        }
        public void btnSP_Click(object sender, RoutedEventArgs e)
        {
            txtit.Text = "Sản Phẩm";
            sp.tempSP.Text= MaTK.Text;//gán chổ này để truyền qua usercontrol
            gridtab.Children.Clear();
            sp.txtMaTKSP.Text= MaTK.Text;
            tabcontrol.SelectedIndex = 0;
            gridtab.Children.Add(sp);
        }
        private void btnTK_Click(object sender, RoutedEventArgs e)
        {
            TiemKiem tk = new TiemKiem();
            txtit.Text = "Tiếm Kiếm SP";
            tabcontrol.SelectedIndex = 0;
            gridtab.Children.Add(tk);
        }
       
        private void btnDH_Click(object sender, RoutedEventArgs e)
        {
            GioHang a = new GioHang();
         
            a.tempMTKgiohang.Text=MaTK.Text ;
            a.ma1 = int.Parse(MaTK.Text);
            txtit.Text ="Đơn Hàng";
            gridtab.Children.Add(a); 

        }
        private void btnttct_Click(object sender, RoutedEventArgs e)
        {

            ThongTinCaNhan ttt = new ThongTinCaNhan();
            try
            {
                int ma = int.Parse(MaTK.Text);
                txtit.Text = "TT Cá Nhân";
                var sql = (from tt in p.taikhoan
                           where tt.MaTK == ma
                           select tt).FirstOrDefault();
                ttt.txtName.Text = sql.HoTen;
                ttt.txtDC.Text = sql.DiaChi;
                ttt.txtNS.Text = sql.DOB;
                ttt.txtEmail.Text = sql.Email;
                ttt.txtSDT.Text = sql.SDT.ToString();
                String stringPath = sql.Hinh;
                if (File.Exists(stringPath))//hàm sử lí hình ảnh
                {
                    Uri imageUri = new Uri(stringPath, UriKind.Absolute);
                    ttt.imgHinh.Source = new BitmapImage(imageUri);
                }
                else
                {
                    Uri imageUri = new Uri(@"/SHOP;component/img/p2.png", UriKind.Absolute);
                    ttt.imgHinh.Source = new BitmapImage(imageUri);
                }
                tabcontrol.SelectedIndex = 0;
                gridtab.Children.Add(ttt);
            }
            catch
            {
                MessageBox.Show("Trang Này đang hiện Hành");
            }
        }
        private void btnUpadateTT_Click(object sender, RoutedEventArgs e)
        {
          
            UpdateTTCN t2 = new UpdateTTCN();
            try
            {
                int ma = int.Parse(MaTK.Text);
                txtit.Text = "TT Cá Nhân";
                var sql = (from tt in p.taikhoan
                           where tt.MaTK == ma
                           select tt).FirstOrDefault();
                t2.txtName.Text = sql.HoTen;
                t2.txtDC.Text = sql.DiaChi;
                t2.txtNS.Text = sql.DOB;
                t2.txtEmail.Text = sql.Email;
                t2.txtSDT.Text = sql.SDT.ToString();
                t2.matk = sql.MaTK;
                String stringPath =sql.Hinh;
                if (File.Exists(stringPath))//hàm sử lí hình ảnh
                {
                    Uri imageUri = new Uri(stringPath, UriKind.Absolute);
                    t2.imgHinh.Source = new BitmapImage(imageUri);
                }
                else
                {
                    Uri imageUri = new Uri(@"/SHOP;component/img/p1.png", UriKind.Absolute);
                    t2.imgHinh.Source = new BitmapImage(imageUri);
                }
                tabcontrol.SelectedIndex = 0;
                gridtab.Children.Add(t2);
            }
            catch
            {
                MessageBox.Show("Trang Này đang hiện Hành");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //sự kiện để xóa tabitem dấu x
            tabgioithieu.Visibility = Visibility.Hidden;
            gtDonHang.Visibility = Visibility.Hidden;
            tabcontrol.SelectedIndex = 0;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //Đăng Xuất trang AD
        private void btnDXad_Click(object sender, RoutedEventArgs e)
        {

            //btnDXad.Visibility = Visibility.Hidden;
            //wd.Loaded += wd_Loaded;
            //mai.Visibility = Visibility.Visible;
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
            
        }

        private void btndk_Click(object sender, RoutedEventArgs e)
        {
            DangKy dk = new DangKy();
            tabcontrol.SelectedIndex = 0;
            gridtab.Children.Add(dk);
        }
    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
                    (
                        "Exit",
                        "Exit",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                        {
                            new KeyGesture(Key.F4, ModifierKeys.Alt)
                        }
                    );

    }
}
