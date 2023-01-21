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
        
        public List<Car> getDataWithStr(string search)
        {
            return CarDAO.Instance.getDataWithStr(search);
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

        public int calculateRentingDateInPeriod(string carId, DateTime startDate, DateTime endDate)
        {
            int days = 0;
            foreach (var rental in CarRentalDAO.Instance.getListByCar(carId))
            {
                if (rental.PickupDate <= startDate)
                {
                    if (rental.ReturnDate > startDate)
                    {
                        if (rental.ReturnDate <= endDate)
                        {
                            days+= (rental.ReturnDate - startDate).Days;
                        } else
                        {
                            days += (endDate - startDate).Days;
                        }
                    }
                } else
                {
                    if (rental.PickupDate < endDate)
                    {
                        if (rental.ReturnDate <= endDate)
                        {
                            days += (rental.ReturnDate - rental.PickupDate).Days;
                        }
                        else
                        {
                            days += (endDate - rental.PickupDate).Days;
                        }
                    }
                }
            }
            return days;
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
