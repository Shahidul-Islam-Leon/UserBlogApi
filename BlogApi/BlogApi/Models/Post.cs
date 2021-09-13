using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogApi.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public string PostTitle { get; set; }
        [Required]
        public string PostContent { get; set; }
       
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
      //  public ICollection<Comment> Comments { get; set; }
    }
}