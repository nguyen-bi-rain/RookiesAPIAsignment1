using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BulkDeleteTaskDTO
    {
        public List<Guid> TodoIds { get; set; }
    }
}
