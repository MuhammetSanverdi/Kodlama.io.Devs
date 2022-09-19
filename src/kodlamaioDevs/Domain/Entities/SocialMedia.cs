using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialMedia:Entity
    {
        public int UserId { get; set; }
        public int SocialMediaTypeId { get; set; }
        public string Address { get; set; }
        public virtual User? User { get; set; }
        public virtual SocialMediaType? SocialMediaType { get; set; }

        public SocialMedia()
        {

        }
        public SocialMedia(int id,int userId,int typeId,string socialMediaAddress):this()
        {
            Id = id;
            UserId = userId;
            Address = socialMediaAddress;
            SocialMediaTypeId = typeId;
        }
    }
}
