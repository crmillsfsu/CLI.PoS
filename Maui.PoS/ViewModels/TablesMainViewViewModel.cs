using Library.PoS.Model;
using Library.PoS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Maui.PoS.ViewModels
{
    public class TablesMainViewViewModel :INotifyPropertyChanged
    {
        public ObservableCollection<Table> Tables
        {
            get
            {
                return new ObservableCollection<Table>(TableServiceProxy.Current.Tables);
            }
        }

        public Table? SelectedTable { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Delete()
        {
            if (SelectedTable == null)
            {
                return;
            }
            TableServiceProxy.Current.Delete(SelectedTable?.Id ?? 0);
            NotifyPropertyChanged("Tables");
        }
        public void Refresh()
        {
            NotifyPropertyChanged("Tables");

        }
    }
}
