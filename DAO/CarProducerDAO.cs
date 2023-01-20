using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class CarProducerDAO : IDAO<CarProducer>
    {
        private static CarProducerDAO instance = null;
        private static readonly object instanceLock = new object();
        private CarProducerDAO() { }
        public static CarProducerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarProducerDAO();
                    }
                    return instance;
                }
            }
        }

        public void deleteData(CarProducer t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.CarProducers.Remove(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public CarProducer getById(string id)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.CarProducers.Find(id);
            }
        }

        public List<CarProducer> getData()
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.CarProducers.ToList();
            }
        }

        public void insertData(CarProducer t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.CarProducers.Add(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public void updateData(CarProducer t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.CarProducers.Update(t);
                dbContext.SaveChanges();
                return;
            }
        }
    }
}
