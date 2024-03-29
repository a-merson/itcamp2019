﻿namespace Itcamp.Продажи.Домен
{
    public class КалькуляторСкидки
    {
        private readonly IРепозиторийЗаказов _репозиторийЗаказов;
        public КалькуляторСкидки(IРепозиторийЗаказов репозиторийЗаказов)
        {
            _репозиторийЗаказов = репозиторийЗаказов;
        }

        public decimal РассчитатьСкидку(long кодКлиента)
        {
            var завершенныхЗаказов = _репозиторийЗаказов.ЗавершенныхЗаказовЗаТриГода(кодКлиента);
            return СкидкаОтКоличества(завершенныхЗаказов);
        }

        private decimal СкидкаОтКоличества(int завершенныхЗаказов)
        {
            if (завершенныхЗаказов >= 5)
                return 30;
            else if (завершенныхЗаказов >= 3)
                return 20;
            else if (завершенныхЗаказов >= 1)
                return 10;
            else
                return 0;
        }
    }
}