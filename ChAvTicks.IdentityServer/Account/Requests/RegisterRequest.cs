using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.IdentityServer.Account.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string? UserName { get; init; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Compare("Password")]
        public string? ConfirmedPassword { get; set; }

        [Required]
        public string? ReturnUrl { get; set; }
    }
}
