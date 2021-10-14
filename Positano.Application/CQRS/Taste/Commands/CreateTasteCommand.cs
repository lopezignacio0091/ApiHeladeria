using FluentValidation;
using MediatR;
using Positano.Domain.Entities;
using Positano.Domain.Enum;
using Positano.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Positano.Application.CQRS
{
    public class CreateTasteCommand
    {
        public class Command : IRequest<CommandResult>
        {
         
            public string Name { get; set; }
         
            public int Quantity { get; set; }

            public TypeTaste TypeTaste { get; set; }

        }

        private class CreateBatchCommandValidator : AbstractValidator<Command>
        {
            public CreateBatchCommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Campo Requerido");
                RuleFor(x => x.Quantity).NotEmpty().WithMessage("Campo Requerido");
               
            }
        }

        public class Handler : IRequestHandler<Command, CommandResult>
        {
            private readonly GenericRepository<Taste> _repository;


            public Handler(GenericRepository<Taste> repository)
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


                    var taste = new Taste
                    {

                        Name = request.Name,
                        Quantity = request.Quantity,
                        TypeTaste = request.TypeTaste,

                    };

                    _repository.Insert(taste);

                    return CommandResult.Create(taste);
                }
                catch (System.Exception ex)
                {
                    return CommandResult.Create(("", ex.Message));
                }
            }
        }

    }
}
