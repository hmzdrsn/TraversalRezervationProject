using MediatR;

namespace TraversalCoreProje.CQRS.Commands.GuideCommands
{
    public class DeleteGuideCommand : IRequest
    {
        public int id { get; set; }
        public DeleteGuideCommand(int id)
        {
            this.id = id;
        }


    }
}
