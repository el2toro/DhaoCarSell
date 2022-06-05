using System.ComponentModel.DataAnnotations;

namespace DhaoCarSell.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:MMMM-yyyy}")]
        public DateTime Year { get; set; }
        public int Power { get; set; }
        public int CmCube { get; set; }
        public int Km { get; set; }
        public FuelType Fuel { get; set; }
        public BodyType Body { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public Contact Contact { get; set; }
        public enum FuelType
        {
            Gasoline,
            Diesel,
            Electric,
            Gas,
            Hybrid
        }

        public enum BodyType
        {
            SUV,
            Sedan,
            Coupe,
            Sport,
            MiniVan,
            HatchBack,
            StationWagon,
            PickUp
        }

    }

}
