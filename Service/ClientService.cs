using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClientService
    {
        public List<User> Get()
        {
            List<User> Clients = null;
            using (var context = new InvoiceContext())
            {

                Clients = context.Users.Where((user) => user.UserTypeID == 2).ToList();

            }
            return Clients;
        }

        public User GetById(int ID)
        {
            User Client = null;

            using (var context = new InvoiceContext())
            {
                Client = context.Users.Find(ID);
            }

            return Client;
        }

        public int Insert(User Client)
        {
            int id;
            using (var context = new InvoiceContext())
            {
                context.Users.Add(Client);
                context.SaveChanges();

                id = Client.UserID;
            }
            return id;
        }

        public void Update(User newClient, int ID)
        {
            using (var context = new InvoiceContext())
            {
                var Client = context.Users.Find(ID);
                Client.Username = newClient.Password ?? Client.Password;
                Client.Password = newClient.Username ?? Client.Username;
                Client.UserTypeID = newClient.UserTypeID == 0 ? Client.UserTypeID : newClient.UserTypeID;
                context.SaveChanges();
            }
        }

        public bool Delete(int ID)
        {
            bool status;
            try
            {
                using (var context = new InvoiceContext())
                {
                    var Client = context.Users.Find(ID);
                    context.Users.Remove(Client);
                    context.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
