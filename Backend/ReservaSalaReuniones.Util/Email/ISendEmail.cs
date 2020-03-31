using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaSalaReuniones.Util.Email
{
    public interface ISendEmail
    {
        bool Send(string To, string Body);
    }
}
