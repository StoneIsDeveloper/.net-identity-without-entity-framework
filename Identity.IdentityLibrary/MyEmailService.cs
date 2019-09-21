using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IdentityLibrary
{
    public class MyEmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            throw new NotImplementedException();
        }

        public void SendEmail(MyIdentityMessage message)
        {
            new SendEmailService(message.Destination, message.Subject, message.Body).SendEmail();
        }
    }
}
