using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class WebPage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public Guid Id { get; set; }

        public string SourceUrl { get; set; }

        public string StaticUrl { get; set; }

        public bool WillGenerate { get; set; }

        public bool IsFinalPage
        {
            get;
            set;
        }
    }

}