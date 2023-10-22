using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAvatarCollectionLibrary
{
    public class Collectable
    {

        /// <summary>
        /// Collectables will be displayed in a catalogue.
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public string Nation { get; set; }

        //veel op veel
        public ICollection<MyCollection>? MyCollections { get; set; }


    }
}
