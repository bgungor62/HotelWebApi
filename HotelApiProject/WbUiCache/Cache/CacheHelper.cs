using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.WebUI.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WbUiCache.Cache
{

    public class CacheHelper
    {
        //ICache cache;
        //Staff _staff;
        //public CacheHelper(ICache cache, Staff staff)
        //{
        //    this.cache = cache;
        //    _staff = staff;
        //}
        //private string Staff_CacheKey = "Staff_CacheKey";
        //public bool StaffClear() { return Clear(Staff_CacheKey); }
        //public List<StaffViewModel> StaffList
        //{
        //    //get
        //    //{
        //    //    var fromCache = Get<List<StaffViewModel>>(Staff_CacheKey);
        //    //    if (fromCache==null)
        //    //    {
        //    //        var datas=_staff.Get
        //    //    }
        //    }
        //}

        //public bool Clear(string name)
        //{
        //    cache.Remove(name);
        //    return true;
        //}

        //public T Get<T>(string cacheKey) where T : class
        //{
        //    object cookies;
        //    if (!cache.TryGetValue(cacheKey, out cookies))
        //        return null;
        //    return cookies as T;
        //}

        //public void Set(string cacheKey, object value)
        //{
        //    cache.Set(cacheKey, value, 180);
        //}

    }
}
