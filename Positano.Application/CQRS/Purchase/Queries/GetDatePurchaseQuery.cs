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
    public class GetDatePurchaseQuery
    {
        public class Query : IRequest<Result>
        {
            public DateTime Date { get; set; }
        }

        public class Result : QueryResult
        {
            public List<Purchase> Purchases { get; set; }
        }


        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly GenericRepository<Purchase> _repository;

            public Handler(GenericRepository<Purchase> context)
            {
                _repository = context;
            }

            public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                try
                {
                    var result = new Result();
                    var purchaseList = _repository.GetQueryable(x=>x.Date.Date == query.Date.Date,
                                                          x => x.Order.TypeOrders,
                                                          x => x.Order.Tastes,
                                                          x => x.Order.User,
                                                          x => x.Order);

                    if (purchaseList == null)
                    {
                        result.Create(("", "No se encontraron resultados."));
                        return result;
                    }

                    result.Purchases = purchaseList.ToList();

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
