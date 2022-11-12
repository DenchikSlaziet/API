using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static readonly IList<Car> Cars = new List<Car>();

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return Cars;
        }


        [HttpPost]
        public Car Add(CarRequestModel model)
        {
            model.Proverka();
            var car = new Car
            {
                Id = Guid.NewGuid(),
                AvgFuelForHour = model.AvgFuelForHour,
                Fuel = model.Fuel,
                GosNumber = model.GosNumber,
                Mark = model.Mark,
                PriseRent = model.PriseRent,
                Probeg = model.Probeg,
                PowerReserve = model.Fuel / model.AvgFuelForHour,
                RentalAmount = Math.Round((model.Fuel / model.AvgFuelForHour * (model.PriseRent * 60)), 2)
            };
            Cars.Add(car);
            return car;
        }


        [HttpDelete("{id:guid}")]
        public bool DeleteUser(Guid id)
        {
            var taggetcar = Cars.FirstOrDefault(x => x.Id == id);
            if (taggetcar != null)
            {
                return Cars.Remove(taggetcar);
            }
            return false;
        }


        [HttpPut("{id:guid}")]
        public Car Update([FromRoute] Guid id, [FromBody] CarRequestModel model)
        {
            var targetcar = Cars.FirstOrDefault(x => x.Id == id);
            if (targetcar != null)
            {
                model.Proverka();
                targetcar.AvgFuelForHour = model.AvgFuelForHour;
                targetcar.Fuel = model.Fuel;
                targetcar.GosNumber = model.GosNumber;
                targetcar.Mark = model.Mark;
                targetcar.PriseRent = model.PriseRent;
                targetcar.Probeg = model.Probeg;
                targetcar.PowerReserve = model.Fuel / model.AvgFuelForHour;
                targetcar.RentalAmount = Math.Round(model.Fuel / model.AvgFuelForHour * (model.PriseRent * 60), 2);
            }
            return targetcar;
        }


        [HttpGet("Statistics")]
        public StatisticsCar GetStats()
        {
            var result = new StatisticsCar()
            {
                CountAll = Cars.Count,
                CountCriticalMove = Cars.Where(x => x.PowerReserve < 7).Count()
            };

            return result;
        }
    }
}
