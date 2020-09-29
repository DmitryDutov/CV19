using CV19.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CV19.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command

    {
        // создали вариант команды в отдельном классе
        // для испоьзования таких команд нужно добавить xmlns во View
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
