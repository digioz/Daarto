using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity.Web.Data
{
    public class ExtendedIdentityRole : IdentityRole<string>
    {
        public ExtendedIdentityRole() { }

        public string Description { get; set; }
    }
}
