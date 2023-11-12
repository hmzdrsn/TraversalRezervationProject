using DataAccessLayer.Concrete;
using MediatR;
using TraversalCoreProje.CQRS.Commands.GuideCommands;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
    public class DeleteGuideHandler : IRequestHandler<DeleteGuideCommand>
    {
        private readonly Context _context;

        public DeleteGuideHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGuideCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Guides.FindAsync(request.id);
            _context.Guides.Remove(data);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
