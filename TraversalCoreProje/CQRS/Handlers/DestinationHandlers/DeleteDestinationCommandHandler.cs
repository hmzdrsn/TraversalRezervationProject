using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class DeleteDestinationCommandHandler
    {
        private readonly Context _context;

        public DeleteDestinationCommandHandler(Context context)
        {
            _context = context;
       }
        public void Handle(DeleteDestinationCommand command)
        {
            var data = _context.Destinations.Find(command.Id);
            _context.Destinations.Remove(data);
            _context.SaveChanges();
        }
    }
}
