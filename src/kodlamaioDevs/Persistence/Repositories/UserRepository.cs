using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
            

        }

        public List<OperationClaim> GetOperationClaims(User user)
        {
                var result = from o in Context.OperationClaims
                             join u in Context.UserOperationClaims
                             on o.Id equals u.OperationClaimId
                             where user.Id == u.UserId 
                             select new OperationClaim { Id = o.Id, Name = o.Name };

                return result.ToList();           
        }
    }
}
