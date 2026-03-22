using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSupport.API.Models
{
    [Table("ticketstatushistory")]
    public class TicketStatusHistory
    {



        public string Status { get; set; }
        public int TicketId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryId { get; set; }
        

  
        public int UpdatedBy { get; set;}

        public DateTime UpdatedDate { get; set;}
    }
}
