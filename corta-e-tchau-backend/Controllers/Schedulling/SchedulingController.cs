using System;
using System.Net;
using corta_e_tchau_backend.Domain.Notification;
using corta_e_tchau_backend.Model;
using corta_e_tchau_backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace corta_e_tchau_backend.Controllers
{
    [Route("[controller]")]
    public class SchedulingController : ApiBase
    {

        private readonly ISchedulingService _service;

        public SchedulingController(NotificationContext notificationContext, ISchedulingService service)
        {
            _notificationContext = notificationContext;
            _service = service;
        }

        [HttpGet("filter")]
        [Authorize]
        public JsonReturn Get(DateTime data)
        {
            return ReturnJson(_service.Get(data));
        }

        [HttpGet("{id}")]
        [Authorize]
        public JsonReturn Get(int id)
        {
            return ReturnJson(_service.Get(id));
        }

        [HttpPost]
        [Authorize]
        public JsonReturn Post([FromBody] Scheduling scheduling)
        {
            if (scheduling == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            return ReturnJson(_service.Insert(scheduling));
        }

        [HttpPut]
        [Authorize]
        public JsonReturn Put([FromBody] Scheduling scheduling)
        {
            if (scheduling == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

                return ReturnJson(_service.Update(scheduling));
            
        }

        [HttpDelete("{id}")]
        [Authorize]
        public JsonReturn Delete(int id)
        {
            return ReturnJson(_service.Delete(id));
        }
    }
}
