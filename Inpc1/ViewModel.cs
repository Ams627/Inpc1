using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace Inpc1
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (s, e) =>
            {
                MyText += 'A';
            };
            timer.Start();
        }
        private string _myText;
        public string MyText
        {   get
            {
                return _myText;
            }
            set
            {
                _myText = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
