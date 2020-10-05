using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using WpfApp3;

namespace WpfApp3
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Phone selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }
        private RelayCommand _addCommand;
        private RelayCommand _delCommand;
        private RelayCommand _copyCommand;

        public RelayCommand AddCommand 
        {
            get 
            {
                return _addCommand ?? (_addCommand= new RelayCommand(obj => 
                {
                    Phone phone = new Phone();
                    Phones.Insert(Phones.Count,phone);
                    SelectedPhone = phone;
                }, (obj) => Phones.Count<10 ));;            
            }                      
        }

        public RelayCommand DelCommand 
        {
            get 
            {
                return _delCommand ?? (_delCommand = new RelayCommand(obj =>
                {
                    Phone phone = obj as Phone;
                    if (phone != null)
                    {
                        Phones.Remove(phone);
                    }
                    
                }, (obj) => Phones.Count > 0));
            }
        }

      
        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<Phone>
                {
                    new Phone {Title="Phone 1", Company="Company 1", Price = 10000 },
                    new Phone {Title="Phone 2", Company="Company 2", Price = 20000 },
                };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}