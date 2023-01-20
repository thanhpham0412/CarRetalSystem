using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class StaffAccountDAO : IDAO<StaffAccount>
    {
        private static StaffAccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private StaffAccountDAO() { }
        public static StaffAccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StaffAccountDAO();
                    }
                    return instance;
                }
            }
        }

        public void deleteData(StaffAccount t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.StaffAccounts.Remove(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public StaffAccount getById(string id)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.StaffAccounts.Find(id);
            }
        }

        public List<StaffAccount> getData()
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return dbContext.StaffAccounts.ToList();
            }
        }

        public void insertData(StaffAccount t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.StaffAccounts.Add(t);
                dbContext.SaveChanges();
                return;
            }
        }

        public void updateData(StaffAccount t)
        {
            using (var dbContext = new CarRentalSystemDBContext())
            {
                dbContext.StaffAccounts.Update(t);
                dbContext.SaveChanges();
                return;
            }
        }
    }
}
