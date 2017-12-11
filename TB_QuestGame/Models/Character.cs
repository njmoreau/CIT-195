using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            None,
            Human,
            Elf,
            Dwarf
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _age;
        private int _locationID;
        private RaceType _race;

        //
        // AION SPRINT 1
        //
        private string _homeKingdom;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        //
        // AION SPRINT 1
        //
        public string HomeKingdom
        {
            get { return _homeKingdom; }
            set { _homeKingdom = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, string homeKingdom, int locationID)
        {
            _name = name;
            _race = race;
            _homeKingdom = homeKingdom;
            _locationID = locationID;
        }

        #endregion

        #region METHODS

        public virtual void Greeting(string name, RaceType race, string homeKingdom)
        {
            Console.WriteLine($"Greetings, {race}. Your name is {name} and you are from {homeKingdom}.");
        }


        #endregion
    }
}
