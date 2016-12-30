using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.DAL;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    public class WebPageController : ApiController
    {
        private delegate void DelegateExecGenerate();
        MyDbContext _db = new MyDbContext();
        // GET api/WebPage
        public List<WebPage> Get()
        {
            return _db.WebPages.ToList();
        }

        // POST api/WebPage
        public void Post(WebPages webPages)
        {
            if (webPages.WebPageList == null)
            {
                return;
            }
            foreach (var page in webPages.WebPageList)
            {
                var pageData = new WebPage
                {
                    Id = Guid.NewGuid(),
                    SourceUrl = page.SourceUrl,
                    StaticUrl = page.StaticUrl,
                    IsFinalPage = page.IsFinalPage == 1,
                    WillGenerate = true
                };
                if (_db.WebPages.Any(x => x.SourceUrl == page.SourceUrl))
                {
                    var existPage = _db.WebPages.Single(x => x.SourceUrl == page.SourceUrl);
                    existPage.StaticUrl = pageData.StaticUrl;
                    existPage.WillGenerate = pageData.WillGenerate;
                    existPage.IsFinalPage = pageData.IsFinalPage;
                }
                else
                {
                    _db.WebPages.Add(pageData);
                }
            }
            _db.SaveChanges();
            new DelegateExecGenerate(GenerateStaticPage).BeginInvoke(null, null);
        }

        private static void GenerateStaticPage()
        {
            var path = ConfigurationManager.AppSettings["generateProPath"];
            System.Diagnostics.Process.Start(path);
        }

    }
}

