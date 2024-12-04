using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP.BUS
{
    public class CatStatistic : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public decimal Incomes
        {
            get
            {
                return incomes;
            }

            set
            {
                incomes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Incomes"));
            }
        }

        decimal incomes;
    }
}
