namespace MotoCross.Models
{
    public class СustomerServiceDto
    {
        //Таблица Услуги для таблицы Заказы (Какие услуги проводились для мотоцикла )
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
