namespace PPCRental.AcceptanceTests.Support
{
    public class PropertyContext
    {
        public PropertyContext()
        {
            ReferenceDetails = new ReferencePropertyList();
        }

        public ReferencePropertyList ReferenceDetails { get; set; }
        public ReferencePropertyList ReferenceFilter { get; set; }
        
    }
}