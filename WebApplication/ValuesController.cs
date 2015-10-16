using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Akka.Actor;
using DataModel;

namespace WebApplication
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public async Task<string> Get()
        {
            var result = await SystemActors.DoesDbRecordExistActor.Ask<string>(new Message("I am got send from an ask in Get()", Guid.NewGuid()));
            return result;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}