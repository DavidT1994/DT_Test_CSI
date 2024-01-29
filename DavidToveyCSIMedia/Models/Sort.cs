using System.ComponentModel.DataAnnotations;

namespace DavidToveyCSIMedia.Models
{
    public class Sort
    {
        [Key]
        public int Id { get; set; }


        [RegularExpression("^[0-9]+(,[0-9]+)*$", ErrorMessage="Please enter a comma separated list of numbers")]
      
        public string Sequence { get; set; }
        public string Direction { get; set; }
        public int Time { get; set; }
    }
}
