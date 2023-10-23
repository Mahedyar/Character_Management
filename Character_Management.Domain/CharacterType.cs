using Character_Management.Domain.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Domain
{
    public class CharacterType : BaseDomainEntity<int>
    {
        public string Type { get; set; }

    }
}
