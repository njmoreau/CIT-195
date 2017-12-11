using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {
        public static Menu QuestIntro = new Menu()
        {
            MenuName = "QuestIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, PlayerAction>()
                    {
                        { ' ', PlayerAction.None }
                    }
        };

        public static Menu InitializeQuest = new Menu()
        {
            MenuName = "InitializeQuest",
            MenuTitle = "Initialize Quest",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.LookAround },
                { '2', PlayerAction.Travel },
                { '3', PlayerAction.ObjectMenu },
                { '4', PlayerAction.NonPlayerCharacterMenu },
                { '5', PlayerAction.PlayerMenu },
                { '6', PlayerAction.AdminMenu },
                { '0', PlayerAction.Exit },
            }
        };

        public static Menu PlayerMenu = new Menu()
        {
            MenuName = "PlayerMenu",
            MenuTitle = "Traveler Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.PlayerInfo },
                { '2', PlayerAction.Inventory },
                { '3', PlayerAction.LocationsVisited },
                { '0', PlayerAction.ReturnToMainMenu },
            }
        };

        public static Menu ObjectMenu = new Menu()
        {
            MenuName = "ObjectMenu",
            MenuTitle = "Object Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.LookAt },
                { '2', PlayerAction.PickUp },
                { '3', PlayerAction.PutDown },
                { '0', PlayerAction.ReturnToMainMenu },
            }
        };

        public static Menu NPCMenu = new Menu()
        {
            MenuName = "NPCMenu",
            MenuTitle = "NPC Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
            {
                { '1', PlayerAction.TalkTo },
                { '2', PlayerAction.LookAtNPC},
                { '3', PlayerAction.Suplex},
                { '0', PlayerAction.ReturnToMainMenu },
            }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.ListLocations },
                    { '2', PlayerAction.ListGameObjects},
                    { '3', PlayerAction.ListNonPlayerCharacters},
                    { '0', PlayerAction.ReturnToMainMenu }
                }
        };

        public enum CurrentMenu
        {
            MissionIntro,
            InitializeMission,
            MainMenu,
            ObjectMenu,
            NPCMenu,
            PlayerMenu,
            AdminMenu
        }

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

        //public static Menu ManagePlayer = new Menu()
        //{
        //    MenuName = "ManagePlayer",
        //    MenuTitle = "Manage Player",
        //    MenuChoices = new Dictionary<char, PlayerAction>()
        //            {
        //                PlayerAction.QuestSetup,
        //                PlayerAction.PlayerInfo,
        //                PlayerAction.Exit
        //            }
        //};
    }
}
