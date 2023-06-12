using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Medias
{
    public class MediaType:BaseEntity
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public ICollection<Media> Medias { get; set; }
    }
}
