using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TestModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

    }
}
