using server.Data;

namespace server.service
{
    public class LoginService
    {
        public LoginService()
        {
        }

        public bool VerificaLogin(string user, string pass)
        {
            if (user == "SISTEMA" && pass == "candidato123")
                return true;
            else return false;
        }
    }
}
