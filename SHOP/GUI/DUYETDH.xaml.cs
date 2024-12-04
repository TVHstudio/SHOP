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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using SHOP.DAL;

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for DUYETDH.xaml
    /// </summary>
    public partial class DUYETDH : System.Windows.Window
    {
        ShopEntities1 p = new ShopEntities1();
        public int ma;
        public DUYETDH()
        {
            InitializeComponent();
            loaddonhang();
        }
        void loaddonhang()
        {
            var sql = from ds in p.DonHang1
                      where ds.MaKH == ma
                      select ds;
            gridDSSP1.ItemsSource = sql.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loaddonhang();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btntrue_Click(object sender, RoutedEventArgs e)
        {
            txtTinhTrang.Foreground = Brushes.Blue;
            txtTinhTrang.Text = "Đã Giao Hàng";
            var sql = (from sp in p.DONDATHANG
                       where sp.MaKH == ma
                       select sp).FirstOrDefault();
            sql.TinhTrangGiao = txttrue.Text;
            p.SaveChanges();
        }

        private void btnfalse_Click(object sender, RoutedEventArgs e)
        {
            txtTinhTrang.Foreground = Brushes.Red;
            txtTinhTrang.Text = "Chưa Giao Hàng";
            var sql = (from sp in p.DONDATHANG
                       where sp.MaKH == ma
                       select sp).FirstOrDefault();
            sql.TinhTrangGiao = txtfalse.Text;
            p.SaveChanges();
        }

        private void excel_Click(object sender, RoutedEventArgs e)
        {

            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            //đổ dữ lieuj vào sheet
            sheet1.Cells[5, 6] = "DANH SÁCH SẢN PHẨM CỦA ĐƠN HÀNG";
            sheet1.Cells[7, 5] = "Mã ĐH:  " + txtMaDH.Text;
            sheet1.Cells[7, 8] = "Tên KH:  " + txtTenKH.Text;
         
            for (int j = 1; j < gridDSSP1.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[10, j + 3];
                sheet1.Cells[10, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = gridDSSP1.Columns[j].Header;
            }
            for (int i = 0; i < gridDSSP1.Columns.Count; i++)
            {
                for (int j = 0; j < gridDSSP1.Items.Count; j++)
                {
                    TextBlock b = gridDSSP1.Columns[i].GetCellContent(gridDSSP1.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 12, i + 3];
                    myRange.Value2 = b.Text;
                }

            }

        }
    }
}
