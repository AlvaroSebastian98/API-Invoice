using APIInvoice.Models.Request;
using APIInvoice.Models.Response;
using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIInvoice.Controllers
{
    public class LoginController : ApiController
    {
        private LoginService service = new LoginService();        

        public Client_Response_v1 Login([FromBody] Client_Request_v2 request)
        {            
            Client_Response_v1 clientResponse = new Client_Response_v1();

            try
            {
                User client = new User
                {
                    Username = request.Username,
                    Password = request.Password
                };

                client = service.Login(client);

                clientResponse.ClientID = client.UserID;
                clientResponse.Username = client.Username;
            }            
            catch (Exception)
            {

            }

            return clientResponse;
            
        }
    }
}
