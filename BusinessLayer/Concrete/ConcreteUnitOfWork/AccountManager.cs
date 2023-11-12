using BusinessLayer.Abstract.AbstractUnitOfWork;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.ConcreteUnitOfWork
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUnitofWorkDal _unitofWorkDal;

        public AccountManager(IAccountDal accountDal, IUnitofWorkDal unitofWorkDal)
        {
            _accountDal = accountDal;
            _unitofWorkDal = unitofWorkDal;
        }

        public Account TGetByID(int id)
        {
            return _accountDal.GetByID(id);
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _unitofWorkDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _unitofWorkDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _unitofWorkDal.Save();
        }
    }
}
