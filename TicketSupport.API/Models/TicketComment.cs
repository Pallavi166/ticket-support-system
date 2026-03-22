using System.ComponentModel.DataAnnotations;

namespace TicketSupport.API.Models
{
    public class TicketComment
    {
        [Key]
        public int CommentId {get; set;}

        public int TicketId { get; set;}

        public string? CommentText { get; set;}

        public int Commentedby{ get; set;}
        public DateTime CreatedDate { get; set;}
    }
}
