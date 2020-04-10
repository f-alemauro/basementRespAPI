using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasementsRestApi.Models
{
    /// <summary>
    /// This class is the item
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Unique id for the item
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }

        /// <summary>
        /// The numnber of items added
        /// </summary>
        [Required]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Item addition date
        /// </summary>
        [DisplayName("Added On")]
        [Required]
        public DateTime AddedOn { get; set; }

        /// <summary>
        /// Item expiration date
        /// </summary>
        [DisplayName("Expire On")]
        public DateTime ExpireOn { get; set; }

        
        public int ItemDefinitionID { get; set; }
        public int UserID { get; set; }
        /// <summary>
        /// The user who added this item
        /// </summary>
        //[ForeignKey("AddedByID")]
        //[InverseProperty("Items")]
        public virtual User User { get; set; }

        /// <summary>
        /// Definition of the item 
        /// </summary>
        //[ForeignKey("ItemDefinitionID")]
        //[InverseProperty("Items")]
        public virtual ItemDefinition ItemDefinition { get; set; }
    }
}