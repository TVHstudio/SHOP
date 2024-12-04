using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SHOP.GUI;
using System.Windows;
using System.Windows.Controls;
using SHOP.DAL;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.IO;

namespace SHOP.BUS
{
    class BTHome : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        ShopEntities1 p = new ShopEntities1();
        public void Execute(object parameter)
        {
            string s = "hau";
            MessageBox.Show(s);
            // var wd = new SanPham((int)Parameter);
            // MainWindow m = new MainWindow() ;
            // m.DataContext = parameter;
            //// new SanPham((int)e.Parameter);
            // TrangChu sp =new TrangChu();
            // sp.DataContext = parameter;
            // m.txtit.Text = "Trang Chủ";
            //// m.gridtab.Children.Clear();
            // m.gridtab.Children.Add(sp);
            // m.UpdateLayout();
            Button t = parameter as Button;
            
            sanpham data = t.DataContext as sanpham;
            int maHSX = int.Parse(data.MaHangSX.ToString());
            int Loai = int.Parse(data.MaLoaiSP.ToString());
            int so = int.Parse(data.SoLuotXem.ToString()) + 1;// mỗi lần xem sẽ tăng lên
           // slx.Text = so.ToString();
            int ID = data.MaSP;
            var sql = p.sanpham.Where(m => m.MaSP == ID).FirstOrDefault();
            sql.SoLuotXem = int.Parse(so.ToString());
            p.SaveChanges();//lưu thây đổi lượt xem
            var sql1 = p.HangSX.Where(m => m.MaHangSX == maHSX).FirstOrDefault();//lấy hãng ra so sánh
            var sql2 = p.loaisanpham.Where(m => m.MaLoaiSP == Loai).FirstOrDefault();//lây loai ra so sanh

            Chitiet ct = new Chitiet();

            //lấy dữ liệu trong datacontex
            Button a = parameter as Button;
            sanpham datact = a.DataContext as sanpham;
            ct.txtID.Text = datact.MaSP.ToString();
           // ct.txtMaTKCT.Text = txtMaTKSP.Text;
            // var s = datact as SanPham;
            ct.tbTenSP.Text = datact.TenSP.ToString();
            ct.tbGia.Text = datact.GiaSP.ToString();

            ct.tbSLX.Text = so.ToString();
            ct.tbSLB.Text = datact.SoLuongBan.ToString();
            ct.tbMoTa.Text = datact.MoTa.ToString();
            ct.tbXuatXu.Text = datact.XuatXu.ToString();

            string text = datact.ChiTiet.ToString();
            IList<string> lines = text.Split(new string[] { @"\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                ct.txtmotachitiet.Inlines.Add(line);
                ct.txtmotachitiet.Inlines.Add(new LineBreak());
            }
            ct.tbLoai.Text = sql2.TenLoaiSP;
            ct.tbNSX.Text = sql1.TenHangSX;
            String stringPath = datact.Hinh.ToString();

            if (File.Exists(stringPath))
            {

                Uri imageUri = new Uri(stringPath, UriKind.Absolute);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                ct.imghinh.Source = new BitmapImage(imageUri);
            }
            else
            {
                Uri imageUri = new Uri(@"E:\PHONE\PHONE\image\iphone7plus.jpg", UriKind.Absolute);//mặt định nếu khong có ảnh thì sẽ là ảnh này
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                ct.imghinh.Source = new BitmapImage(imageUri);
            }
            ct.Show();
        }
    }
}
