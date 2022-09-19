using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ISocialMediaTypeRepository : IRepository<SocialMediaType>, IAsyncRepository<SocialMediaType>
    {
    }
}
