using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CV19.ViewModels.Base
{
    /// <summary>
    /// Базовый класс ViewModel, универсальный для проектов MVVM
    /// </summary>
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        // В метод передаём свойство (из любого класса) и гененрируем внутри событие (обновления)
        // нужно чтобы не городить обновление свойств в каждом окне (или в каждом свойстве)
        protected virtual void OnPropertyChanged([CallerMemberName]string PropertyName = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        // Метод обновляет значение свойства для которого определенно поле.
        // передаём в это свойство новые значения
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null) // предотвращаем обновление кольцевых свойств
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
