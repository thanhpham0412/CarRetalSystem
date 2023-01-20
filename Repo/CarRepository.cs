using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;

namespace Repo
{
    public class CarRepository : IRepository<Car>
    {
        public void deleteData(Car t)
        {
            CarDAO.Instance.deleteData(t);
        }

        public Car getById(string id)
        {
            return CarDAO.Instance.getById(id);
        }

        public List<Car> getData()
        {
            return CarDAO.Instance.getData();
        }

        public List<Car> getCarAvailableByDate(DateTime startDate, DateTime endDate)
        {
            List<Car> cars = new List<Car>();
            foreach (var car in CarDAO.Instance.getData())
            {
                if (CarRentalDAO.Instance.isAvailableByDate(car.CarId, startDate, endDate))
                {
                    cars.Add(car);
                }
            }
            return cars;
        }

        public void insertData(Car t)
        {
            CarDAO.Instance.insertData(t);
        }

        public void updateData(Car t)
        {
            CarDAO.Instance.updateData(t);
        }

        public Boolean existById(string id)
        {
            return CarDAO.Instance.getById(id) != null;
        }
    }
}
