using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Commons
{
    public  class BaseEntity<Tkey>
    {
       
        public  Tkey Id { get; set; }
        public DateTime? InsertTime { get; set; }=DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<string>
    {

    }
}

