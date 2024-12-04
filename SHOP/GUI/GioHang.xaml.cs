using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for GioHang.xaml
    /// </summary>
    public partial class GioHang : UserControl
    {
        ShopEntities1 p = new ShopEntities1();
        public int ma1=0;
        MainWindow main = new MainWindow();
        public GioHang()
        {
            InitializeComponent();
            loadDH();
           
            loadf();
            if (txtgia.Text != "")
            {
                loadtien();// định dang thành tiền việt
            }
        }
        // SỰ KIỆN ĐƠN HÀNG ĐAY

        public void loadDH()
        {
            var sql = from a in p.DonHang
                      where a.MaKH == ma1
                      select a;
            dtg.ItemsSource = sql.ToList();
        }
        public void loadtien()
        {
            txtgia.Text = string.Format("{0:0,0 VNĐ}", double.Parse(txtgia.Text));
        }
        private void dtg_CurrentCellChanged(object sender, EventArgs e)
        {
            // var index = dtg.Columns.Single(c => c.Header.ToString() == "TongTien").DisplayIndex;
        }

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            DH dh = new DH();
            // tao 1 ô textbox gán giá trị ở trong d
            DonHang b = new DonHang();
            DAL.DonHang a = dtg.SelectedItem as DAL.DonHang;//lấy dữ liệu trong datagrid
            int ID = a.STT;//lấy ID đơn hang
            int? Masp = a.MaSP;//lấy sản phẩm trong datagrid đem so sánh

            int soluong = int.Parse(a.SoLuong.ToString());
            txtt.Text = soluong.ToString();//binding ra txtbox này để tí lấy số lượng xử lí

            int tam = int.Parse(txtt.Text);
            //lấy ID của giá san phâm
            var sql1 = (from sp in p.sanpham
                        where sp.MaSP == Masp
                        select sp).FirstOrDefault();

            var sql = p.DonHang.Where(m => m.STT == ID).FirstOrDefault();
            if (sql1.SoLuongTon < a.SoLuong)
            {
                a.SoLuong = sql.SoLuong;
                MessageBox.Show("Sản Phẩm Này Hết rồi!");
                return;
            }
            else {
                sql.SoLuong = tam;// update số lượng vào csdl
                sql.TongTien = tam * sql1.GiaSP;// tính tổng ti

                p.SaveChanges();
                loadDH();
                loadf();
                loadtien();//load tiền khi tiến hành sữa
            }
           

        }
        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            int ID = (dtg.SelectedItem as DAL.DonHang).STT;
            // DonHang temp = new DonHang();
            var xoa = (from s in p.DonHang where s.STT == ID select s).SingleOrDefault();
            p.DonHang.Remove(xoa);
            p.SaveChanges();
            loadDH();
          
            loadf();
            if (txtgia.Text != "")
            {
                loadtien();// định dang thành tiền việt
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //var sql = (from s in p.DonHang
            //           select s).Count();
            //txtsogio.Text = sql.ToString();

        }
        //đếm số luowg sản phẩm
        public void loadf()
        {
            var sql1 = (from t in p.DonHang
                        where t.MaKH==ma1
                        select t.TongTien).Sum();
            txtgia.Text = sql1.ToString();
            txtTemtt.Text = sql1.ToString();
            //đếm số lượng trong giỏ
            var sql = (from s in p.DonHang
                       where s.MaKH == ma1
                       select s).Count();
            txtsogio.Text = sql.ToString();
           
                  
        }


        private DonHang1 LoopData(int STT)
        {
            var CT = new DonHang1();
            using (var BH = new ShopEntities1())
            {
                var GioHang = (from h in p.DonHang
                               where h.STT == STT && h.MaKH== ma1
                               select h);

                foreach (var Temp in GioHang)
                {
                    CT.MaKH = Temp.MaKH;                 
                    CT.MaDonHang = Temp.MaDonHang;
                    
                    CT.MaSP = Temp.MaSP;
                    CT.TenSP = Temp.TenSP;
                    CT.SoLuong = Temp.SoLuong;
                    CT.NgayLap = Temp.NgayLap;
                    CT.GiaBan = Temp.GiaBan;                 
                    CT.TongTien = Temp.TongTien;
                    CT.MaDonHang = Temp.MaKH;
                }
            }

            return CT;
        }

    

        private List<int> LaySTT()
        {
            using (var BH = new ShopEntities1())
            {
                return (from i in BH.DonHang
                        where i.MaKH==ma1
                        select i.STT).ToList();
            }
        }
        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {

           
            //đếm số lượng sản phẩm

            DONDATHANG g1 = new DONDATHANG();
            DAL.DonHang a = new DAL.DonHang();
               
                try {
                var slsp = (from s in p.DonHang
                            where s.MaKH == ma1
                            select s.SoLuong).Sum();
                var g = new DONDATHANG()
                {
                    MaKH = int.Parse(tempMTKgiohang.Text),
                    NgayDat = DateTime.Now,
                    TongSoLuong = slsp,
                    TongTien = int.Parse(txtTemtt.Text),
                    TinhTrangGiao = "false",
                    DaThanhToan = "false",
                };
                using (var ql = new ShopEntities1())
                {
                    int n = ql.DONDATHANG.Where(m => m.MaKH == g.MaKH).Count();
                    if (n > 0)
                    {
                        try
                        {
                            var n1 = ql.DONDATHANG.Where(m => m.MaKH == g.MaKH).FirstOrDefault();
                            n1.NgayDat = DateTime.Now;
                            n1.TongSoLuong = slsp;
                            if (txtTemtt.Text == "")
                            {
                                n1.TongTien = 0;
                            }
                            else
                            {

                                n1.TongTien = g.TongTien;
                            }

                            ql.SaveChanges();
                           
                            MessageBox.Show("thanh toán thành công!");
                           
                        }
                        catch
                        {
                            MessageBox.Show("thanh toán thất bại");
                        }

                    }
                    else
                    {

                        //thêm 
                        try
                        {

                            ql.DONDATHANG.Add(g);
                            if (ql.SaveChanges() > 0)
                            {

                          
                                MessageBox.Show("Đã thêm vào giỏ hàng của bạn");
                            }
                            else
                            {
                                MessageBox.Show("Chưa thêm được!");
                            }
                        }   
                        catch
                        {   
                            MessageBox.Show("thanh toán thất bại!");
                        }
                    }

                }
            }
            catch {
                MessageBox.Show("Giỏ Hàng Đang NULL!");
            }
            foreach (var i in LaySTT())
            {
                using (var BL = new ShopEntities1())
                {
                  
                    var ChiTiet = new DonHang1();
                    ChiTiet = LoopData(i);
                    BL.DonHang1.Add(ChiTiet);
                    BL.SaveChanges();//lưu thay doi
                                     //   UpdateSoLuongSP(LayMaSp(i));

                }

            }
            p.Database.ExecuteSqlCommand("TRUNCATE TABLE DonHang");
            ObservableCollection<DonHang> users = new ObservableCollection<DonHang>();
            dtg.ItemsSource = users;
            txtsogio.Text = "0";
            txtgia.Text = " 0 VNĐ";
            users.Clear();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<DonHang> users = new ObservableCollection<DonHang>();
            dtg.ItemsSource = users;
            users.Clear();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
          
            loadDH();
            loadf();
            if (txtgia.Text != "")
            {
                loadtien();
            }
        }
    }

}
