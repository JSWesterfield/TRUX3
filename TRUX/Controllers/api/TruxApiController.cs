using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TRUX.Models;
using TRUX.Services;
using WikiWebStarter.Web.Models.Responses;

namespace TRUX.Controllers.api
{
    [Route("api/Trux")]
    public class TruxApiController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            ItemsResponse<Truck> response = new ItemsResponse<Truck>();
            try
            {
                TruxService svc = new TruxService();
                List<Truck> trux = svc.SelectAll();
                response.Items = trux;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public HttpResponseMessage Post(Truck model)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            ItemResponse<int> response = new ItemResponse<int>();
            try
            {
                TruxService svc = new TruxService();
                response.Item = svc.Insert(model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpPut]
        public HttpResponseMessage Put(Truck model)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState);

            try
            {
                TruxService svc = new TruxService();
                svc.Update(model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                TruxService svc = new TruxService();
                svc.Delete(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
        }
    }
}
