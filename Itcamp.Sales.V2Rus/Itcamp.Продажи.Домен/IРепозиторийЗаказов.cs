﻿using System.Linq;

namespace Itcamp.Продажи.Домен
{
    public interface IРепозиторийЗаказов
    {
        Заказ ПолучитьЗаказ(long код);
        void СохранитьЗаказ(Заказ заказ);
        IQueryable<Заказ> ПолучитьЗаказы();
        
        #region V2
        int ЗавершенныхЗаказовЗаТриГода(long customerId);
        #endregion
    }
}