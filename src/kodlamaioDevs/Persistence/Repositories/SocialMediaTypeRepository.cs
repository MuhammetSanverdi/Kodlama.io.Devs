using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SocialMediaTypeRepository : EfRepositoryBase<SocialMediaType, BaseDbContext>, ISocialMediaTypeRepository
    {
        public SocialMediaTypeRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
