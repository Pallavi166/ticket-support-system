namespace TicketSupport.API.Models
{
    public class Ticket
    {

       
        public string TicketNumber { get; set; }

        public string Subject { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CreatedBy{ get; set; }

        public int? AssignedTo { get; set; }
        public int TicketId { get; set; }
    }
}
