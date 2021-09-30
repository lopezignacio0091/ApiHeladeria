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
   public class CreateOrderCommand
    {
        public class Command : IRequest<CommandResult>
        {

            public virtual ICollection<TypeOrderDTO> TypeOrders { get; set; }
            public virtual ICollection<TasteDTO> Tastes { get; set; }

            public Boolean isUser   { get; set; }

            public User user { get; set; }

        }

        public class TasteDTO
        {
            public int TasteId { get; set; }
 
        }
        public class TypeOrderDTO
        {
            public int TypeOrderId { get; set; }
         
        }

        private class CreateBatchCommandValidator : AbstractValidator<Command>
        {
            public CreateBatchCommandValidator()
            {
                RuleFor(x => x.user.Phone).NotEmpty().WithMessage("Campo Requerido");
                RuleFor(x => x.user.Direction).NotEmpty().WithMessage("Campo Requerido");
                RuleFor(x => x.user.LastName).NotEmpty().WithMessage("Campo Requerido");
            }
        }

        public class Handler : IRequestHandler<Command, CommandResult>
        {
            private readonly GenericRepository<Order> _repository;
            private readonly GenericRepository<Taste> _repositoryTaste;
            private readonly GenericRepository<TypeOrder> _repositoryTypeOrder;
            private readonly GenericRepository<Purchase> _repositoryPurchase;
            private readonly GenericRepository<User> _repositoryUser;


            public Handler(
                GenericRepository<Order> repository,
                GenericRepository<Taste> repositoryTaste,
                GenericRepository<TypeOrder> repositoryTypeOrder,
                GenericRepository<Purchase> repositoryPurchase,
                GenericRepository<User> repositoryUser
                )
            {
                _repository = repository;
                _repositoryTaste = repositoryTaste;
                _repositoryTypeOrder = repositoryTypeOrder;
                _repositoryPurchase = repositoryPurchase;
                _repositoryUser = repositoryUser;
               
                
            }

            public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var validator = new CreateBatchCommandValidator().Validate(request);

                    if (!validator.IsValid)
                        return CommandResult.Create(validator.Errors.ToList());

                    var taste = _repositoryTaste.Get(x => request.Tastes.Select(t => t.TasteId).Contains(x.TasteId));
                    var typeOrder = _repositoryTypeOrder.Get(x => request.TypeOrders.Select(t => t.TypeOrderId).Contains(x.TypeOrderId));

                    if(!request.isUser)
                    _repositoryUser.Insert(request.user);

                    
                    taste.ToList().ForEach(x => { x.Quantity -= 250; _repositoryTaste.Update(x);}) ;
                   
                    var order = new Order
                    {
                        UserId = request.user.UserId,
                        Tastes = taste.ToList(),
                        TypeOrders = typeOrder.ToList(),
                        Date = System.DateTime.Now,
                        Status=Domain.Enum.Status.Pending,
                    };

                    _repository.Insert(order);

                    order.User = request.user;

                    var purchase = new Purchase
                    {
                        OrderId = order.OrderId,
                        Date = System.DateTime.Now,
                        Total = typeOrder.Sum(e => e.Cost),
                    };

                    _repositoryPurchase.Insert(purchase);

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
