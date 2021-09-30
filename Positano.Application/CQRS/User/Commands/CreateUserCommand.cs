
using FluentValidation;
using MediatR;
using Positano.Domain.Entities;
using Positano.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Positano.Application.CQRS
{
    public  class CreateUserCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public string LastName { get; set; }
            public string Direction { get; set; }
            public int Phone { get; set; }


        }

        private class CreateBatchCommandValidator : AbstractValidator<Command>
        {
            public CreateBatchCommandValidator()
            {
                RuleFor(x => x.LastName).NotEmpty().WithMessage("Campo Requerido");
                RuleFor(x => x.Direction).NotEmpty().WithMessage("Campo Requerido");
                RuleFor(x => x.Phone).NotEmpty().WithMessage("Campo Requerido");
             
            }
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
                    var validator = new CreateBatchCommandValidator().Validate(request);

                    if (!validator.IsValid)
                        return CommandResult.Create(validator.Errors.ToList());

            
                    var user = new User
                    {
                      
                        LastName = request.LastName,
                        Phone = request.Phone,
                        Direction = request.Direction
                    };
                   
                    _repository.Insert(user);

                    user = _repository.GetByIdInclude(x => x.UserId == user.UserId);

                    return CommandResult.Create(user);
                }
                catch (System.Exception ex)
                {
                    return CommandResult.Create(("", ex.Message));
                }
            }
        }
    }
}
