using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class PostParams : PaginationParams
    { 
        
        public string Type { get; set; }


    }
}
