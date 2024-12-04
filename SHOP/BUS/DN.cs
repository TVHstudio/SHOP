using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOP.DAL;

namespace SHOP.BUS
{
    
    class DN
    {
        ShopEntities1 p = new ShopEntities1();
        public bool login(string id, string pass)
        {
            try
            {
                var nd = from n in p.taikhoan
                         where (n.TenDN == id &&
                               n.MatKhau == pass)
                         select n;
                         

                //quyenNguoiDung = nd.Select(x => x.MaQuyenNV).Single();
                //tenNguoiDung = nd.Select(x => x.TenNV).Single();
                //chucvuNguoiDung = nd.Select(x => x.TenChucVuNV).Single();
                //MaNVNguoiDung = nd.Select(x => x.MaNV).Single();
                //tenQuyenNguoiDung = nd.Select(x => x.TenQuyenNV).Single();
                //maNguoiDung = nd.Select(x => x.MaNguoiDung).Single().ToString();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
