using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class FarmModellDto
    {
        public Guid Id { get; set; }
        public string NomeFazenda { get; set; } = string.Empty;
        public string AreaHectares { get; set; } = string.Empty;
        
        
        
    }

   
}