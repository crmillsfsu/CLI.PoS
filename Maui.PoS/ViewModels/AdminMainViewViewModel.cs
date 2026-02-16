using CLI.PoS.Model;
using Library.PoS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Maui.PoS.ViewModels
{
    public class AdminMainViewViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Item> Items
        {
            get
            {
                return new ObservableCollection<Item>(ItemServiceProxy.Current.Items);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Refresh()
        {
            NotifyPropertyChanged("Items");
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
