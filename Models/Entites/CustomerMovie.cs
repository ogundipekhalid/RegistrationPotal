using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class CustomerMovie : BaseEntity
    {
        // public int Id { get; set; }
          public int CustomerId { get; set; }
          public int MovieId { get; set; }
          public Customer Customer { get; set; }
          public Movie Movie { get; set; }

    }
}