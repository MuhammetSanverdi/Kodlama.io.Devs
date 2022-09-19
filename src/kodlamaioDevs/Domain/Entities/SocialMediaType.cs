using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class SocialMediaType:Entity
    {
        public string Name { get; set; }
        public virtual ICollection<SocialMedia> SocialMedias { get; set; }
        public SocialMediaType()
        {

        }
        public SocialMediaType(int id,string name):this()
        {
            Id = id;
            Name = name;
        }
    }
}