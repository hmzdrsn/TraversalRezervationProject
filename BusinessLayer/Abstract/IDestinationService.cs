using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {

		void TDeleteDestinationById(int id);

        public Destination TGetDestinationWithGuide(int id);
        public List<Destination> TGetLast4Destinations();
    }
}
