using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOP.DAL;

namespace SHOP.BUS
{
    public class Chart : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        int curCatID;

        public int CurCatID
        {
            get
            {
                return curCatID;
            }

            set
            {
                curCatID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurCatID"));
            }
        }

        public List<loaisanpham> Cats
        {
            get
            {
                return cats;
            }

            set
            {
                cats = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cats"));
            }
        }

        public List<int> Years
        {
            get
            {
                return years;
            }

            set
            {
                years = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Years"));
            }
        }

        public int Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Year"));
            }
        }

        public List<CatStatistic> CatStatistics
        {
            get
            {
                return catStatistics;
            }

            set
            {
                catStatistics = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CatStatistics"));
            }
        }

        List<loaisanpham> cats;
        List<int> years;
        int year;
        List<CatStatistic> catStatistics;

     
    }
}
