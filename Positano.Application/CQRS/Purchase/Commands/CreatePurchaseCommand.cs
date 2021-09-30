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
   public class CreatePurchaseCommand
    {
        public class Command : IRequest<CommandResult>
        {
            public int OrderId { get; set; }
            public DateTime Date { get; set; }
            public int Total { get; set; }

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
            private readonly GenericRepository<Purchase> _repository;
         

            public Handler(GenericRepository<Purchase> repository)
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


                    var purchase = new Purchase
                    {

                        Date = request.Date,
                        OrderId = request.OrderId,
                        Total = request.Total,
                      
                    };

                    _repository.Insert(purchase);

                    return CommandResult.Create(purchase);
                }
                catch (System.Exception ex)
                {
                    return CommandResult.Create(("", ex.Message));
                }
            }
        }
    }
}
