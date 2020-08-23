using CV19.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
