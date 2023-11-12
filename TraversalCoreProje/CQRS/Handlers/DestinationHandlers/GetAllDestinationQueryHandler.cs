using DataAccessLayer.Concrete;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProje.CQRS.Results.DestinationResults;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;
        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                id = x.DestinationID,
                city = x.City,
                daynight = x.DayNight,
                price = x.Price,
                capacity = x.Capacity
            }).AsNoTracking().ToList();
            return values;
        }
    }
}

