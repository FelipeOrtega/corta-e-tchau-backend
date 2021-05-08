using System.Net;
using corta_e_tchau_backend.Domain.Notification;
using corta_e_tchau_backend.Model;
using corta_e_tchau_backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace corta_e_tchau_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiBase
    {

        private readonly IUserService _service;
        public UserController(NotificationContext notificationContext, IUserService service)
        {
            _notificationContext = notificationContext;
            _service = service;
        }

        [HttpGet]
        public JsonReturn Get()
        {
            return ReturnJson(_service.Get());
        }

        [HttpGet("{id}")]
        public JsonReturn Get(int id)
        {
            return ReturnJson(_service.Get(id));
        }

        [HttpPost]
        public JsonReturn Post([FromBody] User modulo)
        {
            if (modulo == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            return ReturnJson(_service.Insert(modulo));
        }

        [HttpPut]
        public JsonReturn Put([FromBody] User modulo)
        {
            if (modulo == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            return ReturnJson(_service.Update(modulo));

        }

        [HttpDelete("{id}")]
        public JsonReturn Delete(int id)
        {
            return ReturnJson(_service.Delete(id));
        }
    }
}
