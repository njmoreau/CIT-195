using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "The TB Quest Game" };
        public static List<string> FooterText = new List<string>() { "Nick Moreau, 2017" };

        #region INTITIAL GAME SETUP

        public static string QuestIntro()
        {
            string messageBoxText =
            "You have been tasked by the Village Elder to embark " +
            "on a quest that is imperative to the survival of your people. " +
            "You are to travel far to the North to find the source of the river's " +
            "pollution and stop it.\n" +
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "Your quest begins now.\n" +
            " \n" +
            "\tYour first task will be to set up the initial parameters of your quest.\n" +
            " \n" +
            "\tPress any key to begin the Quest Initialization Process.\n";

            return messageBoxText;
        }


        #region Initialize Quest Text

        public static string InitializeQuestIntro()
        {
            string messageBoxText =
                "Before you begin your quest, we must know a bit about you.\n" +
                " \n" +
                "You will be prompted for the required information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeQuestGetPlayerName()
        {
            string messageBoxText =
                "Enter your name, villager.\n" +
                " \n" +
                "Please use the name you wish to be referred during this quest.";

            return messageBoxText;
        }

        public static string InitializeQuestGetPlayerAge(Player gamePlayer)
        {
            string messageBoxText =
                $"Very good then, we will call you {gamePlayer.Name} on this Quest.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n" +
                "Please use the standard twelve moon years as your reference.";

            return messageBoxText;
        }

        public static string InitializeQuestGetPlayerRace(Player gamePlayer)
        {
            string messageBoxText =
                $"{gamePlayer.Name}, it will be important for us to know your race on this Quest.\n" +
                " \n" +
                "Enter your race below.\n" +
                " \n" +
                "Please choose from the race list below." +
                " \n";

            string raceList = null;

            foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
            {
                if (race != Character.RaceType.None)
                {
                    raceList += $"\t{race}\n";
                }
            }

            messageBoxText += raceList;

            return messageBoxText;
        }

        //
        // AION SPRINT 1
        //
        public static string InitializeQuestGetPlayerHomeKingdom(string name)
        {
            string messageBoxText =
                $"{name}, in case of emergency, it may be necessary to return your remains home. \n" +
                " \n" +
                "Enter your home kingdom below. \n" +
                " \n" +
                "Please use a recognized kingdom as your reference.";

            return messageBoxText;
        }

        public static string InitializeQuestEchoPlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"Very good then {gamePlayer.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your Quest. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tName: {gamePlayer.Name}\n" +
                $"\tAge: {gamePlayer.Age}\n" +
                $"\tRace: {gamePlayer.Race}\n" +

                //
                // AION SPRINT 1
                //
                $"\tHome: {gamePlayer.HomeKingdom}\n" +
                " \n" +
                "Press any key to begin your Quest.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string CurrentLocationInfo(Location location)
        {
            string messageBoxText =
            $"Current Location: {location.CommonName}\n" +
            " \n" +
            location.Description;

            return messageBoxText;
        }

        public static string PlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"\tName: {gamePlayer.Name}\n" +
                $"\tAge: {gamePlayer.Age}\n" +
                $"\tRace: {gamePlayer.Race}\n" +

                //
                // AION SPRINT 1
                //
                $"\tHome: {gamePlayer.HomeKingdom}\n" +
                " \n";
            //$"\t{gamePlayer.Greeting(gamePlayer.Name, gamePlayer.Race, gamePlayer.HomeKingdom)}";

            return messageBoxText;
        }

        public static string LookAround(Location location)
        {
            string messageBoxText =
                $"Current Location: {location.CommonName}\n" +
                " \n" + 
                location.GeneralContents;

            return messageBoxText;
        }

        public static string CurrentInventory(IEnumerable<PlayerObject> inventory)
        {
            string messageBoxText = "";

            //display table header
            messageBoxText =
            "ID".PadRight(10) +
            "Name".PadRight(30) +
            "Type".PadRight(10) +
            "\n" +
            "---".PadRight(10) +
            "----------------------------".PadRight(30) +
            "----------------------".PadRight(10) +
            "\n";

            //display all player objects in rows
            string inventoryObjectRows = null;
            foreach (PlayerObject inventoryObject in inventory)
            {
                inventoryObjectRows +=
                    $"{inventoryObject.ID}".PadRight(10) +
                    $"{inventoryObject.Name}".PadRight(30) +
                    $"{inventoryObject.Type}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += inventoryObjectRows;

            return messageBoxText;
        }

        public static string Travel(Player gamePlayer, List<Location> locations)
        {
            string messageBoxText =
                $"{gamePlayer.Name}, where would you like to go?\n" +
                " \n" +
                "Enter the ID number of your desired destination." +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "Accessible".PadRight(10) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "-------".PadRight(10) + "\n";

            //
            // display all locations except current location
            //
            string locationList = null;
            foreach (Location loc in locations)
            {
                if (loc.LocationID != gamePlayer.LocationID)
                {
                    locationList +=
                        $"{loc.LocationID}".PadRight(10) +
                        $"{loc.CommonName}".PadRight(30) +
                        $"{loc.Accessable}".PadRight(10) +
                        Environment.NewLine;
                }
            }

            messageBoxText += locationList;

            return messageBoxText;
        }

        public static string VisitedLocations(IEnumerable<Location> locations)
        {
            string messageBoxText =
                $"Locations Visited\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";
            //
            // display all locations
            //
            string locationList = null;
            foreach (Location location in locations)
            {
                locationList +=
                    $"{location.LocationID}".PadRight(10) +
                    $"{location.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += locationList;

            return messageBoxText;
        }

        public static string ListLocations(IEnumerable<Location> locations)
        {
            string messageBoxText =
                "Locations\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string locationList = null;
            foreach (Location location in locations)
            {
                locationList +=
                    $"{location.LocationID}".PadRight(10) +
                    $"{location.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += locationList;

            return messageBoxText;
        }

        public static string ListAllGameObjects(IEnumerable<GameObject> gameObjects)
        {
            //display table name and column headers
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Location ID".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            //display all traveler objects in rows
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.ID}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.LocationID}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        public static string GameObjectsChooseList(IEnumerable<GameObject> gameObjects)
        {
            //display table name and column headers
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                // display table header
                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            //display all traveler objects in rows
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.ID}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        public static string ListAllNPCObjects(IEnumerable<NPC> npcObjects)
        {
            // display table name and column headers
            string messageBoxText =
                "NPC Objects\n" +
                " \n" +

                // display table header
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Location ID".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            // display all npc obj in rows
            string npcObjectRows = null;
            foreach (NPC npcObject in npcObjects)
            {
                npcObjectRows +=
                    $"{npcObject.ID}".PadRight(10) +
                    $"{npcObject.Name}".PadRight(30) +
                    $"{npcObject.LocationID}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += npcObjectRows;

            return messageBoxText;
        }

        public static string LookAt(GameObject gameObject)
        {
            string messageBoxText = "";

            messageBoxText =
                $"{gameObject.Name}\n" +
                " \n" +
            gameObject.Description + "\n" +
                " \n";

            if (gameObject is PlayerObject)
            {
                PlayerObject playerObject = gameObject as PlayerObject;

                messageBoxText += $"The {playerObject.Name} has a value of {playerObject.Value} and ";

                if (playerObject.CanInventory)
                {
                    messageBoxText += "may be added to your inventory.";
                }

                else
                {
                    messageBoxText += "may not be added to your inventory.";
                }
            }
            else
            {
                messageBoxText += $"The {gameObject.Name} may not be added to your inventory.";
            }

            return messageBoxText;
        }

        public static string NPCsChooseList(IEnumerable<NPC> npcs)
        {
            // display table name and column headers
            string messageBoxText =
                "NPCs\n" +
                " \n" +

                // display table header
                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            // display all NPCs in rows
            string npcRows = null;
            foreach (NPC npc in npcs)
            {
                npcRows +=
                    $"{npc.ID}".PadRight(10) +
                    $"{npc.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += npcRows;

            return messageBoxText;
        }

        public static List<string> StatusBox(Player player, Universe universe)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Experience Points: {player.ExpPoints}\n");
            statusBoxText.Add($"Health: {player.HitPoints}\n");
            statusBoxText.Add($"Lives: {player.Lives}\n");

            return statusBoxText;
        }
        #endregion
    }
}
