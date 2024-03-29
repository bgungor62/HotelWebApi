﻿using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDal _workLocationDal;

        public WorkLocationManager(IWorkLocationDal workLocationDal)
        {
            _workLocationDal = workLocationDal;
        }

        public void BDelete(WorkLocation t)
        {
            _workLocationDal.Delete(t);
        }

        public WorkLocation BGetById(int id)
        {
            return _workLocationDal.GetById(id);
        }

        public List<WorkLocation> BGetList()
        {
            return _workLocationDal.GetList();
        }

        public void BInsert(WorkLocation t)
        {
            _workLocationDal.Insert(t);
        }

        public void BUpdate(WorkLocation t)
        {
            _workLocationDal.Update(t);
        }
    }
}
