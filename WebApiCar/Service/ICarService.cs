using WebApiCar.Models;

namespace WebApiCar.Service
{
    public interface ICarService
    {
        void Upload ( string path );
        List<Car> GetCars ();
        void ConverToCars ();
    }
}
