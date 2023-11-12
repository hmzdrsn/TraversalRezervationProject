using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using TraversalCoreProje.CQRS.Commands.GuideCommands;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            await _context.Guides.AddAsync(new Guide
            {
                GuideID= request.GuideID,
                Name= request.Name,
                Description = request.Description,
                Status=true
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
