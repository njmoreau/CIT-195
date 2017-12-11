using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class of the game map
    /// </summary>
    public class Universe
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all locations
        //
        private List<Location> _locations;
        private List<GameObject> _gameObjects;
        private List<NPC> _npcs;

        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }

        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }

        public List<NPC> NPCs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }

        #endregion

        #region ***** constructor *****

        // default Universe constructor
        public Universe()
        {
            // add all of the universe objects to the game
            IntializeUniverse();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the universe with all of the space-time locations
        /// </summary>
        private void IntializeUniverse()
        {
            _locations = UniverseObjects.Locations;
            _gameObjects = UniverseObjects.gameObjects;
            _npcs = UniverseObjects.NPCs;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        public bool IsValidLocationId(int locationId)
        {
            List<int> locationIds = new List<int>();

            // create a list of space-time location ids
            foreach (Location loc in _locations)
            {
                locationIds.Add(loc.LocationID);
            }

            // determine if the space-time location id is a valid id and return the result
            if (locationIds.Contains(locationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidGameObjectByLocationId(int gameObjectID, int currentLocation)
        {
            List<int> gameObjectIDs = new List<int>();

            // create a list of game object ids in current location
            foreach (GameObject gameObject in _gameObjects)
            {
                gameObjectIDs.Add(gameObject.ID);
            }

            // determine if valid id and return the result
            if (gameObjectIDs.Contains(gameObjectID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidPlayerObjectByLocationId(int playerObjectID, int currentLocation)
        {
            List<int> playerObjectIDs = new List<int>();

            //create a list of player obj ids in current location
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationID == currentLocation && gameObject is PlayerObject)
                {
                    playerObjectIDs.Add(gameObject.ID);
                }
            }

            //determine if game obj id is valid and return result
            if (playerObjectIDs.Contains(playerObjectID))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsValidNPCByLocationID(int npcID, int currentLocation)
        {
            List<int> npcIDs = new List<int>();

            //create list of NPC IDs in current location
            foreach (NPC npc in _npcs)
            {
                if (npc.LocationID == currentLocation)
                {
                    npcIDs.Add(npc.ID);
                }
            }

            //determine if the game object ID is valid and return result
            if (npcIDs.Contains(npcID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int locationId)
        {
            Location location = GetLocationByID(locationId);
            if (location.Accessable == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// return the next available ID for a Location object
        /// </summary>
        /// <returns>next LocationObjectID </returns>
        public int GetMaxLocationId()
        {
            int MaxId = 0;

            foreach (Location location in Locations)
            {
                if (location.LocationID > MaxId)
                {
                    MaxId = location.LocationID;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// get a Location object using an Id
        /// </summary>
        /// <param name="Id">space-time location Id</param>
        /// <returns>requested space-time location</returns>
        public Location GetLocationByID(int Id)
        {
            Location location = null;

            //
            // run through the location list and grab the correct one
            //
            foreach (Location loc in _locations)
            {
                if (loc.LocationID == Id)
                {
                    location = loc;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (location == null)
            {
                string feedbackMessage = $"The Location ID {Id} does not exist in the current world.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return location;
        }

        public GameObject GetGameObjectByID(int ID)
        {
            GameObject gameObjectToReturn = null;

            //run thru object list and grab correct one
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.ID == ID)
                {
                    gameObjectToReturn = gameObject;
                }
            }

            //specified id was not found in universe. throw exception
            if (gameObjectToReturn == null)
            {
                string feedbackMessage = $"The Object ID {ID} does not exist in the current area.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return gameObjectToReturn;
        }

        public List<GameObject> GetGameObjectByLocationID(int locationID)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            //run thru game obj list and get from current location
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationID == locationID)
                {
                    gameObjects.Add(gameObject);
                }
            }

            return gameObjects;
        }

        public List<PlayerObject> GetPlayerObjectByLocationID(int locationID)
        {
            List<PlayerObject> playerObjects = new List<PlayerObject>();

            //run thru game obj list and get from current location
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationID == locationID && gameObject is PlayerObject)
                {
                    playerObjects.Add(gameObject as PlayerObject);
                }
            }

            return playerObjects;
        }

        public NPC GetNPCByID(int ID)
        {
            NPC npcToReturn = null;

            //run thru npc list and grab correct one
            foreach (NPC npc in _npcs)
            {
                if (npc.ID == ID)
                {
                    npcToReturn = npc;
                }
            }

            //specified id was not found in universe. throw exception
            if (npcToReturn == null)
            {
                string feedbackMessage = $"The NPC ID {ID} does not exist in the current area.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return npcToReturn;
        }

        public List<NPC> GetNPCsByLocationID(int locationID)
        {
            List<NPC> npcs = new List<NPC>();

            //run thru npc obj list and grab all that are in the current location
            foreach (NPC npc in _npcs)
            {
                if (npc.LocationID == locationID)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;
        }

        #endregion
    }
}
