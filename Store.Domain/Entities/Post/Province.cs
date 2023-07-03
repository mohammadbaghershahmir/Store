using Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Post
{
    public class Province : BaseEntity
    {
        public virtual Province Parrent { get; set; }
        public string? ParrentId { get; set; }
        public string? CityName { get; set; }
        public double Cost { get; set; }
        public int DeliverDay { get; set; }

        public virtual ICollection<Province> SubProvinces { get; set; }

    }
}
