using System.ComponentModel;

namespace ConsoleApp1.Enums
{
    public enum SoStatusEnum
    {
        //[Description("N/A")]
        //Unknown,

        [Description("Pending")]
        Pending = 1,

        [Description("Approved")]
        Approved = 2,

        [Description("Rejected")]
        Rejected = 3,

        [Description("Stock Transfer")]
        StockTransfer = 4,

        [Description("Stock Out")]
        StockOut = 5,

        [Description("Shipped")]
        Shipped = 6
    }
}
