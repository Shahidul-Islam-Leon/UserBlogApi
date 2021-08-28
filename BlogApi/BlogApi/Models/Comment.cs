using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogApi.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string CommentContent { get; set; }


        public string Username { get; set; }
       
        public int PostId { get; set; }
        public Post Post { get; set; }

     
     
    }
}