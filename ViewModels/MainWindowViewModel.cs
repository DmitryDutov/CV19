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
using CV19.Infrastructure.Commands;
using CV19.Models;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        //Создаём свойство для нумерации вкладок
        #region SelectedPagewIndex : int - Номер выборанной вкладки
        private int _selectedPagewIndex = 0;
        public int SelectedPagewIndex
        {
            get => _selectedPagewIndex;
            set => Set(ref _selectedPagewIndex, value);
        }
        #endregion

        #region TestDataPoints : IEnumerable - Тестовый набор данных для визуализации графиков
        //Создаём свойство, которое возвращает перечисление точек данных для графика
        private IEnumerable<DataPoint> _testDataPoints;
        public IEnumerable<DataPoint> TestDataPoints
        {
            get=>_testDataPoints; 
            set=>Set(ref _testDataPoints, value);
        }
        #endregion
        
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
        // Команды можно описывать как внутри ViewModel, так и внутри другого класса
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

        #region ChangeTabIndex
        public ICommand ChangeTabIndexCommand { get; }
        private bool CanChangeTabIndexCommandExecute(object p) => _selectedPagewIndex >= -0;

        private void OnChangeTabIndexCommandExecute(object p)
        {
            if (!(p is int count))return;
            SelectedPagewIndex += count;
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды
            // создаём значения комманд
            ClosrAppkicationCommand = new LambdaCommand(OnClosrAppkicationCommandExecuted, CanClosrAppkicationCommandExecute);
            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecute, CanChangeTabIndexCommandExecute);
            #endregion

            #region Данные для графика
            //создаём рисовалку линии (набили "БД" точек для графика)
            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint {Xvalue = x, Yvalue = y});
            }

            TestDataPoints = data_points;
            #endregion
        }

    }
}
