using DataAccessLayer.Concrete;
using MediatR;
using TraversalCoreProje.CQRS.Queries.GuideQueries;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
    public class GetByIdGuideHandler : IRequestHandler<GetByIdGuideQuery, GetByIdGuideQueryResult>
    {
        private readonly Context _context;

        public GetByIdGuideHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetByIdGuideQueryResult> Handle(GetByIdGuideQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Guides.FindAsync(request.Id);
            return new GetByIdGuideQueryResult
            {
                GuideID = data.GuideID,
                Name = data.Name,
                Description = data.Description
            };
        }
    }
}
