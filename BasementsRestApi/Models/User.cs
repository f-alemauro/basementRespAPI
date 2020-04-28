using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasementsRestApi.Models
{
    /// <summary>
    /// This class reprents the user
    /// </summary>
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Last Activity")]
        public DateTime LastActivityTimestamp { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Item> Items { get; set; }

        /// <summary>
        /// Ctor of the user class
        /// </summary>
        public User()
        {
            Items = new HashSet<Item>();
        }
    }
}