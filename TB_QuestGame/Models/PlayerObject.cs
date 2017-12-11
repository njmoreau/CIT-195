using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class PlayerObject : GameObject
    {
        public override int ID { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int LocationID { get; set; }
        public PlayerObjectType Type { get; set; }
        public bool CanInventory { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsVisable { get; set; }
        public int Value { get; set; }
    }
}
