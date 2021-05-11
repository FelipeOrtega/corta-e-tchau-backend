using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using corta_e_tchau_backend.Domain.Notification;
using corta_e_tchau_backend.Model;
using System.Net;
using corta_e_tchau_backend.Service;

namespace corta_e_tchau_backend.Controllers
{
    [Route("[controller]")]
    public class AutenticateController : ApiBase
    {
        private readonly IUserService _service;

        public AutenticateController(NotificationContext notificationContext, IUserService service)
        {
            _service = service;
            _notificationContext = notificationContext;
        }

        [HttpGet]
        [Authorize]
        [EnableCors("AllowAll")]
        public JsonReturn Get()
        {
            return ReturnJson(_service.Get());
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonReturn Post([FromBody] User user)
        {
            var userValidate = _service.Get(user);

            if (userValidate == null)
                return ReturnJson(userValidate, (int)HttpStatusCode.Forbidden);

            var token = TokenService.GenerateToken(userValidate);

            userValidate.password = "";

            var data = new { user = userValidate, token = token };
   
            return ReturnJson(data);
        }

        [HttpPut]
        [Authorize]
        [EnableCors("AllowAll")]
        public JsonReturn Put([FromBody] User user)
        {
            if (user == null)
                return ReturnJson("Por favor, passe alguma informação.", (int)HttpStatusCode.BadRequest);

            return ReturnJson(_service.Update(user));
         }

        [HttpDelete("{id}")]
        [Authorize]
        [EnableCors("AllowAll")]
        public JsonReturn Delete(int id)
        {
            return ReturnJson(_service.Delete(id));
        }

    }
}
