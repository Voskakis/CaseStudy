using BackLayers.DAL;
using BackLayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackLayers.Controllers
{
    
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        private readonly DatabaseContext db = new DatabaseContext();

        // GET api/values
        public IEnumerable<Click> Get()
        {
            return db.Clicks;
        }

        // GET api/values/5
        public Click Get(int id)
        {
            return db.Clicks.Find(id);
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] Click click)
        {
            db.Clicks.Add(click);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, click);
        }
    }
}
