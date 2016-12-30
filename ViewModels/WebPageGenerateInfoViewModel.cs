using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.ViewModels
{
    public class WebPages
    {
        public IEnumerable<WebPageGenerateInfoViewModel> WebPageList { get; set; }
    }
    
    public class WebPageGenerateInfoViewModel
    {
        public string SourceUrl { get; set; }

        public string StaticUrl { get; set; }
        public int IsFinalPage
        {
            get;
            set;
        }
    }
}