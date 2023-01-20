using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;

namespace Repo
{
    public class CarRentalRepository : IRepository<CarRental>
    {
        public void deleteData(CarRental t)
        {
            CarRentalDAO.Instance.deleteData(t);
        }

        public CarRental getById(string id)
        {
            return CarRentalDAO.Instance.getById(id);
        }

        public List<CarRental> getData()
        {
            return CarRentalDAO.Instance.getData();
        }

        public void insertData(CarRental t)
        {
            CarRentalDAO.Instance.insertData(t);
        }

        public void updateData(CarRental t)
        {
            CarRentalDAO.Instance.updateData(t);
        }
    }
}
