using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Sample01.DTO
{
    public class ErrorDTO
    {
        public int HttpStatusID { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
