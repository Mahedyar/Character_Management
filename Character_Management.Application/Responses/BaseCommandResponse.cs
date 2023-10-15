using System.Collections.Generic;

namespace Character_Management.Application.Responses
{
    public class BaseCommandResponse
    {
        public int ID { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
