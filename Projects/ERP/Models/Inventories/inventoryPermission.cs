namespace ERP_Automation_Testing.Models
{

    public class InventoryPermission
    {
        public string profileType { get; set; }
        public string customer { get; set; }
        public string store { get; set; }
        public string inventorypermissionDescribtion { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string ItemTypeName { get; set; }
        public string code { get; set; }
        public string Quantity { get; set; }
        public string Quantity1 { get; set; }
        public object Date { get; internal set; }
    }

}


