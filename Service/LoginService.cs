using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LoginService
    {
        public User Login(User Client)
        {
            User client;
            using (var context = new InvoiceContext())
            {
                
                client = context.Users.Where((user) => user.Username == Client.Username && user.Password == Client.Password).First();
                
            }
            return client;
        }
    }
}
