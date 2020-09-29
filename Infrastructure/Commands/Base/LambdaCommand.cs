using CV19.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CV19.Infrastructure.Commands
{
    internal class LambdaCommand: Command
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        // получаем в конструкторе два делегата, т.е. указываем два действия, которые команда может выполнять
        // два парамтра, которые пришли из конструктора можно сохранить в приватные поля
        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute=null) 
        {
            // эти переменные создаются автоматически при добавлении приватных полей
            //execute = Execute;
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute)); // дополнительная проверка - ругаемся, если не передали ссылку на делегат
            canExecute = CanExecute;
        }

        // Использование делегатов из конструктора (execute, canExecute)
        //public override bool CanExecute(object parameter) => throw new NotImplementedException();
        public override void Execute(object parameter) => execute(parameter);
        //public override bool CanExecute(object parameter) => throw new NotImplementedException();
        public override bool CanExecute(object parameter) => canExecute?.Invoke(parameter)?? true;

    }
}
