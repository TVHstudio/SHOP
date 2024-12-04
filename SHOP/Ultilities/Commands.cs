using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOP.BUS;

namespace SHOP.Ultilities
{
    class Commands
    {
        public static BTHome BTHome { get; }
        static Commands()
        {
            BTHome = new BTHome();
        }
    }
}
