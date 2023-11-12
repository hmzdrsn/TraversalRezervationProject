using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ContactUsStatusChange(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            using(var context = new Context())
            {
                var data = context.ContactUses.Where(x=>x.MessageStatus==false).ToList();
                return data;
            }
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            using (var context = new Context())
            {
                var data = context.ContactUses.Where(x => x.MessageStatus == true).ToList();
                return data;
            }
        }
    }
}
