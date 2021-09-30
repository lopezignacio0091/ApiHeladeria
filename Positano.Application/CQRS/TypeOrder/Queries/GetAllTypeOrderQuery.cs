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
    public class GetAllTypeOrderQuery
    {
        public class Query : IRequest<Result>
        {
            public int? Id { get; set; }
        }

        public class Result : QueryResult
        {
            public List<TypeOrder> TypeOrders { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly GenericRepository<TypeOrder> _repository;

            public Handler(GenericRepository<TypeOrder> context)
            {
                _repository = context;
            }

            public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                try
                {
                    var result = new Result();
                    var typeOrdersList = _repository.GetAll();

                    if (typeOrdersList == null)
                    {
                        result.Create(("", "No se encontraron resultados."));
                        return result;
                    }

                    result.TypeOrders = typeOrdersList.ToList();

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
