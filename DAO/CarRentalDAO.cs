using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class CarRentalDAO : IDAO<CarRental>
    {
        private static CarRentalDAO instance = null;
        private static readonly object instanceLock = new object();
        private CarRentalDAO() { }
        public static CarRentalDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarRentalDAO();
                    }
                    return instance;
                }
            }
        }

        public void deleteData(CarRental t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.CarRentals.Remove(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public CarRental getById(string id)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.CarRentals.Find(id);
            }
        }

        public List<CarRental> getData()
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.CarRentals.ToList();
            }
        }

        public Boolean isAvailableByDate(string carId, DateTime startDate, DateTime endDate)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.CarRentals.Where(c => c.CarId == carId)
                    .Where(c => (startDate < c.PickupDate && c.PickupDate < endDate) 
                    || (startDate < c.ReturnDate && c.ReturnDate < endDate)).Count() == 0;
            }
        }

        public void insertData(CarRental t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.CarRentals.Add(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public void updateData(CarRental t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.CarRentals.Update(t);
                dbContext.SaveChanges();
                return;
            }
        }
    }
}
