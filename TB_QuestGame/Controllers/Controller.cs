using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Universe _gameUniverse;
        private bool _playingGame;
        private Location _currentLocation;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            // setup all of the objects in the game
            InitializeGame();

            // begins running the application UI
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gamePlayer = new Player();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);
            _playingGame = true;

            //add initial items to player inventory
            _gamePlayer.Inventory.Add(_gameUniverse.GetGameObjectByID(8) as PlayerObject);
            _gamePlayer.Inventory.Add(_gameUniverse.GetGameObjectByID(9) as PlayerObject);

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction playerActionChoice = PlayerAction.None;

            // display splash screen
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            // player chooses to quit
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            // display introductory message
            _gameConsoleView.DisplayGamePlayScreen("Quest Intro", Text.QuestIntro(), ActionMenu.QuestIntro, "");
            _gameConsoleView.GetContinueKey();

            // initialize the Quest player
            InitializeQuest();

            // prepare game play screen
            _currentLocation = _gameUniverse.GetLocationByID(_gamePlayer.LocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

            // game loop
            while (_playingGame)
            {
                // process flags, events, stats
                UpdateGameStatus();

                // get next game action from player
                playerActionChoice = GetNextPlayerAction();

                // choose an action based on the user's menu choice
                switch (playerActionChoice)
                {
                    case PlayerAction.None:
                        break;

                    case PlayerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;

                    case PlayerAction.PlayerMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.PlayerMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Player Menu", "Select an operation from the menu.", ActionMenu.PlayerMenu, "");
                        break;

                    case PlayerAction.ObjectMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ObjectMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Object Menu", "Select an operation from the menu.", ActionMenu.ObjectMenu, "");
                        break;

                    case PlayerAction.NonPlayerCharacterMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NPCMenu;
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu.", ActionMenu.NPCMenu, "");
                        break;

                    case PlayerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPlayerInfo();
                        break;

                    case PlayerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case PlayerAction.PickUp:
                        PickUpAction();
                        break;

                    case PlayerAction.PutDown:
                        PutDownAction();
                        break;

                    case PlayerAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        break;

                    case PlayerAction.Travel:
                        // get new location choice and update current location property
                        _gamePlayer.LocationID = _gameConsoleView.DisplayTravel();
                        _currentLocation = _gameUniverse.GetLocationByID(_gamePlayer.LocationID);

                        // set the game play screen to the current location info format
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case PlayerAction.LocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;

                    case PlayerAction.LookAt:
                        LookAtAction();
                        break;

                    case PlayerAction.TalkTo:
                        TalkToAction();
                        break;

                    case PlayerAction.LookAtNPC:
                        LookAtNPCAction();
                        break;

                    case PlayerAction.Suplex:
                        SuplexAction();
                        break;

                    case PlayerAction.ListLocations:
                        _gameConsoleView.DisplayListOfLocations();
                        break;

                    case PlayerAction.ListNonPlayerCharacters:
                        _gameConsoleView.DisplayListOfAllNPCObjects();
                        break;

                    case PlayerAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case PlayerAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeQuest()
        {
            Player player = _gameConsoleView.GetInitialPlayerInfo();

            _gamePlayer.Name = player.Name;
            _gamePlayer.Age = player.Age;
            _gamePlayer.Race = player.Race;
            _gamePlayer.LocationID = 1;

            _gamePlayer.ExpPoints = 0;
            _gamePlayer.HitPoints = 100;
            _gamePlayer.Lives = 3;

            //
            // AION SPRINT 1
            //
            _gamePlayer.HomeKingdom = player.HomeKingdom;
        }

        private PlayerAction GetNextPlayerAction()
        {
            PlayerAction playerActionChoice = PlayerAction.None;

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MainMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;

                case ActionMenu.CurrentMenu.ObjectMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ObjectMenu);
                    break;

                case ActionMenu.CurrentMenu.NPCMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.NPCMenu);
                    break;

                case ActionMenu.CurrentMenu.PlayerMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.PlayerMenu);
                    break;

                case ActionMenu.CurrentMenu.AdminMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;

                default:
                    break;
            }

            return playerActionChoice;
        }

        private void LookAtAction()
        {
            //display list of player obj in location and get player choice
            int gameObjectToLookAtID = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //display game obj info
            if (gameObjectToLookAtID != 0)
            {
                //get game obj from universe
                GameObject gameObject = _gameUniverse.GetGameObjectByID(gameObjectToLookAtID);

                //display info for obj chosen
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }

        private void PickUpAction()
        {
            //display list of player obj in location and get user choice
            int playerObjectToPickUpID = _gameConsoleView.DisplayGetPlayerObjectToPickUp();

            //add the player obj to player's inventory
            if (playerObjectToPickUpID != 0)
            {
                //get game obj from universe
                PlayerObject playerObject = _gameUniverse.GetGameObjectByID(playerObjectToPickUpID) as PlayerObject;

                //note: player obj is added to list and the location is set to 0
                _gamePlayer.Inventory.Add(playerObject);
                playerObject.LocationID = 0;

                //display confirmation message
                _gameConsoleView.DisplayConfirmPlayerObjectAddedToInventory(playerObject);
            }
        }

        private void PutDownAction()
        {
            //display list of player obj in inventory and get a player choice
            int inventoryObjectToPutDownID = _gameConsoleView.DisplayGetInventoryObjectToPutDown();
            if (inventoryObjectToPutDownID != 0)
            {
                PlayerObject playerObject = _gameUniverse.GetGameObjectByID(inventoryObjectToPutDownID) as PlayerObject;

                //remove obj from inventory and set location ID to current value
                _gamePlayer.Inventory.Remove(playerObject);
                playerObject.LocationID = _gamePlayer.LocationID;

                //display confirm message
                _gameConsoleView.DisplayConfirmPlayerObjectRemovedFromInventory(playerObject);
            }
            //get the game obj from universe
            
        }

        private void TalkToAction()
        {
            // display a list of NPCs in space-time location and get a player choice
            int npcToTalkToID = _gameConsoleView.DisplayGetNPCToTalkTo();

            // display NPC's message
            if (npcToTalkToID != 0)
            {
                // get the NPC from the universe
                NPC npc = _gameUniverse.GetNPCByID(npcToTalkToID);

                // display information for the object chosen
                _gameConsoleView.DisplayTalkTo(npc);
            }
        }

        private void LookAtNPCAction()
        {
            // display a list of NPCs in space-time location and get a player choice
            int npcToLookAtID = _gameConsoleView.DisplayGetNPCToLookAt();

            // display NPC's message
            if (npcToLookAtID != 0)
            {
                // get the NPC from the universe
                NPC npc = _gameUniverse.GetNPCByID(npcToLookAtID);

                // display information for the object chosen
                _gameConsoleView.DisplayLookAtNPC(npc);
            }
        }

        private void SuplexAction()
        {
            // display a list of NPCs in space-time location and get a player choice
            int npcToSuplexID = _gameConsoleView.DisplayGetNPCToSuplex();

            // display NPC's message
            if (npcToSuplexID != 0)
            {
                // get the NPC from the universe
                NPC npc = _gameUniverse.GetNPCByID(npcToSuplexID);

                // display information for the object chosen
                _gameConsoleView.DisplaySuplexNPC(npc);
            }
        }

        private void UpdateGameStatus()
        {
            if (!_gamePlayer.HasVisited(_currentLocation.LocationID))
            {
                //add new location to the list of visited locations if first visit
                _gamePlayer.LocationsVisited.Add(_currentLocation.LocationID);

                //update exp for visiting locations
                _gamePlayer.ExpPoints += _currentLocation.ExperiencePoints;
            }
        }

        #endregion
    }
}
