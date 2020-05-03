using BasementsRestApi.Commons;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasementsRestApi.Models
{
    /// <summary>
    /// This class represent the description of an item.
    /// E.g.: 1 liter full milk, 1 kilogram choccolate biscuits, and so so
    /// </summary>
    public class ItemDefinition
    {
        /// <summary>
        /// Unique id for the description
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemDefinitionID { get; set; }

        /// <summary>
        /// Barcode of this item definition
        /// </summary>
        [DisplayName("Bar Code")]
        public string BarCode { get; set; }

        /// <summary>
        /// The type of the item
        /// </summary>
        [Required]
        public ItemType Type { get; set; }

        /// <summary>
        /// Human readable description of the item
        /// </summary>
        [StringLength(30)]
        [DisplayName("Item Description")]
        public string Description { get; set; }

        /// <summary>
        /// The volume of the item with respect to the unit of measurement
        /// </summary>
        [Required]
        [Range(1,9999)]
        [DisplayName("Item Volume")]
        public float Volume { get; set; }

        /// <summary>
        /// The unit of measurement
        /// </summary>
        [Required]
        [DisplayName("Unit of measurement")]
        public UnitOfMeasurements UnitOfMeasurement { get; set; }


        [InverseProperty("ItemDefinition")]
        public virtual ICollection<Item> Items { get; set; }

        /// <summary>
        /// Ctor of the itemDefinition class
        /// </summary>
        public ItemDefinition()
        {
            Items = new HashSet<Item>();
        }
    }
}