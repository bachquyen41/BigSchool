using Quanlysach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Quanlysach.Controllers
{
    public class SachController : ApiController
    {
        Sach[] sachs = new Sach[]
        {
            new Sach {Id=1, Title="Toi thay hoa vang tren co xanh" ,AuthorName="Nguyen Nhat Anh",Price=1, Content="Truyen ke ve tuoi tho...." },
            new Sach {Id=2, Title="Pro ASP.NET MVC5" ,AuthorName="Admin",Price=3.75M, Content="The ASP.NET MVC 5 Framework is the latest evolution of Microsoft’s ASP.NET web platform." },
        };
        public IEnumerable<Sach> GetAll()
        {
            return sachs;
        }

        public IHttpActionResult GetSach(int id)
        {
            var sach = sachs.FirstOrDefault((p) => p.Id == id);
            if (sach == null)
            {
                return NotFound();
            }
            return Ok(sach);
        }
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {

                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
    }
}
