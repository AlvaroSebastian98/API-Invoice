using System;
using System.Collections.Generic;
using System.Linq;
using Service;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIInvoice.Models.Response;
using Domain;
using APIInvoice.Models.Request;

namespace APIInvoice.Controllers
{
    public class ClientController : ApiController
    {
        private ClientService service = new ClientService();

        public List<Client_Response_v1> Get()
        {
            var response = (from c in service.Get()
                            where c.UserTypeID == 2
                            select
                            new Client_Response_v1
                            {
                                ClientID = c.UserID,
                                Username = c.Username
                            }).ToList();

            return response;
        }

        public Client_Response_v1 Get(int id)
        {
            User client = new User();

            client = service.GetById(id);

            Client_Response_v1 clientResponse = new Client_Response_v1
            {
                ClientID = client.UserID,
                Username = client.Username
            };

            return clientResponse;
        }

        public int Post([FromBody] Client_Request_v1 request)
        {
            User client = new User();
            client.Username = request.Username;
            client.Password = request.Password;
            client.UserTypeID = request.UserTypeID;

            int id = service.Insert(client);

            return id;
        }

        public void Update([FromBody] Client_Request_v1 request)
        {

            User client = new User();
            client.Username = request.Username;
            client.Password = request.Password;

            service.Update(client, client.UserID);
        }

        public bool Delete(int id)
        {
            bool response = service.Delete(id);
            return response;
        }
    }
}
