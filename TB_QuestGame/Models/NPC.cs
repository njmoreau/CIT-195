using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public abstract class NPC : Character
    {
        public abstract int ID { get; set; }
        public abstract int Level { get; set; }
        public abstract string Description { get; set; }
        public abstract bool Barter { get; set; }

    }
}
