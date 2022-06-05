using DhaoCarSell.Data;
using DhaoCarSell.Models;
using DhaoCarSell.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DhaoCarSell.Controllers
{
    public class CarController : Controller, ICarData
    {
        private readonly DataContext _dataContext;
        private Car _car;
        private List<Car> _carList;
        private readonly CarData _carData;

        public CarController()
        {
            _dataContext = new DataContext();
            _car = new Car();
            _carList = new List<Car>();
            _carData = new CarData();
        }

        public IActionResult Index()
        {
            _carList = _carData.GetCars();

            return View(_carList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
     
        public IActionResult OnCreate(Car car)
        {
            using (_dataContext)
            {
                if (!ModelState.IsValid)
                {
                    _dataContext.Car.Add(car);
                    int result = _dataContext.SaveChanges();
                }
            }
            ModelState.Clear();

            return View("Create");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            using (_dataContext)
            {
                _car = _dataContext.Car.Where(x => x.Id == id).FirstOrDefault();
            }               
            return View(_car);
        }

        [Authorize(Roles="Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            _car = _dataContext.Car.FirstOrDefault(c => c.Id == id);
            _dataContext.Remove(_car);
            _dataContext.SaveChanges();

            return View("Delete");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            using (_dataContext)
            {
                _car = _dataContext.Car.Where(i => i.Id == id).FirstOrDefault();
            }    
            return View(_car);
        }
       
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Car car)
        {
            using (_dataContext)
            {
                _dataContext.Update(car);
                _dataContext.SaveChanges();
            }           
            ModelState.Clear();

            return View();
        }
    }
}
