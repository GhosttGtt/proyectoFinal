using System.Collections.Generic;

namespace POS.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public decimal Total { get; set; }
        public List<SaleDetail> Details { get; set; }
    }

    public class SaleDetail
    {
        public int SaleDetailID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
