//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Anneme_Holzhausen_ST10144453_Prog_POE.Core
{
    // INotifyPropertyChanged: notify clients, typically binding clients, that a property value has changed.
    internal class ObservableObjectClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//