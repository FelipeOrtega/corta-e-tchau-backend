using System.Net;
using corta_e_tchau_backend.Domain.Notification;
using corta_e_tchau_backend.Model;
using corta_e_tchau_backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace corta_e_tchau_backend.Controllers
{
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
        [Authorize]
        public JsonReturn Get()
        {
            return ReturnJson(_service.Get());
        }

        [HttpGet("{id}")]
        [Authorize]
        public JsonReturn Get(int id)
        {
            return ReturnJson(_service.Get(id));
        }

        [HttpPost]
        public JsonReturn Post([FromBody] User user)
        {
            if (user == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            return ReturnJson(_service.Insert(user));
        }

        [HttpPut]
        [Authorize]
        public JsonReturn Put([FromBody] User user)
        {
            if (user == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            return ReturnJson(_service.Update(user));

        }

        [HttpDelete("{id}")]
        [Authorize]
        public JsonReturn Delete(int id)
        {
            return ReturnJson(_service.Delete(id));
        }
    }
}
