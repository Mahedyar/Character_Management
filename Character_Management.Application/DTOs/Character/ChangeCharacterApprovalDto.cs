using Character_Management.Application.DTOs.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.DTOs.Character
{
    public class ChangeCharacterApprovalDto:BaseDto
    {
        public bool? Approved { get; set; }
    }
}
