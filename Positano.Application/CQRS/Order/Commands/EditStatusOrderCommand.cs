using FluentValidation;
using MediatR;
using Positano.Domain.Entities;
using Positano.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Positano.Application.CQRS
{
    public class EditStatusOrderCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public int OrderId { get; set; }
        }

        private class CreateBatchCommandValidator : AbstractValidator<Command>
        {
            public CreateBatchCommandValidator()
            {
                RuleFor(x => x.OrderId).NotEmpty().WithMessage("Campo Requerido");
              
            }
        }


        public class Handler : IRequestHandler<Command, CommandResult>
        {
            private readonly GenericRepository<Order> _repository;

            public Handler(GenericRepository<Order> repository)
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

                    var order = _repository.GetByIdInclude(x => x.OrderId == request.OrderId,x=>x.User);

                    if (order == null)
                    {
                        return null;
                    }
                    order.Status = Domain.Enum.Status.Delivered;
                    _repository.Update(order);
                    return CommandResult.Create(order);
                }
                catch (System.Exception ex)
                {
                    return CommandResult.Create(("", ex.Message));
                }
            }
        }
    }
}
