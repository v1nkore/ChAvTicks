using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.IdentityServer.Account.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        [Required]
        public string ReturnUrl { get; set; }
    }
}