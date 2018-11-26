using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter.UI.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int _record;
        public int Record
        {
            get => _record;
            set
            {
                _record = value;
                OnPropertyChanged("Record");
            }
        }
    }
}
