using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;

namespace Repo
{
    public class StaffAccountRepository : IRepository<StaffAccount>
    {
        public void deleteData(StaffAccount t)
        {
            StaffAccountDAO.Instance.deleteData(t);
        }

        public StaffAccount getById(string id)
        {
            return StaffAccountDAO.Instance.getById(id);
        }

        public List<StaffAccount> getData()
        {
            return StaffAccountDAO.Instance.getData();
        }

        public void insertData(StaffAccount t)
        {
            StaffAccountDAO.Instance.insertData(t);
        }

        public void updateData(StaffAccount t)
        {
            StaffAccountDAO.Instance.updateData(t);
        }
    }
}
