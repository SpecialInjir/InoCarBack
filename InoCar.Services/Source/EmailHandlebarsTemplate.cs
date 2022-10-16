using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services
{
    public class EmailHandlebarsTemplate
    {
       public const string CarCharacteristicsTemplate =
        @"
       <span>
          Марка: {{Mark}} <br>
          Модель: {{Model}} <br>
          Гос.номер: {{StateNumber}} <br>
          Тип двигателя: {{EngineType}}<br>
          Привод:{{Drive}}<br>
          Трансмиссия: {{Transmission}}<br>
          Пробег:{{Mileage}}<br>
          Год выпуска:{{Year}}<br>
          Отправлено из сервиса InoCar
       </span>";



    }
}
