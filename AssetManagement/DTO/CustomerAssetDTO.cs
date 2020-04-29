using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.DTO
{
    public class CustomerAssetDTO
    {
        public int CustomerId { get; set; }
        public int AssetId { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime? ReturnDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }


        public virtual AssetDTO Asset { get; set; }


        public virtual CustomerDTO Customer { get; set; }
    }
}
