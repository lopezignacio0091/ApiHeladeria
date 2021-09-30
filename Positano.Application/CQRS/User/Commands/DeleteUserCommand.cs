
using MediatR;
using Positano.Domain.Entities;
using Positano.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Positano.Application.CQRS
{
    public class DeleteUserCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public int UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, CommandResult>
        {
            private readonly GenericRepository<User> _repository;

            public Handler(GenericRepository<User> repository)
            {
                _repository = repository;
            }

            public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = _repository.GetByID(request.UserId);
                    if (user == null) return default;

                    _repository.Delete(request.UserId);

                    return CommandResult.Create(request.UserId);
                }
                catch (System.Exception ex)
                {
                    return CommandResult.Create(("", ex.Message));
                }
            }
        }
    }
}
