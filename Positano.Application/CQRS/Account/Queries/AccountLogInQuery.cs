
using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Positano.Domain.Entities;
using Positano.Persistence;
using Positano.CrossCutting.Security;

namespace Positano.Application.CQRS
{
    public class AccountLogInQuery
    {
        public class Query : IRequest<Result>
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class Result : QueryResult
        {
            public User User { get; set; }
        }

        public class UserValidator : AbstractValidator<Query>
        {
            public UserValidator()
            {
                RuleFor(x => x.UserName).NotEmpty().WithMessage("El nombre de usuario es obligatorio.");
                RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña es obligatoria.");
            }
        }

        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly PositanoContext _context;
           

            public Handler(PositanoContext context)
            {
                _context = context;
                
            }

            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = new Result();

                   

                    User user = _context.Users.FirstOrDefault(u => u.LastName == request.UserName);

                    if (user is null)
                    {
                        result.Create((string.Empty, "Usuario y/o contraseña son inválidos."));
                        return result;
                    }
         

                    result.User = user;

                    return result;
                }
                catch (System.Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
