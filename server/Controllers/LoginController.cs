using Microsoft.AspNetCore.Mvc;
using server.service;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public bool Logar([FromQuery] string user,
                          [FromQuery] string pass)
        {
            try
            {
                if (user == "SISTEMA" && pass == "candidato123")
                    return true;
                else return false;
            }
            catch (Exception e)
            {
                throw new Exception("Requisão foi requisitada com erro");
            }
        }
    }
}
