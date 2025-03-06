namespace JobPortalManagement.Entities
{
    public class Job
    {
        public int ID { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public double Salary { set; get; }

        public int CompanyID { set; get; }
        public Company? Company { set; get; } = null;

        public ICollection<Applicationn>? Applications { set; get; } = null;

        public override string ToString()
        {
            return $"Title : {Title} \n Description : {Description} \n Salary : {Salary} ";
        }


    }

}
