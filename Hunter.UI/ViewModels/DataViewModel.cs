using Quacker_Hunter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter.UI.ViewModels
{
    public class DataViewModel:ViewModelBase
    {
        private ObservableCollection<ProfileViewModel> _records;
        public ObservableCollection<ProfileViewModel> Records
        {
            get => _records;
            set
            {
                _records = value;
                OnPropertyChanged("Records");
            }
        }
    }
}
