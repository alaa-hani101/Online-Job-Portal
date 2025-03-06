namespace JobPortalManagement.Entities
{
    public class Company
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Industry { set; get; }
        public string Location { set; get; }

        public ICollection<Job>? Jobs { set; get; } = null!;

        public override string ToString()
        {
            return $"Name: {Name} ,  Industry: {Industry},  Location : {Location}";
        }
    }

}
