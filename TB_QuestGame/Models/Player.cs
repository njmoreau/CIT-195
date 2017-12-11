using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Character
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS

        private int _expPoints;
        private int _hp;
        private int _lives;
        private List<int> _locationsVisited;
        private List<PlayerObject> _inventory;

        #endregion

        #region PROPERTIES

        public int ExpPoints
        {
            get { return _expPoints; }
            set { _expPoints = value; }
        }

        public int HitPoints
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public List<int> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }


        public List<PlayerObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<int>();
            _inventory = new List<PlayerObject>();
        }

        public Player(string name, RaceType race, string homeKingdom, int locationID) : base(name, race, homeKingdom, locationID)
        {
            _locationsVisited = new List<int>();
            _inventory = new List<PlayerObject>();
        }

        #endregion
        
        #region METHODS
        
        public bool HasVisited(int _locationID)
        {
            if (LocationsVisited.Contains(_locationID))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public override void Greeting(string name, RaceType race, string homeKingdom)
        {
            Console.WriteLine($"Greetings, {race}. Your name is {name} and you are from {homeKingdom}.");
        }

        #endregion
    }
}
