namespace JobPortalManagement.Entities
{
    public class Applicationn
    {
        public int ID { set; get; }

        public int UserID { set; get; }
        public Userr user { set; get; }

        public string Status { set; get; }   // "Pending", "Accepted", "Rejected"

        public int jobID { set; get; }
        public Job job { set; get; }

        public override string ToString()
        {
            return $"User Name :  {this.user.Name}, status : {Status}";
        }


    }

}
