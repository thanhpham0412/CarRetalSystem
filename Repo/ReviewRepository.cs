using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;

namespace Repo
{
    public class ReviewRepository : IRepository<Review>
    {
        public void deleteData(Review t)
        {
            ReviewDAO.Instance.deleteData(t);
        }

        public Review getById(string id)
        {
            return ReviewDAO.Instance.getById(id);
        }

        public List<Review> getData()
        {
            return ReviewDAO.Instance.getData();
        }

        public void insertData(Review t)
        {
            ReviewDAO.Instance.insertData(t);
        }

        public void updateData(Review t)
        {
            ReviewDAO.Instance.updateData(t);
        }
    }
}
