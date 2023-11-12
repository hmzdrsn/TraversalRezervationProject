using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _IAnnouncementService;

        public AnnouncementManager(IAnnouncementDal ıAnnouncementService)
        {
            _IAnnouncementService = ıAnnouncementService;
        }

        public void TAdd(Announcement t)
        {
            _IAnnouncementService.Insert(t);
        }

        public void TDelete(Announcement t)
        {
            _IAnnouncementService.Delete(t);
        }

        public Announcement TGetById(int id)
        {
            return _IAnnouncementService.GetByID(id);
        }

        public List<Announcement> TGetList()
        {
            return _IAnnouncementService.GetList();
        }

        public void TUpdate(Announcement t)
        {
            _IAnnouncementService.Update(t);
        }
    }
}
