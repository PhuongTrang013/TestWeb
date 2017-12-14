using PPCRental.Models;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.Support
{
    [Binding, Scope(Tag ="automated")]
    public class DatabaseTools
    {
        [BeforeScenario]
        public void CleanDatabase()
        {
            using (var db = new K21T1_Tteam13Entities())
            {

                db.PROPERTies.RemoveRange(db.PROPERTies);
                db.PROPERTY_TYPE.RemoveRange(db.PROPERTY_TYPE);
                db.PROPERTY_FEATURE.RemoveRange(db.PROPERTY_FEATURE);
                db.PROPERTY_IMG.RemoveRange(db.PROPERTY_IMG);
                db.SaveChanges();
            }
        }
    }
}
