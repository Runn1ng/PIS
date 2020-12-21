using System.ComponentModel.DataAnnotations.Schema;

namespace PIS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int? Role_id { get; set; }

        [ForeignKey("Locality")]
        public int? Locality_id { get; set; }

        public virtual Role Role { get; set; }
        public virtual Locality Locality { get; set; }

    }
}