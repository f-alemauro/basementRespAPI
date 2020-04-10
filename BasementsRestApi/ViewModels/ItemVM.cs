using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasementsRestApi.ViewModels
{
    public class ItemVM
    {
        public int Quantity { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ExpireOn { get; set; }
        public int ItemDefinitionID { get; set; }
    }
}
