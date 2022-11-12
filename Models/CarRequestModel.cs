namespace API.Models
{
    public class CarRequestModel
    {
        /// <summary>
        /// Гос.Номер
        /// </summary>
        public string GosNumber { get; set; }
        /// <summary>
        /// Машина
        /// </summary>
        public MarkCars Mark { get; set; }
        /// <summary>
        /// Пробег
        /// </summary>
        public decimal Probeg { get; set; }

        /// <summary>
        /// Среднее потребление топлива за час
        /// </summary>
        public decimal AvgFuelForHour { get; set; }
        /// <summary>
        /// Текущий объем топлива
        /// </summary>
        public decimal Fuel { get; set; }
        /// <summary>
        /// Стоимость аренды (за минуту)
        /// </summary>
        public decimal PriseRent { get; set; }


        public void Proverka()
        {
            Random rnd = new Random();
            if(Probeg < 0 || Probeg > 5000)
            {
                Probeg = rnd.Next(0,5000);
            }

            if(Fuel < 0 || Fuel > 20)
            {
                Fuel = rnd.Next(0, 20);
            }

            if((int)Mark > 2 || (int)Mark < 0)
            {
                Mark = MarkCars.HyundaiCreta;
            }

            if (AvgFuelForHour < 0 || AvgFuelForHour > 7)
            {
                AvgFuelForHour = rnd.Next(0, 7);
            }

            if (PriseRent < 0)
            {
                PriseRent = rnd.Next(0, 1000000);
            }
        }
    }
}
