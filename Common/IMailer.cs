using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Common
{
    public interface IMailer
    {
        void Send(string toAdress, string subject, string body);
    }
}
