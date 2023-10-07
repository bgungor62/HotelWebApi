using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void BInsert(T t);
        void BUpdate(T t);
        void BDelete(T t);
        List<T> BGetList();
        T BGetById(int id);
    }
}
