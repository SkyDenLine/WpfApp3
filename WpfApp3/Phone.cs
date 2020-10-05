using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfApp3
{
    public class Phone : INotifyPropertyChanged
    {
        private string _title;
        private string _company;
        private int _price;
        private string _description;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Company
        {
            get { return _company; }
            set
            {
                _company = value;
                OnPropertyChanged("Company");
            }
        }
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public string Description
        {
            get 
            {
                return _description ;
            }
            set 
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged( string prop = "")
        {           
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
