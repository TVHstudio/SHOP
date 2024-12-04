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
using SHOP.DAL;

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for SPCungLoai.xaml
    /// </summary>
    public partial class SPCungLoai : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        public SPCungLoai()
        {
            InitializeComponent();
            loadSP();
        }
        private void loadSP()
        {
            
            var data = (from d in p.sanpham
                        where d.MaLoaiSP==2
                       select d).Take(5);
                stpanel.ItemsSource = data.ToList();
            
            // stpanel.ItemsSource = p.SanPham.ToList();
            //  stpanel.SelectedValuePath = "MaSP";
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DH cn = new DH();

            //lấy dữ liệu trong datacontex
            Button a = sender as Button;
            sanpham datact = a.DataContext as sanpham;

            // var s = datact as SanPham;
            cn.txtname.Text = datact.TenSP.ToString();
            cn.txtid.Text = datact.MaSP.ToString();
            cn.txtmota.Text = datact.MoTa.ToString();
            cn.txtname.Text = datact.TenSP.ToString();
            cn.txtgia.Text = datact.GiaSP.ToString();
            String stringPath = datact.Hinh.ToString();

            if (File.Exists(stringPath))
            {

                Uri imageUri = new Uri(stringPath, UriKind.Absolute);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                cn.hinh.Source = new BitmapImage(imageUri);
            }
            else
            {
                Uri imageUri = new Uri(@"E:\PHONE\PHONE\image\iphone7plus.jpg", UriKind.Absolute);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                cn.hinh.Source = new BitmapImage(imageUri);
            }
            cn.Show();
        }

        //lích chuột phải chon đặt hàngh
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            DH cn = new DH();
            // SanPham sp = new SanPham();
            if (stpanel.SelectedIndex > -1)
            {
                string sx = stpanel.SelectedItem.ToString();
                var a = stpanel.SelectedItem;
                //String json = Newtonsoft.Json.JsonConvert.SerializeObject(o);    

                sanpham sp = (sanpham)stpanel.SelectedItem;
                //  var a = stpanel.SelectedItem;
                //Newtonsoft.Json.JsonConvert.DeserializeObject<SanPham>(stpanel.SelectedItem.ToString());

                cn.Focus();
                cn.txtid.Text = sp.MaSP.ToString();
                cn.txtname.Text = sp.TenSP.ToString();
                cn.txtgia.Text = sp.GiaSP.ToString();
                cn.txtmota.Text = sp.MoTa.ToString();
                String stringPath = sp.Hinh;

                if (File.Exists(stringPath))
                {

                    Uri imageUri = new Uri(stringPath, UriKind.Absolute);
                    BitmapImage imageBitmap = new BitmapImage(imageUri);
                    cn.hinh.Source = new BitmapImage(imageUri);
                }
                else
                {
                    Uri imageUri = new Uri(@"E:\PHONE\PHONE\image\iphone7plus.jpg", UriKind.Absolute);
                    BitmapImage imageBitmap = new BitmapImage(imageUri);
                    cn.hinh.Source = new BitmapImage(imageUri);
                }
                cn.Show();

            }
        }
        private void MenuItem_refesh(object sender, RoutedEventArgs e)
        {
            loadSP();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadSP();
        }
    }
}
