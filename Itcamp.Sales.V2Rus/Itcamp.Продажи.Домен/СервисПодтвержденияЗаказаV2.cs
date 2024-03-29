﻿namespace Itcamp.Продажи.Домен
{
    public class СервисПодтвержденияЗаказаV2
    {
        private readonly IРепозиторийЗаказов _репозиторийЗаказов;
        private readonly КалькуляторСкидки _калькуляторСкидки;
        public СервисПодтвержденияЗаказаV2(IРепозиторийЗаказов репозиторийЗаказов, КалькуляторСкидки калькуляторСкидки)
        {
            _репозиторийЗаказов = репозиторийЗаказов;
            _калькуляторСкидки = калькуляторСкидки;
        }

        public void Подтвердить(long кодЗаказа)
        {
            var заказ = _репозиторийЗаказов.ПолучитьЗаказ(кодЗаказа);
            var скидка = _калькуляторСкидки.РассчитатьСкидку(заказ.КодКлиента);
            заказ.ПрименитьСкидку(скидка);
            заказ.Статус = СтатусЗаказа.ОжидаетОплаты;
            _репозиторийЗаказов.СохранитьЗаказ(заказ);
        }
    }
}