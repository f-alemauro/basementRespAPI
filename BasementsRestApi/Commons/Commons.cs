using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace BasementsRestApi.Commons
{
    /// <summary>
    /// List of item type
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemType
    {
        FOOD,
        BEVERAGE,
        CLEANING
    }

    /// <summary>
    /// List of unit of measurement
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnitOfMeasurements
    {
        [Display(Name = "KG")]
        KILOGRAM,
        [Display(Name = "G")]
        GRAM,
        [Display(Name = "L")]
        LITER,
        [Display(Name = "U")]
        UNIT
    }
    
    /// <summary>
    /// This class contains common definitions: enum, useful classes...
    /// </summary>
    public class Commons
    {

    }
}