using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

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
        CLEANING,
        PETS,
        OTHER
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

    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
    
    ///// <summary>
    ///// This class contains common definitions: enum, useful classes...
    ///// </summary>
    //public class Commons
    //{

    //}
}