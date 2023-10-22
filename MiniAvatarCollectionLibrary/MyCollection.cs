using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAvatarCollectionLibrary
{
    public class MyCollection
    {
        /// <summary>
        /// functions as a list of acquired collectables by a collector
        /// </summary>
        public int MyCollectionID { get; set; }
        public string MyCollectionName { get; set; }

        //Veel op Veel
        public ICollection<Collectable> Collectables { get; set; }

        // een op veel
        public Collector? Users { get; set; }
    }
}
