using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;

namespace Repo
{
    public class CustomerRepository : IRepository<Customer>
    {
        public void deleteData(Customer t)
        {
            CustomerDAO.Instance.deleteData(t);
        }

        public Customer getById(string id)
        {
            return CustomerDAO.Instance.getById(id);
        }

        public List<Customer> getData()
        {
            return CustomerDAO.Instance.getData();
        }

        public List<Customer> getDataWithStr(string search)
        {
            return CustomerDAO.Instance.getDataWithStr(search);
        }

        public void insertData(Customer t)
        {
            CustomerDAO.Instance.insertData(t);
        }

        public void updateData(Customer t)
        {
            CustomerDAO.Instance.updateData(t);
        }

        public Boolean existById(string id)
        {
            return CustomerDAO.Instance.getById(id) != null;
        }
    }
}
