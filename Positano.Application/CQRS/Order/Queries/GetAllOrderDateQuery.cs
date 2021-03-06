using MediatR;
using Microsoft.EntityFrameworkCore;
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
   public  class GetAllOrderDateQuery
    {
        public class Query : IRequest<Result>
        {
            public int? Id { get; set; }
        }

        public class Result : QueryResult
        {
            public List<Order> Orders { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly GenericRepository<Order> _repository;

            public Handler(GenericRepository<Order> context)
            {
                _repository = context;
            }

            public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                try
                   
                {
                   
                    var result = new Result();
                    var orderLists = _repository.GetQueryable(x => x.Date.Date == DateTime.Now.Date )
                        .Include(x=>x.TypeOrders)
                        .Include(x=>x.Tastes)
                        .Include(x=>x.User);

                    if (orderLists == null)
                    {
                        result.Create(("", "No se encontraron resultados."));
                        return result;
                    }

                    result.Orders = orderLists.ToList();

                    return result;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
