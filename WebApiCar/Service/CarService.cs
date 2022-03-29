using System.Text.RegularExpressions;
using WebApiCar.Models;
using System.Drawing;

namespace WebApiCar.Service
{
    public class CarService : ICarService
    {
        private List<Car> _cars { get; }
        private List<string> _carNames = new();
        public CarService() => _cars = new List<Car>();

        public void ConverToCars ()
        {
            for (int i = 0; i < _carNames.Count; i++)
            {
                _carNames[i] = Regex.Replace(_carNames[i],@"[^0-9a-zA-Z:,.]+","");
                
            }
            _carNames.RemoveAll(x => string.IsNullOrEmpty(x));

            for (int i = 0; i < _carNames.Count; i+=7)
            {               
               _cars.Add(new Car { NameCar = _carNames[i],Color = _carNames[i+1],Manufacturer = _carNames[i + 2],DateCreate = DateTime.Parse(_carNames[i + 5]),Engine = _carNames[i + 5] });  
            }
        }

        

        public List<Car> GetCars ()
        {
            return _cars;
        }

        public void Upload ( string path )
        {
            using StreamReader sr = new StreamReader(path);
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                _carNames.Add(line);
            }
        }
    }
}
