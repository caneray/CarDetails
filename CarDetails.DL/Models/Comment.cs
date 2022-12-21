using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetails.DL.Models
{
    public class Comment
    {
        [Key]
        public int CommandId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Yorum Boş Geçilemez!")]
        [Display(Name = "Yorum")]
        public string Text { get; set; }
        public int CarId { get; set; }
        public UserModel _User { get; set; }
        public Car _Car { get; set; }
    }
}
