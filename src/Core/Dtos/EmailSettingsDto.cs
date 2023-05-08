using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class EmailSettingsDto
    {
        public EmailSettingsDto()
        {

        }
        public EmailSettingsDto(string userName,
           string password)
        {
            UserName = userName;
            Password = password;
        }
        public string Host= "mail.ielts-zi.ir";
        public string UserName= "info@ielts-zi.ir";
        public string Password= "U7apd2$45";

        public int SMTPPort = 465;
        public int POP3Port = 995;
        public int IMAPPort = 993;

    }
}
