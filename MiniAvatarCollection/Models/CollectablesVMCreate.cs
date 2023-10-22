using MiniAvatarCollectionLibrary;

namespace MiniAvatarCollection.Models
{
    public class CollectablesVMCreate
    {
        public Collectable? Collectable { get; set; }

        public List<string> Nations = new List<string>()
        {
            "Fire Nation",
            "Air Nomads",
            "Water Tribe",
            "Earth Kingdom"
        };
        //collectable
        //welke nations zijn er.
    }
}
