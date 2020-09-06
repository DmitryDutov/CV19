using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CV19.Infrastructure.Commands.Base
{
    // Делаем метод абстрактным чтобы он стал универмальным
    //internal class Command : ICommand
    internal abstract class Command : ICommand
    {
        // Передаём управление событиями классу CommandManager
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        //public bool CanExecute(object parameter) => throw new NotImplementedException();
        //public void Execute(object parameter) => throw new NotImplementedException();
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);

    }
}
