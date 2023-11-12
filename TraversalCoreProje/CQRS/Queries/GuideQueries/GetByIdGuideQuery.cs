using MediatR;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Queries.GuideQueries
{
    public class GetByIdGuideQuery : IRequest<GetByIdGuideQueryResult>
    {
        public GetByIdGuideQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
