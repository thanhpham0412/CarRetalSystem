using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class ReviewDAO : IDAO<Review>
    {
        private static ReviewDAO instance = null;
        private static readonly object instanceLock = new object();
        private ReviewDAO() { }
        public static ReviewDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ReviewDAO();
                    }
                    return instance;
                }
            }
        }

        public void deleteData(Review t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.Reviews.Remove(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public Review getById(string id)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.Reviews.Find(id);
            }
        }

        public List<Review> getData()
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.Reviews.ToList();
            }
        }

        public void insertData(Review t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.Reviews.Add(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public void updateData(Review t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.Reviews.Update(t);
                dbContext.SaveChanges();
                return;
            }
        }
    }
}
