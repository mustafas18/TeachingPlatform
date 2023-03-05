using System.Diagnostics.Contracts;

namespace WebApi.ViewModels.Acconut
{
    public class LoginResultViewModel
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; } 
       public DateTime IssuedDate { get; set; }
    }
}
