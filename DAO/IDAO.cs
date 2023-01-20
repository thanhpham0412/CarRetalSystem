using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    internal interface IDAO<T>
    {
        public void insertData(T t);
        public List<T> getData();
        public T getById(string id);
        public void updateData(T t);
        public void deleteData(T t);
    }
}
