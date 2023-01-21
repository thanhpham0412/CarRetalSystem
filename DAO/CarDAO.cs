using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class CarDAO : IDAO<Car>
    {
        private static CarDAO instance = null;
        private static readonly object instanceLock = new object();
        private CarDAO() { }
        public static CarDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDAO();
                    }
                    return instance;
                }
            }
        }

        public void deleteData(Car t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.Cars.Remove(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public Car getById(string id)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.Cars.Find(id);
            }
        }

        public List<Car> getData()
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.Cars.ToList();
            }
        }

        public List<Car> getDataWithStr(string search)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.Cars.Where(c => c.CarName.Contains(search)).ToList();
            }
        }

        public void insertData(Car t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.Cars.Add(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public void updateData(Car t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.Cars.Update(t);
                dbContext.SaveChanges();
                return;
            }
        }
    }
}
