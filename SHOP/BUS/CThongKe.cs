using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SHOP.DAL;

namespace SHOP.BUS
{
    class CThongKe
    {
        public ICollectionView listTheLoai_SoLuong { get; set; }


        ShopEntities1 p = new ShopEntities1();
        public CThongKe()
        {
           
            loadReportTheLoai();
            
        }
        public void loadReportTheLoai()
        {
            var sp = (from n in p.sanpham
                          join t in p.loaisanpham
                          on n.MaLoaiSP equals t.MaLoaiSP
                          group n by t.TenLoaiSP into g
                          select new
                          {
                              g.Key,
                              ten = g.Key,
                              soluong = g.Sum(x => x.SoLuongBan)
                          }).ToList();

            /*DbCommand dc = db.GetCommand(sach);
            Console.WriteLine(dc.CommandText);*/

            listTheLoai_SoLuong = CollectionViewSource.GetDefaultView(sp);
        }
    }
}
