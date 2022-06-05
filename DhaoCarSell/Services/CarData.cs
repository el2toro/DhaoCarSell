using DhaoCarSell.Data;
using DhaoCarSell.Models;
using Microsoft.EntityFrameworkCore;

namespace DhaoCarSell.Services
{
    public class CarData
    {
        public List<Car> GetCars()
        {
            using(var context = new DataContext())
            {
              return  context.Car.Include(c => c.Contact).ToList();
            }
        }

        public Car GetCarById(int id)
        {

            using(var context = new DataContext())
            {
              return  context.Car.Include(c => c.Contact)
                    .Where(car => car.Id == id).FirstOrDefault();
            }          
            
        }
    }
}
