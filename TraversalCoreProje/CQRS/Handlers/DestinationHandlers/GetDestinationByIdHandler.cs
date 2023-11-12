using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;
using TraversalCoreProje.CQRS.Results.DestinationResults;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdHandler
    {
        private readonly Context _context;

        public GetDestinationByIdHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdResult Handle(GetDestinationByIdQuery query)
        {
            var data = _context.Destinations.Find(query.id);

            return new GetDestinationByIdResult
            {
                DestinationId = data.DestinationID,
                City = data.City,
                Daynight = data.DayNight,
                Price=data.Price
            };
        }
    }
}
