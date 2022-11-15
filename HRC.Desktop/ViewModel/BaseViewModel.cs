using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace HRC.Desktop
{
    public class BaseViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private bool _isWorking;
        public bool IsWorking
        {
            get { return _isWorking; }
            set
            {
                if (_isWorking != value)
                {
                    _isWorking = value;
                    OnPropertyChanged("IsWorking");
                }
            }
        }

        protected static int LatestUserSelected;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public string Error
        {
            get { return string.Empty; }
        }

        public virtual string this[string columnName]
        {
            get { return string.Empty; }
        }
    }
}

