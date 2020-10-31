using System;

namespace CV19.Models
{
    //Модель данных заболеваемости
    internal struct ConfirmedCount
    {
        public DateTime Date { get; set; }

        public int Count { get; set; }
    }
}
