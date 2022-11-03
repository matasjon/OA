using Microsoft.AspNetCore.Identity;

namespace OnAct.Auth.Model
{
    public class OnActUser : IdentityUser
    {
        [PersonalData]
        public string? AdditionalInfo { get; set;  }
    }
}
