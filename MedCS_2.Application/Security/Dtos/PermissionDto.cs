using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Dtos
{
    public class PermissionDto
    {

        public string Endpoint { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public string OperationType { get; set; } = string.Empty;
    }
}
