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
    internal class MenuItemMainViewViewModel
    {
        public ObservableCollection<Item> Items
        {
            get
            {
                return new ObservableCollection<Item>(ItemServiceProxy.Current.Items);
            }
        }

        public Item? SelectedItem { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Delete()
        {
            ItemServiceProxy.Current.Delete(SelectedItem);
            Refresh();
        }
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
