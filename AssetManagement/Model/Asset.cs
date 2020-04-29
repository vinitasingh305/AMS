using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Model
{
    public class Asset
    {
        public Asset()
        {
            CustomerAssets = new HashSet<CustomerAsset>();
        }
        public int Id { get; set; }

        public string AssetName { get; set; }

        public string TypeOfItem { get; set; }

        public int Quantity { get; set; }

        public string ItemDesc { get; set; }
        public string ItemBrand { get; set; }

        public DateTime? ManufacturingDate { get; set; }

        public string BUName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public virtual ICollection<CustomerAsset> CustomerAssets { get; set; }
    }
}
