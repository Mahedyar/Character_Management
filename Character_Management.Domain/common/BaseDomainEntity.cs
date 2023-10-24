using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Domain.common
{
    public abstract class BaseDomainEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set;}
    }
}
