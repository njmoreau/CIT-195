using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        //Enums
        private enum ViewStatus
        {
            PlayerInitialization,
            PlayingGame
        }

        #region FIELDS

        // declare game objects for the ConsoleView object to use
        Player _gamePlayer;
        Universe _gameUniverse;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gamePlayer, Universe gameUniverse)
        {
            _gamePlayer = gamePlayer;
            _gameUniverse = gameUniverse;

            _viewStatus = ViewStatus.PlayerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public PlayerAction GetActionMenuChoice(Menu menu)
        {
            PlayerAction choosenAction = PlayerAction.None;
            Console.CursorVisible = false;

            //
            // create an array of valid keys from menu dictionary
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            //
            // Validate key pressed as in MenuChoices dictionary
            //
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
                keyPressed = keyPressedInfo.KeyChar;

            } while (!validKeys.Contains(keyPressed));

            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            //validate on range if min and max are not 0
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }
            Console.CursorVisible = false;

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.RaceType GetRace()
        {
            Character.RaceType raceType;
            Enum.TryParse<Character.RaceType>(Console.ReadLine(), out raceType);

            return raceType;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @"      _____ _            ___________    _____                 _          ");
            Console.WriteLine(tabSpace + @"     |_   _| |          |_   _| ___ \  |  _  |               | |         ");
            Console.WriteLine(tabSpace + @" ______| | | |__   ___    | | | |_/ /  | | | |_   _  ___  ___| |_ ______ ");
            Console.WriteLine(tabSpace + @"|______| | | '_ \ / _ \   | | | ___ \  | | | | | | |/ _ \/ __| __|______|");
            Console.WriteLine(tabSpace + @"       | | | | | |  __/   | |_| |_/ /  \ \/' / |_| |  __/\__ \ |_        ");
            Console.WriteLine(tabSpace + @"       \_/ |_| |_|\___|   \_(_)____(_)  \_/\_\\__,_|\___||___/\__|      ");
            Console.WriteLine(tabSpace + @"                                                                        ");

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "The T.B. Quest";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, PlayerAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != PlayerAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            // display the outline for the status box
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            // display the text for the status box if playing game
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                // display status box header with title
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                // display stats
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gamePlayer, _gameUniverse))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                // display status box header without header
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>villager object with all properties updated</returns>
        public Player GetInitialPlayerInfo()
        {
            Player villager = new Player();

            //
            // intro
            //
            DisplayGamePlayScreen("Quest Initialization", Text.InitializeQuestIntro(), ActionMenu.QuestIntro, "");
            GetContinueKey();

            //
            // get villager's name
            //
            DisplayGamePlayScreen("Quest Initialization - Name", Text.InitializeQuestGetPlayerName(), ActionMenu.QuestIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            villager.Name = GetString();

            //
            // get villager's age
            //
            DisplayGamePlayScreen("Quest Initialization - Age", Text.InitializeQuestGetPlayerAge(villager), ActionMenu.QuestIntro, "");
            int gamePlayerAge;

            GetInteger($"Enter your age {villager.Name}: ", 0, 1000000, out gamePlayerAge);
            villager.Age = gamePlayerAge;

            //
            // get villager's race
            //
            DisplayGamePlayScreen("Quest Initialization - Race", Text.InitializeQuestGetPlayerRace(villager), ActionMenu.QuestIntro, "");
            DisplayInputBoxPrompt($"Enter your race {villager.Name}: ");
            villager.Race = GetRace();

            //
            // AION SPRINT 1
            //
            // get villager's home kingdom
            //
            DisplayGamePlayScreen("Quest Initialization - Home Kingdom", Text.InitializeQuestGetPlayerHomeKingdom(villager.Name), ActionMenu.QuestIntro, "");
            DisplayInputBoxPrompt("Enter your home kingdom: ");
            villager.HomeKingdom = GetString();

            //
            // echo the villager's info
            //
            DisplayGamePlayScreen("Quest Initialization - Complete", Text.InitializeQuestEchoPlayerInfo(villager), ActionMenu.QuestIntro, "");
            GetContinueKey();

            // 
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;

            return villager;
        }

        #region ----- display responses to menu action choices -----

        public void DisplayPlayerInfo()
        {
            DisplayGamePlayScreen("Player Information", Text.PlayerInfo(_gamePlayer), ActionMenu.PlayerMenu, "");
        }

        public void DisplayLookAround()
        {
            //get current location
            Location currentLocation = _gameUniverse.GetLocationByID(_gamePlayer.LocationID);

            //get list of game objects in current location
            List<GameObject> gameObjectsInCurrentLocation = _gameUniverse.GetGameObjectByLocationID(_gamePlayer.LocationID);

            // get list of NPCs in current space-time location
            List<NPC> npcsInCurrentLocation = _gameUniverse.GetNPCsByLocationID(_gamePlayer.LocationID);

            string messageBoxText = Text.LookAround(currentLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.GameObjectsChooseList(gameObjectsInCurrentLocation) + Environment.NewLine;
            messageBoxText += Text.NPCsChooseList(npcsInCurrentLocation);

            DisplayGamePlayScreen("Current Location", messageBoxText, ActionMenu.MainMenu, "");
        }

        public void DisplayInventory()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gamePlayer.Inventory), ActionMenu.PlayerMenu, "");
        }

        public int DisplayGetPlayerObjectToPickUp()
        {
            int gameObjectID = 0;
            bool validGameObjectID = false;

            //get list of player obj in current location
            List<PlayerObject> playerObjectsInLocation = _gameUniverse.GetPlayerObjectByLocationID(_gamePlayer.LocationID);

            if (playerObjectsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Game Object", Text.GameObjectsChooseList(playerObjectsInLocation), ActionMenu.ObjectMenu, "");

                while (!validGameObjectID)
                {
                    //get int from user
                    GetInteger($"Enter the ID number of the object you wish to add to your inventory: ", 0, 0, out gameObjectID);

                    //validate int as valid game obj id an in current location
                    if (_gameUniverse.IsValidPlayerObjectByLocationId(gameObjectID, _gamePlayer.LocationID))
                    {
                        PlayerObject playerObject = _gameUniverse.GetGameObjectByID(gameObjectID) as PlayerObject;
                        if (playerObject.CanInventory)
                        {
                            validGameObjectID = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("You cannot add that item to your inventory. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you have entered an invalid ID. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no game objects here.", ActionMenu.ObjectMenu, "");
            }

            return gameObjectID;
        }

        public void DisplayConfirmPlayerObjectAddedToInventory(PlayerObject objectAddedToInventory)
        {
            DisplayGamePlayScreen("Pick Up Game Object", $"The {objectAddedToInventory.Name} has been added to your inventory.", ActionMenu.ObjectMenu, "");
        }

        public int DisplayGetInventoryObjectToPutDown()
        {
            int playerObjectID = 0;
            bool validInventoryObjectID = false;

            if (_gamePlayer.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Game Object", Text.GameObjectsChooseList(_gamePlayer.Inventory), ActionMenu.ObjectMenu, "");

                while (!validInventoryObjectID)
                {
                    //get int from user
                    GetInteger($"Enter the ID of the object you wish to remove from your inventory: ", 0, 0, out playerObjectID);

                    //find obj in inventory
                    PlayerObject objectToPutDown = _gamePlayer.Inventory.FirstOrDefault(o => o.ID == playerObjectID);

                    //validate obj in inventory
                    if (objectToPutDown != null)
                    {
                        validInventoryObjectID = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered the ID of an object not in your inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no game objects currently in your inventory.", ActionMenu.ObjectMenu, "");
            }

            return playerObjectID;
        }

        public int DisplayGetNPCToTalkTo()
        {
            int npcId = 0;
            bool validNPCId = false;

            // get a list of NPCs in the current space-time location
            List<NPC> npcsInLocation = _gameUniverse.GetNPCsByLocationID(_gamePlayer.LocationID);

            if (npcsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose Character to Speak With", Text.NPCsChooseList(npcsInLocation), ActionMenu.NPCMenu, "");

                while (!validNPCId)
                {
                    // get an integer from the player
                    GetInteger($"Enter the ID number of the character you wish to speak with: ", 0, 0, out npcId);

                    // validate integer as a valid NPC id and in current location
                    if (_gameUniverse.IsValidNPCByLocationID(npcId, _gamePlayer.LocationID))
                    {
                        NPC npc = _gameUniverse.GetNPCByID(npcId);
                        if (npc is ISpeak)
                        {
                            validNPCId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears this character has nothing to say. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid NPC id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Choose Character to Speak With", "It appears there are no NPCs here.", ActionMenu.NPCMenu, "");
            }

            return npcId;
        }

        public int DisplayGetNPCToLookAt()
        {
            int npcId = 0;
            bool validNPCId = false;

            // get a list of NPCs in the current space-time location
            List<NPC> npcsInLocation = _gameUniverse.GetNPCsByLocationID(_gamePlayer.LocationID);

            if (npcsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose Character to Look At", Text.NPCsChooseList(npcsInLocation), ActionMenu.NPCMenu, "");

                while (!validNPCId)
                {
                    // get an integer from the player
                    GetInteger($"Enter the ID number of the character you wish to look at: ", 0, 0, out npcId);

                    // validate integer as a valid NPC id and in current location
                    if (_gameUniverse.IsValidNPCByLocationID(npcId, _gamePlayer.LocationID))
                    {
                        NPC npc = _gameUniverse.GetNPCByID(npcId);
                        if (npc is ILook)
                        {
                            validNPCId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("Huh... you can't see that NPC. Please look again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid NPC ID. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Choose Character to Look at", "It appears there are no NPCs here.", ActionMenu.NPCMenu, "");
            }

            return npcId;
        }

        public int DisplayGetNPCToSuplex()
        {
            int npcId = 0;
            bool validNPCId = false;

            // get a list of NPCs in the current space-time location
            List<NPC> npcsInLocation = _gameUniverse.GetNPCsByLocationID(_gamePlayer.LocationID);

            if (npcsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose which character's day to ruin", Text.NPCsChooseList(npcsInLocation), ActionMenu.NPCMenu, "");

                while (!validNPCId)
                {
                    // get an integer from the player
                    GetInteger($"Enter the ID number of the character you wish to say goodnight to: ", 0, 0, out npcId);

                    // validate integer as a valid NPC id and in current location
                    if (_gameUniverse.IsValidNPCByLocationID(npcId, _gamePlayer.LocationID))
                    {
                        NPC npc = _gameUniverse.GetNPCByID(npcId);
                        if (npc is ISuplex)
                        {
                            validNPCId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears this character declines your invitation. Try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid NPC id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Choose Character to Suplex", "It appears there are no NPCs here.", ActionMenu.NPCMenu, "");
            }

            return npcId;
        }

        public void DisplayTalkTo(NPC npc)
        {
            ISpeak speakingNPC = npc as ISpeak;

            string message = speakingNPC.Speak();

            DisplayGamePlayScreen("Speak to Character", message, ActionMenu.NPCMenu, "");
        }

        public void DisplayLookAtNPC(NPC npc)
        {
            ILook lookingNPC = npc as ILook;

            string look = lookingNPC.Look();

            DisplayGamePlayScreen("Look at Character", look, ActionMenu.NPCMenu, "");
        }

        public void DisplaySuplexNPC(NPC npc)
        {
            ISuplex suplexingNPC = npc as ISuplex;

            string suplex = suplexingNPC.Suplex();

            DisplayGamePlayScreen("Suplex Character", suplex, ActionMenu.NPCMenu, "");
        }

        public void DisplayConfirmPlayerObjectRemovedFromInventory(PlayerObject objectRemovedFromInventory)
        {
            DisplayGamePlayScreen("Put Down Game Object", $"The {objectRemovedFromInventory.Name} has been removed from your inventory.", ActionMenu.ObjectMenu, "");
        }

        public void DisplayListOfAllNPCObjects()
        {
            DisplayGamePlayScreen("List: NPC Objects", Text.ListAllNPCObjects(_gameUniverse.NPCs), ActionMenu.AdminMenu, "");
        }

        public int DisplayTravel()
        {
            int locationID = 0;
            bool validLocationID = false;

            DisplayGamePlayScreen("Travel", Text.Travel(_gamePlayer, _gameUniverse.Locations), ActionMenu.MainMenu, "");

            while (!validLocationID)
            {
                //
                // get int from player
                //
                GetInteger($"Enter your new location {_gamePlayer.Name}: ", 1, _gameUniverse.GetMaxLocationId(), out locationID);

                //
                // validate integer as a valid location id and determine accessability
                //
                if (_gameUniverse.IsValidLocationId(locationID))
                {
                    if (_gameUniverse.IsAccessibleLocation(locationID))
                    {
                        validLocationID = true;
                    }

                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("You can't travel there currently. Pick a different location");
                    }
                }

                else
                {
                    DisplayInputErrorMessage("You have entered an invalid ID. Please try again.");
                }
            }

            return locationID;
        }

        public void DisplayLocationsVisited()
        {
            //generate list of locations visited
            List<Location> visitedLocations = new List<Location>();
            foreach (int locationID in _gamePlayer.LocationsVisited)
            {
                visitedLocations.Add(_gameUniverse.GetLocationByID(locationID));
            }

            DisplayGamePlayScreen("Locations Visited", Text.VisitedLocations(visitedLocations), ActionMenu.PlayerMenu, "");
        }

        public void DisplayListOfLocations()
        {
            DisplayGamePlayScreen("List: Locations", Text.ListLocations(_gameUniverse.Locations), ActionMenu.AdminMenu, "");
        }

        public void DisplayListOfAllGameObjects()
        {
            DisplayGamePlayScreen("List: Game Objects", Text.ListAllGameObjects(_gameUniverse.GameObjects), ActionMenu.AdminMenu, "");
        }

        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.ObjectMenu, "");
        }

        public int DisplayGetGameObjectToLookAt()
        {
            int gameObjectID = 0;
            bool validGameObjectID = false;

            //get list of obj with current location
            List<GameObject> gameObjectsInLocation = _gameUniverse.GetGameObjectByLocationID(_gamePlayer.LocationID);

            if (gameObjectsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at an Object", Text.GameObjectsChooseList(gameObjectsInLocation), ActionMenu.ObjectMenu, "");

                while (!validGameObjectID)
                {
                    //get int from player
                    GetInteger($"Enter the ID number of the object you wish to look at: ", 0, 0, out gameObjectID);

                    //validate int as valid game object id and in current location
                    if (_gameUniverse.IsValidGameObjectByLocationId(gameObjectID, _gamePlayer.LocationID))
                    {
                        validGameObjectID = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appear you entered an invalid object ID. Please try again.");
                    }
                }
            }

            else
            {
                DisplayGamePlayScreen("Look at an Object", "It appears there are no objects here.", ActionMenu.ObjectMenu, "");
            }

            return gameObjectID;
        }



        #endregion

        #endregion
    }
}
