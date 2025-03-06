using JobPortal.Repositories;

namespace JobPortalManagement.Entities
{
    public class Userr 
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public String Password { set; get; }
        public string Role { set; get; }

        public ICollection<Applicationn>? Applications { set; get; } = null;

        public override string ToString()
        {
            return $"Name : {Name} , Email : {Email} , Role : {Role}";
        }

    }

}
