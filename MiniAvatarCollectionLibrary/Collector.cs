using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAvatarCollectionLibrary
{
    public class Collector
    {
        /// <summary>
        /// person that collects the collectables
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
 


        //een op veel
        public ICollection<MyCollection> MyCollections { get; set; }
    }
}
