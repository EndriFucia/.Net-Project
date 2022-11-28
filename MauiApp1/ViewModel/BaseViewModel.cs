using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IData DataStore => DependencyService.Get<IData>();
        Boolean isBussy;
        public Boolean IsBusy
        {
            get => isBussy;
            set
            {
                if(isBussy == value)
                    return;

                isBussy = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
