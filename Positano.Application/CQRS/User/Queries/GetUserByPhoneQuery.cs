using MediatR;
using Positano.Domain.Entities;
using Positano.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Positano.Application.CQRS
{
    public class GetUserByPhoneQuery
    {
        public class Query : IRequest<Result>
        {
            public int Phone { get; set; }
        }

        public class Result : QueryResult
        {
            public User User { get; set; }
        }


        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly GenericRepository<User> _repository;

            public Handler(GenericRepository<User> repository)
            {
                _repository = repository;
            }

            public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                try
                {
                    var result = new Result();

                    var usuario = _repository.GetByPhone(x => x.Phone == query.Phone);

                    if (usuario == null)
                    {
                        result.Create(("", "Usuario inexistente"));
                        return result;
                    }
                    result.User = usuario;
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
