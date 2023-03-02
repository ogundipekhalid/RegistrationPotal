using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class BaseEntity
    {
        public int Id { get; set; }     
        public bool IsdDleted { get; set; }  
    }
}