using Microsoft.AspNet.Identity.EntityFramework;

namespace CSRT.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {

        }

        public ApplicationRole(string name) : base(name)
        {

        }
    }
}