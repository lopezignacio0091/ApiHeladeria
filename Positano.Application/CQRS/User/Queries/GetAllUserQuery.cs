
using Financiera.Persistence;
using MediatR;
using Positano.Domain.Entities;
using Positano.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Positano.Application.CQRS
{
    public class GetAllUserQuery
    {
        public class Query : IRequest<Result>
        {
            public int? Id { get; set; }
        }

        public class Result : QueryResult
        {
            public List<User> Users { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly GenericRepository<User> _repository;

            public Handler(GenericRepository<User> context)
            {
                _repository = context;
            }

            public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                try
                {
                    var result = new Result();
                    var userList = _repository.GetAll();

                    if (userList == null)
                    {
                        result.Create(("", "No se encontraron resultados."));
                        return result;
                    }

                    result.Users = userList.ToList();

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
