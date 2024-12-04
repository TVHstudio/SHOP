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
using Microsoft.Office.Interop.Excel;
using SHOP.DAL;

namespace SHOP.GUI
{
    /// <summary>
    /// Interaction logic for LSNguoiDung.xaml
    /// </summary>
    public partial class LSNguoiDung : System.Windows.Window
    {
        ShopEntities1 p = new ShopEntities1();
        public int TempMatk { get; set; }
        public LSNguoiDung()
        {
            InitializeComponent();
        }
        void load()
        {

            var sql = from i in p.DonHang1
                      where i.MaKH == TempMatk
                      select i;
            gridDSSP1.ItemsSource = sql.ToList();
        }
        private void excel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            //đổ dữ lieuj vào sheet
            sheet1.Cells[5, 6] = "LỊCH SỬ NGƯỜI DÙNG";
            sheet1.Cells[7, 5] = "Mã ĐH:  " + txtMaKH.Text;
            sheet1.Cells[7, 8] = "Tên KH:  " + txtTenKH.Text;

            for (int j = 1; j < gridDSSP1.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[10, j + 3];
                sheet1.Cells[10, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = gridDSSP1.Columns[j].Header;
            }
            for (int i = 1; i < gridDSSP1.Columns.Count; i++)
            {
                for (int j = 0; j < gridDSSP1.Items.Count; j++)
                {
                    TextBlock b = gridDSSP1.Columns[i].GetCellContent(gridDSSP1.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 12, i + 3];
                    myRange.Value2 = b.Text;
                }

            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            load();
        }
    }
}
