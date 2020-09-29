using CV19.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CV19.Infrastructure.Commands.Base;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        // создаем свойства для тестирования ViewModel
        #region Заголовок окна
        private string _Title = "Анализ статистики CV19"; // для тестов захардкодим значение

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => _Title;
            //set
            //{
            //    //if(Equals(_title, value)) return;
            //    //_title = value;
            //    //OnPropertyChanged();

            //    // Поскольку у нас в базовом классе есть метод Set()
            //    // то мы можем сократить запись:
            //    Set(ref _title, value);

            //}

            // Либо вообще сокращаем до одной строки:
            set => Set(ref _Title, value);
        }
        #endregion

        #region Status - Статус программы
        /// <summary>
        /// Статус программы
        /// </summary>
        private string _Status ="Готов";
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
        #endregion

        // описываем главную команду (наделяем её функционалом) - закрытие приложения
        // нужен ctor и region с описаним комманд

        #region Команды

        #region CloseApplicationCommand

        // создаём свойство с типом ICommand
        public ICommand ClosrAppkicationCommand { get; }
        // теперь создаём два метода для команды
        private void OnClosrAppkicationCommandExecuted(object p)
        {
            // Само действие команды (То что команда делает)
            Application.Current.Shutdown();
        }

        private bool CanClosrAppkicationCommandExecute(object p) => true;

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды
            // создаём значения комманд
            ClosrAppkicationCommand = new LambdaCommand(OnClosrAppkicationCommandExecuted, CanClosrAppkicationCommandExecute);
            

            #endregion    
        }
    }
}
