using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public abstract class GameObject
    {
        public abstract int ID { get; set; }
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract int LocationID { get; set; }
    }
}
