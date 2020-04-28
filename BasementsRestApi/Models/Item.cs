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
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 999, ErrorMessage = "Quantity must be greater than 0")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Item addition date
        /// </summary>
        [DisplayName("Added On")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Added on is required")]
        public DateTime AddedOn { get; set; }

        /// <summary>
        /// Item expiration date
        /// </summary>
        [DisplayName("Expire On")]
        [Required(ErrorMessage = "Expiring date is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpireOn { get; set; }

        [Required(ErrorMessage = "Item definition is required")]
        public int ItemDefinitionID { get; set; }
        [Required(ErrorMessage = "User is required")]
        public int UserID { get; set; }

        /// <summary>
        /// The user who added this item
        /// </summary>
        
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        /// <summary>
        /// Definition of the item 
        /// </summary>
        //[ForeignKey("ItemDefinitionID")]
        //[InverseProperty("Items")]
       
        [ForeignKey("ItemDefinitionID")]
        public virtual ItemDefinition ItemDefinition { get; set; }
    }
}