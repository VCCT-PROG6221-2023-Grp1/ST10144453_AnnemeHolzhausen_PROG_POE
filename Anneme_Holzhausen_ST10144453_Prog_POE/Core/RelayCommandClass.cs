//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Anneme_Holzhausen_ST10144453_Prog_POE.Core
{
    internal class RelayCommandClass : ICommand
    {
        //The underscores are there to be used instead of "this." (Learned something new here!)
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        //------------------------------------------EventHandler event Method------------------------------------------//
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        //------------------------------------------Default Constructor------------------------------------------//
        public RelayCommandClass(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        //------------------------------------------CanExecute Method------------------------------------------//
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
        //------------------------------------------Execute Method------------------------------------------//
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//