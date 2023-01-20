using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;
namespace Repo
{
    public class CarProducerRepository : IRepository<CarProducer>
    {
        public void deleteData(CarProducer t)
        {
            CarProducerDAO.Instance.deleteData(t);
        }

        public CarProducer getById(string id)
        {
            return CarProducerDAO.Instance.getById(id);
        }

        public List<CarProducer> getData()
        {
            return CarProducerDAO.Instance.getData();
        }

        public void insertData(CarProducer t)
        {
            CarProducerDAO.Instance.insertData(t);
        }

        public void updateData(CarProducer t)
        {
            CarProducerDAO.Instance.updateData(t);
        }
    }
}
