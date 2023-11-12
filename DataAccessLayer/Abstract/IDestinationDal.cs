using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal : IGenericDal<Destination>
    {
		void DeleteDestinationById(int id);
        public Destination GetDestinationWithGuide(int id);

        public List<Destination> GetLast4Destinations();
	}
}
