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
    public class ReservationManager : IReservationService

    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public List<Reservation> GetListReservationByAccepted(int id)
        {
            return _reservationDal.GetListReservationByAccepted(id);
        }

        public List<Reservation> GetListReservationByPrevious(int id)
        {
            return _reservationDal.GetListReservationByPrevious(id);
        }

        public List<Reservation> GetListReservationByWaitApproval(int id)
        {
            return _reservationDal.GetListReservationByWaitApproval(id);
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            throw new NotImplementedException();
        }

        public Reservation TGetById(int id)
        {
            return _reservationDal.GetByID(id);
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetList();
        }

        public List<Reservation> TGetListWithAll()
        {
            return _reservationDal.GetListWithAll();
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
