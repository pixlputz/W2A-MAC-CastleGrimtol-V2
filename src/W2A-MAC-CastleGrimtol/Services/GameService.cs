using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Providers;
using W2A_MAC_CastleGrimtol.Utils;


namespace W2A_MAC_CastleGrimtol.Services
{

    //2018-05-15: Update: Working to Revamp Service class to consolidate original method logic...
    //Accomplished a lot, but still have areas that could be improved.

    public class GameService
    {
        private GameProvider _gp = new GameProvider();

        public bool Running { get; private set; }
        private bool InGame { get; set; }
        private bool InRoom1 { get; set; }
        private bool InRoom2 { get; set; }
        private bool InRoom3 { get; set; }
        private bool InRoom4 { get; set; }
        private bool InRoom1Look { get; set; }
        private bool InRoom2Look { get; set; }
        private bool InRoom3Look { get; set; }
        private bool InRoom4Look { get; set; }
        private bool InRoom1Help { get; set; }
        private bool InRoom2Help { get; set; }
        private bool InRoom3Help { get; set; }
        private bool InRoom4Help { get; set; }
        private bool InRoom1Take { get; set; }
        private bool InRoom2Take { get; set; }
        private bool InRoom3Take { get; set; }
        private bool InRoom4Take { get; set; }
        private bool InRoom1Complete { get; set; }
        private bool InRoom2Complete { get; set; }
        private bool InRoom3Complete { get; set; }
        private bool InRoom4Complete { get; set; }
        private bool InRoom2Submit { get; set; }
        private bool InRoom3Submit { get; set; }
        private bool InRoom4Submit { get; set; }
        private bool InInventory { get; set; }
        private bool InResult { get; set; }
        private Menu MainMenu { get; set; }
        private Menu Room1Menu { get; set; }
        private Menu Room2Menu { get; set; }
        private Menu Room3Menu { get; set; }
        private Menu Room4Menu { get; set; }


        public GameService()
        {
            Running = true;
            BuildMainMenu();
        }

        public void DisplayGameIntro()
        {
            var gameInfo = _gp.GetGameInfo();

            Globals.Clear();
            Globals.BlankLine();
            Globals.Write("*************************************************", true);
            Console.Write("     ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*         Welcome to: " + gameInfo.Title + "              *");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Globals.Write("*************************************************", true);
            Globals.Write("         Version: " + gameInfo.Version + "       ", true);
            Globals.Write("         Developer: " + gameInfo.Developer + "       ", true);
            Globals.Write("         Last Update: " + gameInfo.DateLastUpdated + "       ", true);
            Globals.Write("-------------------------------------------------", true);
            Globals.Write("Today's Date/Time: " + DateTime.Now.ToString(), true);
            Globals.Write("", true);
            foreach (string line in gameInfo.Description)
            {
                Globals.Write(line, true);
            }
            Globals.BlankLine();
            Globals.Write("Are you ready to play?!", true);
            Globals.BlankLine();
            Console.Beep(1000, 1000 / 4);
            Console.Beep(1500, 1000 / 5);

            MainMenuSelection();
        }

        private void MainMenuSelection()
        {
            Action action = MainMenu.SelectOption();
            if (action != null)
            {
                action.Invoke();
            }
        }

        private void Room1MenuSelection()
        {
            Action action = Room1Menu.SelectOption();
            if (action != null)
            {
                action.Invoke();
            }
        }

        private void Room2MenuSelection()
        {
            Action action = Room2Menu.SelectOption();
            if (action != null)
            {
                action.Invoke();
            }
        }

        private void Room3MenuSelection()
        {
            Action action = Room3Menu.SelectOption();
            if (action != null)
            {
                action.Invoke();
            }
        }

        private void Room4MenuSelection()
        {
            Action action = Room4Menu.SelectOption();
            if (action != null)
            {
                action.Invoke();
            }
        }

        void BuildMainMenu()
        {
            MainMenu = new Menu(
               "Main Menu",
               new List<MenuOption>
               {
               new MenuOption(moSelectPlay, "Yes, I'm in! - Let's Play!"),
               new MenuOption(moSelectExit, "No, sorry; I think I'd rather not: Exit")
               });
        }

        void BuildRoom1Menu()
        {
            Room1Menu = new Menu(
               "Room 1 Menu",
               new List<MenuOption>
               {
               new MenuOption(moRoom1SelectGo, "Go To Next Room"),
               new MenuOption(moRoom1SelectLook, "Look"),
               new MenuOption(moRoom1SelectHelp, "Help"),
               new MenuOption(moRoom1SelectTake, "Take"),
               new MenuOption(moSelectInventory, "Inventory"),
               new MenuOption(moRoom1SelectComplete, "Complete"),
               new MenuOption(moSelectRestart, "Restart"),
               new MenuOption(moSelectExit, "Quit")
               });
        }

        void BuildRoom2Menu()
        {
            Room2Menu = new Menu(
               "Room 2 Menu",
               new List<MenuOption>
               {
               new MenuOption(moRoom2SelectGo, "Go To Next Room"),
               new MenuOption(moRoom2SelectLook, "Look"),
               new MenuOption(moRoom2SelectHelp, "Help"),
               new MenuOption(moRoom2SelectTake, "Take"),
               new MenuOption(moSelectInventory, "Inventory"),
               new MenuOption(moRoom2SelectComplete, "Complete"),
               new MenuOption(moRoom2SelectSubmit, "Submit Item from Previous Office"),
               new MenuOption(moSelectRestart, "Restart"),
               new MenuOption(moSelectExit, "Quit")
               });
        }

        void BuildRoom3Menu()
        {
            Room3Menu = new Menu(
               "Room 3 Menu",
               new List<MenuOption>
               {
               new MenuOption(moRoom3SelectGo, "Go To Next Room"),
               new MenuOption(moRoom3SelectLook, "Look"),
               new MenuOption(moRoom3SelectHelp, "Help"),
               new MenuOption(moRoom3SelectTake, "Take"),
               new MenuOption(moSelectInventory, "Inventory"),
               new MenuOption(moRoom3SelectComplete, "Test Item"),
               new MenuOption(moRoom3SelectSubmit, "Submit Item from Previous Office"),
               new MenuOption(moSelectRestart, "Restart"),
               new MenuOption(moSelectExit, "Quit")
               });
        }

        void BuildRoom4Menu()
        {
            Room4Menu = new Menu(
               "Room 4 Menu",
               new List<MenuOption>
               {
               new MenuOption(moRoom4SelectGo, "Submit Last Item On Your Way Out for the Day!"),
               new MenuOption(moRoom4SelectLook, "Look"),
               new MenuOption(moRoom4SelectHelp, "Help"),
               new MenuOption(moRoom4SelectTake, "Take"),
               new MenuOption(moSelectInventory, "Inventory"),
               new MenuOption(moRoom4SelectComplete, "Complete Item"),
               new MenuOption(moRoom4SelectSubmit, "Submit Item from Previous Office"),
               new MenuOption(moSelectRestart, "Restart"),
               new MenuOption(moSelectExit, "Quit")
               });
        }

        private void moSelectPlay()
        {
            BuildRoom1Menu();

            Globals.Clear();
            InRoom1 = true;
            while (InRoom1)
            {
                var gamePlayed = _gp.SetGamePlayedStatus(true);

                //2018-05-15: Update: Now uses a new Provider method to Pull Room info for Game's current room:
                var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());

                Globals.Clear();
                Globals.BlankLine();
                Globals.Write("You have entered the first room...", true);

                //Display Room Objects: Room Name, Room Manager, Manager's Mood, and Room Item:
                Globals.Write("-------------------------------------------------------------", true);
                Globals.Write("|                  " + roomInfo.Name + "                    |", true);
                Globals.Write("|                                                           |", true);
                Globals.Write("|   Office Manager: " + roomInfo.Person.Title + "              |", true);
                Globals.Write("|   Manager's Mood: " + roomInfo.Person.Mood + "                                     |", true);
                Globals.Write("|                                                           |", true);
                Globals.Write("|   Item Available: " + roomInfo.Item.Name + "                      |", true);
                Globals.Write("|                                                           |", true);
                Globals.Write("-------------------------------------------------------------", true);

                //Display Room Feedback:
                Globals.BlankLine();
                foreach (string line in roomInfo.Description)
                {
                    Globals.Write(line, true);
                }

                //Display Room Command Options:
                Globals.BlankLine();
                Room1MenuSelection();
            }
        }

        private void moRoom1SelectGo()
        {
            _gp.ChangeCurrentRoom();
            InRoom1 = false;

            DetermineRoom2ManagerMood();

            BuildRoom2Menu();

            Globals.Clear();
            InRoom2 = true;
            while (InRoom2)
            {
                //2018-05-15: Update: Now uses a new Provider method to Pull Room info for Game's current room:
                var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());

                Globals.Clear();
                Globals.BlankLine();
                Globals.Write("You have entered the second room...", true);

                //Display Room Objects: Room Name, Room Manager, Manager's Mood, and Room Item:
                Globals.Write("-------------------------------------------------------------", true);
                Globals.Write("|                  " + roomInfo.Name + "                    |", true);
                Globals.Write("|   Office Manager: " + roomInfo.Person.Title + "                  |", true);
                if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                {
                    Globals.Write("|   Manager's Mood: " + roomInfo.Person.Mood + "                                     |", true);
                }
                else
                {
                    Globals.Write("|   Manager's Mood: " + roomInfo.Person.Mood + "                                    |", true);
                }
                Globals.Write("|                                                           |", true);
                Globals.Write("|   Item Available: " + roomInfo.Item.Name + "                |", true);
                Globals.Write("|                                                           |", true);
                Globals.Write("-------------------------------------------------------------", true);

                //Display Room Feedback:
                Globals.BlankLine();
                foreach (string line in roomInfo.Description)
                {
                    Globals.Write(line, true);
                }

                //Display Room Command Options:
                Globals.BlankLine();
                Room2MenuSelection();
            }
        }

        //2018-05-16: New Consolidated Method:
        private void SetRoomMood(string strMood)
        {
            //2018-05-15: Update: Now uses a new Provider method to set Room Mood, using Game-State's CurrentRoom:
            _gp.SetRoomPersonMood(strMood);
        }


        private void DetermineRoom2ManagerMood()
        {
            string strMood;

            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());
            var playerInfo = _gp.GetPlayerInfo();

            if (playerInfo.Inventory.Count < 1)
            {
                //No items in inventory; mood is Bad by default:
                strMood = "Bad";
                //2018-05-15: Update: Now uses a new Provider method to set Room Mood, using Game-State's CurrentRoom:
                SetRoomMood(strMood);
            }
            else
            {
                foreach (var item in playerInfo.Inventory)
                {
                    var itemInfo = _gp.GetItemInfo(item);
                    if (itemInfo.Name == "In-Processing Form")
                    {
                        if (itemInfo.Completed == true)
                        {
                            //Item was found in Inventory AND it was Completed! - Yay! = Good Mood:
                            strMood = "Good";
                            //2018-05-15: Update: Now uses a new Provider method to set Room Mood, using Game-State's CurrentRoom:
                            SetRoomMood(strMood);
                        }
                    }
                    //Else: Leave retain original mood (Bad).
                }
            }
        }

        private void DetermineRoom3ManagerMood()
        {
            string strMood;

            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());
            var playerInfo = _gp.GetPlayerInfo();

            if (playerInfo.Inventory.Count < 1)
            {
                //No items in inventory; mood is Bad by default:
                strMood = "Bad";
                //2018-05-15: Update: Now uses a new Provider method to set Room Mood, using Game-State's CurrentRoom:
                SetRoomMood(strMood);
            }
            else
            {
                foreach (var item in playerInfo.Inventory)
                {
                    var itemInfo = _gp.GetItemInfo(item);
                    if (itemInfo.Name == "Policy Agreement Package")
                    {
                        if (itemInfo.Completed == true)
                        {
                            //Item was found in Inventory AND it was Completed! - Yay! = Good Mood:
                            strMood = "Good";
                            //2018-05-15: Update: Now uses a new Provider method to set Room Mood, using Game-State's CurrentRoom:
                            SetRoomMood(strMood);
                        }
                    }
                    //Else: Leave retain original mood (Bad).
                }
            }
        }

        private void DetermineRoom4ManagerMood()
        {
            string strMood;

            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());
            var playerInfo = _gp.GetPlayerInfo();

            if (playerInfo.Inventory.Count < 1)
            {
                //No items in inventory; mood is Bad by default:
                strMood = "Bad";
                //2018-05-15: Update: Now uses a new Provider method to set Room Mood, using Game-State's CurrentRoom:
                SetRoomMood(strMood);
            }
            else
            {
                foreach (var item in playerInfo.Inventory)
                {
                    var itemInfo = _gp.GetItemInfo(item);
                    if (itemInfo.Name == "Building Fob")
                    {
                        if (itemInfo.Completed == true)
                        {
                            //Item was found in Inventory AND it was Completed! - Yay! = Good Mood:
                            strMood = "Good";
                            //2018-05-15: Update: Now uses a new Provider method to set Room Mood, using Game-State's CurrentRoom:
                            SetRoomMood(strMood);
                        }
                    }
                    //Else: Leave retain original mood (Bad).
                }
            }
        }

        private bool DetermineIfPlayerWins()
        {
            bool bolRoom1ItemComplete = false;
            bool bolRoom2ItemComplete = false;
            bool bolRoom3ItemComplete = false;
            bool bolRoom4ItemComplete = false;

            var playerInfo = _gp.GetPlayerInfo();

            foreach (var item in playerInfo.Inventory)
            {
                var itemInfo = _gp.GetItemInfo(item);
                if (itemInfo.Name == "In-Processing Form")
                {
                    if (itemInfo.Completed == true)
                    {
                        bolRoom1ItemComplete = true;
                    }
                }
                if (itemInfo.Name == "Policy Agreement Package")
                {
                    if (itemInfo.Completed == true)
                    {
                        bolRoom2ItemComplete = true;
                    }
                }
                if (itemInfo.Name == "Building Fob")
                {
                    if (itemInfo.Completed == true)
                    {
                        bolRoom3ItemComplete = true;
                    }
                }
                if (itemInfo.Name == "Active Directory Account")
                {
                    if (itemInfo.Completed == true)
                    {
                        bolRoom4ItemComplete = true;
                    }
                }
            }

            if (bolRoom1ItemComplete && bolRoom2ItemComplete && bolRoom3ItemComplete && bolRoom4ItemComplete)
            {
                //All items were completed - Player Wins!
                return true;
            }
            else
            {
                //Something was not completed:
                return false;
            }
        }


        private void moRoom2SelectGo()
        {
            _gp.ChangeCurrentRoom();
            InRoom2 = false;

            DetermineRoom3ManagerMood();

            BuildRoom3Menu();

            Globals.Clear();
            InRoom3 = true;
            while (InRoom3)
            {
                //2018-05-15: Update: Now uses a new Provider method to Pull Room info for Game's current room:
                var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());

                Globals.Clear();
                Globals.BlankLine();
                Globals.Write("You have entered the third room...", true);

                //Display Room Objects: Room Name, Room Manager, Manager's Mood, and Room Item:
                Globals.Write("-------------------------------------------------------------", true);
                Globals.Write("|                  " + roomInfo.Name + "             |", true);
                Globals.Write("|   Office Manager: " + roomInfo.Person.Title + "                   |", true);
                if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                {
                    Globals.Write("|   Manager's Mood: " + roomInfo.Person.Mood + "                                     |", true);
                }
                else
                {
                    Globals.Write("|   Manager's Mood: " + roomInfo.Person.Mood + "                                    |", true);
                }
                Globals.Write("|                                                           |", true);
                Globals.Write("|   Item Available: " + roomInfo.Item.Name + "                            |", true);
                Globals.Write("|                                                           |", true);
                Globals.Write("-------------------------------------------------------------", true);

                //Display Room Feedback:
                Globals.BlankLine();
                foreach (string line in roomInfo.Description)
                {
                    Globals.Write(line, true);
                }

                //Display Room Command Options:
                Globals.BlankLine();
                Room3MenuSelection();
            }
        }

        private void moRoom3SelectGo()
        {
            _gp.ChangeCurrentRoom();
            InRoom3 = false;

            DetermineRoom4ManagerMood();

            BuildRoom4Menu();

            Globals.Clear();
            InRoom4 = true;
            while (InRoom4)
            {
                //2018-05-15: Update: Now uses a new Provider method to Pull Room info for Game's current room:
                var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());

                Globals.Clear();
                Globals.BlankLine();
                Globals.Write("You have entered the fourth and last room...", true);

                //Display Room Objects: Room Name, Room Manager, Manager's Mood, and Room Item:
                Globals.Write("-------------------------------------------------------------", true);
                Globals.Write("|                  " + roomInfo.Name + "                         |", true);
                Globals.Write("|   Office Manager: " + roomInfo.Person.Title + "                                |", true);
                if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                {
                    Globals.Write("|   Manager's Mood: " + roomInfo.Person.Mood + "                                     |", true);
                }
                else
                {
                    Globals.Write("|   Manager's Mood: " + roomInfo.Person.Mood + "                                    |", true);
                }
                Globals.Write("|                                                           |", true);
                Globals.Write("|   Item Available: " + roomInfo.Item.Name + "                |", true);
                Globals.Write("|                                                           |", true);
                Globals.Write("-------------------------------------------------------------", true);

                //Display Room Feedback:
                Globals.BlankLine();
                foreach (string line in roomInfo.Description)
                {
                    Globals.Write(line, true);
                }

                //Display Room Command Options:
                Globals.BlankLine();
                Room4MenuSelection();
            }
        }

        private void moRoom4SelectGo()
        {
            InRoom4 = false;

            //2018-05-16: Updated to consolidate process logic, now using new method version
            //and passing current room from game-state:
            //In this last case, player is leaving the room, so pass that flag to method:
            SubmitRoomItem(true);

            bool bolPlayerWins = DetermineIfPlayerWins();

            Globals.Clear();
            InResult = true;
            while (InResult)
            {
                Globals.Clear();
                Globals.BlankLine();
                Globals.Write("You are now leaving the company at the end of the day...", true);

                //Display Room Objects: Room Name, Room Manager, Manager's Mood, and Room Item:
                Globals.Write("-----------------------------------------------------------------", true);

                if (bolPlayerWins)
                {
                    Globals.BlankLine();
                    Globals.Write("             CONGRATULATIONS! YOU WON THE GAME!", true);
                    Globals.Write("     You've completed all items before the End-of-Day!", true);
                    Globals.Write("The 'New Job, LLC' company welcomes you to return another day.", true);
                    Globals.Write("                     JOB WELL DONE!", true);
                    Globals.BlankLine();
                }
                else
                {
                    Globals.BlankLine();
                    Globals.Write("                 SORRY, YOU'VE BEEN FIRED!", true);
                    Globals.Write("    You failed to complete all items before the End-of-Day!", true);
                    Globals.Write("The 'New Job, LLC' company says, 'Don't bother coming in tomrrow.", true);
                    Globals.Write("                          (SO SAD)", true);
                    Globals.BlankLine();
                }

                Globals.Write("-----------------------------------------------------------------", true);

                //Display Room Command Options:
                Globals.BlankLine();
                Globals.Write("Press any key to continue... > ", false);
                Console.ReadLine();
                InResult = false;
            }
        }

        //2018-05-16: Update: New encapsulated method:
        private void SubmitRoomItem(bool leavingBuilding)
        {
            //2018-05-16: Updated to consolidate process logic, now using new method version
            //and passing current room from game-state:
            _gp.SubmitRoomItem(leavingBuilding);
        }

        private void moRoom1SelectLook()
        {
            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());
            var playerInfo = _gp.GetPlayerInfo();

            Globals.Clear();
            InRoom1Look = true;
            while (InRoom1Look)
            {
                Globals.BlankLine();
                Globals.Write("You look around the room and notice the following:", true);
                Globals.BlankLine();
                Globals.Write("  - This is the Administration Office.", true);
                Globals.Write("  - Managed by an Admin Clerk.", true);

                if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                {
                    Globals.Write("  - The Clerk is in a Bad mood. Don't want to disappoint!", true);
                }
                else
                {
                    Globals.Write("  - The Clerk is in a Good mood - Yay!", true);
                }

                Globals.BlankLine();
                Globals.Write("You are greeted by the manager of the room:", true);
                foreach (string line in roomInfo.Description)
                {
                    Globals.Write(line, true);
                }

                Globals.BlankLine();
                Globals.Write("Press any key to return to the Administration Office... > ", false);
                Console.ReadLine();
                InRoom1Look = false;
            }
        }

        private void moRoom2SelectLook()
        {
            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());
            var playerInfo = _gp.GetPlayerInfo();

            Globals.Clear();
            InRoom2Look = true;
            while (InRoom2Look)
            {
                Globals.BlankLine();
                Globals.Write("You look around the room and notice the following:", true);
                Globals.BlankLine();
                Globals.Write("  - This is the Human Resource Office.", true);
                Globals.Write("  - Managed by the HR Manager.", true);

                if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                {
                    Globals.Write("  - The Manager is in a Bad mood. Don't want to disappoint!", true);
                }
                else
                {
                    Globals.Write("  - The Manager is in a Good mood - Yay!", true);
                }

                Globals.BlankLine();
                Globals.Write("You are greeted by the manager of the room:", true);
                foreach (string line in roomInfo.Description)
                {
                    Globals.Write(line, true);
                }

                Globals.BlankLine();
                Globals.Write("Press any key to return to the HR Office... > ", false);
                Console.ReadLine();
                InRoom2Look = false;
            }
        }

        private void moRoom3SelectLook()
        {
            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());
            var playerInfo = _gp.GetPlayerInfo();

            Globals.Clear();
            InRoom3Look = true;
            while (InRoom3Look)
            {
                Globals.BlankLine();
                Globals.Write("You look around the room and notice the following:", true);
                Globals.BlankLine();
                Globals.Write("  - This is your Department Supervisor's Office.", true);
                Globals.Write("  - Managed by your Supervisor.", true);

                if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                {
                    Globals.Write("  - Your Supervisor is in a Bad mood. Don't want to disappoint!", true);
                }
                else
                {
                    Globals.Write("  - Your Supervisor is in a Good mood - Yay!", true);
                }

                Globals.BlankLine();
                Globals.Write("You are greeted by your Department Supervisor:", true);
                foreach (string line in roomInfo.Description)
                {
                    Globals.Write(line, true);
                }

                Globals.BlankLine();
                Globals.Write("Press any key to return to the HR Office... > ", false);
                Console.ReadLine();
                InRoom3Look = false;
            }
        }

        private void moRoom4SelectLook()
        {
            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());
            var playerInfo = _gp.GetPlayerInfo();

            Globals.Clear();
            InRoom4Look = true;
            while (InRoom4Look)
            {
                Globals.BlankLine();
                Globals.Write("You look around the room and notice the following:", true);
                Globals.BlankLine();
                Globals.Write("  - This is your new Work Area Office", true);
                Globals.Write("  - You see that your new Coworker is hard at work.", true);

                if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                {
                    Globals.Write("  - Your Coworker is in a Bad mood. Don't want to disappoint!", true);
                }
                else
                {
                    Globals.Write("  - Your Coworker is in a Good mood - Yay!", true);
                }

                Globals.BlankLine();
                Globals.Write("You are greeted by your new Coworker:", true);
                foreach (string line in roomInfo.Description)
                {
                    Globals.Write(line, true);
                }

                Globals.BlankLine();
                Globals.Write("Press any key to return to your new Work Area... > ", false);
                Console.ReadLine();
                InRoom4Look = false;
            }
        }

        private void moRoom1SelectHelp()
        {
            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());

            Globals.Clear();
            InRoom1Help = true;
            while (InRoom1Help)
            {
                Globals.BlankLine();
                Globals.Write("Intent is to Take the Item available in the room, Complete it,", true);
                Globals.Write("then Submit it to the next Office's Manager.", true);
                Globals.Write("Be careful! If you do not Complete the item before", true);
                Globals.Write("Submitting it, you may be fired before you're hired!", true);

                Globals.BlankLine();
                Globals.Write("Press any key to return to the Administration Office... > ", false);
                Console.ReadLine();
                InRoom1Help = false;
            }
        }

        private void moRoom2SelectHelp()
        {
            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());

            Globals.Clear();
            InRoom2Help = true;
            while (InRoom2Help)
            {
                Globals.BlankLine();
                Globals.Write("Intent is to Submit the Item Obtained from the Previous room,", true);
                Globals.Write("then Take the Item available in this room, Complete it,", true);
                Globals.Write("then Submit it to the next Office's Manager.", true);
                Globals.Write("Be careful! If you do not Complete items before", true);
                Globals.Write("Submitting them, you may be fired before you're hired!", true);

                Globals.BlankLine();
                Globals.Write("Press any key to return to the HR Office... > ", false);
                Console.ReadLine();
                InRoom2Help = false;
            }
        }

        private void moRoom3SelectHelp()
        {
            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());

            Globals.Clear();
            InRoom3Help = true;
            while (InRoom3Help)
            {
                Globals.BlankLine();
                Globals.Write("Intent is to Submit the Item Obtained from the Previous room,", true);
                Globals.Write("then Take the Item available in this room, Test it,", true);
                Globals.Write("then Submit it to the next Office.", true);
                Globals.Write("Be careful! If you do not Complete items before", true);
                Globals.Write("Submitting them, you may be fired before you're hired!", true);

                Globals.BlankLine();
                Globals.Write("Press any key to return to your Department Supervisor Office... > ", false);
                Console.ReadLine();
                InRoom3Help = false;
            }
        }

        private void moRoom4SelectHelp()
        {
            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());

            Globals.Clear();
            InRoom4Help = true;
            while (InRoom4Help)
            {
                Globals.BlankLine();
                Globals.Write("Intent is to Submit the Item Obtained from the Previous room,", true);
                Globals.Write("then Take the Item available in this room and Complete it.", true);
                Globals.Write("Be careful! If you do not Complete all items before", true);
                Globals.Write("you leave for the day, you may be fired before you're hired!", true);

                Globals.BlankLine();
                Globals.Write("Press any key to return to your Work Area... > ", false);
                Console.ReadLine();
                InRoom4Help = false;
            }
        }

        private void moRoom1SelectTake()
        {
            Globals.Clear();
            InRoom1Take = true;
            while (InRoom1Take)
            {
                //Player Takes Item and adds to Inventory:
                //2018-05-16: Updated to consolidate process logic:
                _gp.AddRoomItemToInventory();

                Globals.BlankLine();
                Globals.Write("You have just accepted the In-Processing Form.", true);
                Globals.Write("This item has been added to your Inventory.", true);
                Globals.BlankLine();
                Globals.Write("Press any key to continue... > ", false);
                Console.ReadLine();
                InRoom1Take = false;
            }
        }

        private void moRoom2SelectTake()
        {
            Globals.Clear();
            InRoom2Take = true;
            while (InRoom2Take)
            {
                //Player Takes Item and adds to Inventory:
                //2018-05-16: Updated to consolidate process logic:
                _gp.AddRoomItemToInventory();

                Globals.BlankLine();
                Globals.Write("You have just accepted the Policy Agreement Package.", true);
                Globals.Write("This item has been added to your Inventory.", true);
                Globals.BlankLine();
                Globals.Write("Press any key to continue... > ", false);
                Console.ReadLine();
                InRoom2Take = false;
            }
        }

        private void moRoom3SelectTake()
        {
            Globals.Clear();
            InRoom3Take = true;
            while (InRoom3Take)
            {
                //Player Takes Item and adds to Inventory:
                //2018-05-16: Updated to consolidate process logic:
                _gp.AddRoomItemToInventory();

                Globals.BlankLine();
                Globals.Write("You have just accepted your new Building Fob.", true);
                Globals.Write("This item has been added to your Inventory.", true);
                Globals.Write("Don't forget to test it before the end-of-day!", true);
                Globals.BlankLine();
                Globals.Write("Press any key to continue... > ", false);
                Console.ReadLine();
                InRoom3Take = false;
            }
        }

        private void moRoom4SelectTake()
        {
            Globals.Clear();
            InRoom4Take = true;
            while (InRoom4Take)
            {
                //Player Takes Item and adds to Inventory:
                //2018-05-16: Updated to consolidate process logic:
                _gp.AddRoomItemToInventory();

                Globals.BlankLine();
                Globals.Write("You have just accepted the task of building your AD Account.", true);
                Globals.Write("This item has been added to your Inventory.", true);
                Globals.Write("Don't forget to Complete it before the end-of-day!", true);
                Globals.BlankLine();
                Globals.Write("Press any key to continue... > ", false);
                Console.ReadLine();
                InRoom4Take = false;
            }
        }

        private void moSelectInventory()
        {
            var playerInfo = _gp.GetPlayerInfo();

            Globals.Clear();
            InInventory = true;
            while (InInventory)
            {
                Globals.BlankLine();

                if (playerInfo.Inventory.Count < 1)
                {
                    Globals.Write("You Currently Have Zero Items in Your Inventory.", true);
                }
                else
                {
                    Globals.Write("Your Item Inventory:", true);
                    foreach (var item in playerInfo.Inventory)
                    {
                        var itemInfo = _gp.GetItemInfo(item);
                        string strCompleted = "";
                        string strSubmitted = "";

                        if (itemInfo.Completed)
                        {
                            strCompleted = "Completed";
                        }
                        else
                        {
                            strCompleted = "Incomplete";
                        }
                        if (itemInfo.Submitted)
                        {
                            strSubmitted = "Submitted";
                        }
                        else
                        {
                            strSubmitted = "Not Yet Submitted";
                        }

                        Globals.Write(" * Item: " + itemInfo.Name + "; " + strCompleted + "; " + strSubmitted, true);
                    }
                }
                Globals.BlankLine();
                Globals.Write("Press any key to continue... > ", false);
                Console.ReadLine();
                InInventory = false;
            }
        }

        private void CompleteItem()
        {
            //2018-05-16: Updated to consolidate process logic:
            _gp.CompleteRoomItem();
        }


        private void moRoom1SelectComplete()
        {
            var playerInfo = _gp.GetPlayerInfo();

            Globals.Clear();
            InRoom1Complete = true;
            while (InRoom1Complete)
            {
                bool FoundItemInInventory = false;
                //Verify Player Has Item in Inventory:
                if (playerInfo.Inventory.Count > 0)
                {
                    foreach (var item in playerInfo.Inventory)
                    {
                        var itemInfo = _gp.GetItemInfo(item);
                        if (itemInfo.Name == "In-Processing Form")
                        {
                            FoundItemInInventory = true;
                        }
                    }
                    if (FoundItemInInventory)
                    {
                        //2018-05-16: Updated to consolidate process logic:
                        CompleteItem();

                        Globals.BlankLine();
                        Globals.Write("You have just completed filling out the In-Processing Form.", true);
                        Globals.Write("This item has been marked Complete in your Inventory.", true);
                        Globals.BlankLine();
                        Globals.Write("Press any key to continue... > ", false);
                        Console.ReadLine();
                        InRoom1Complete = false;
                    }
                    if (!FoundItemInInventory)
                    {
                        //Item Not Found in Inventory:
                        Globals.BlankLine();
                        Globals.Write("An In-Processing Form is not yet in your Inventory.", true);
                        Globals.Write("This item has not yet been picked up or completed.", true);
                        Globals.BlankLine();
                        Globals.Write("Press any key to continue... > ", false);
                        Console.ReadLine();
                        InRoom1Complete = false;
                    }
                }
                else
                {
                    //No Items in Inventory to Complete:
                    Globals.BlankLine();
                    Globals.Write("There are no Items in your Inventory yet.", true);
                    Globals.Write("Please pick up an Item first, then Complete it.", true);
                    Globals.BlankLine();
                    Globals.Write("Press any key to continue... > ", false);
                    Console.ReadLine();
                    InRoom1Complete = false;
                }
            }
        }

        private void moRoom2SelectComplete()
        {
            var playerInfo = _gp.GetPlayerInfo();

            Globals.Clear();
            InRoom2Complete = true;
            while (InRoom2Complete)
            {
                bool FoundItemInInventory = false;
                //Verify Player Has Item in Inventory:
                if (playerInfo.Inventory.Count > 0)
                {
                    foreach (var item in playerInfo.Inventory)
                    {
                        var itemInfo = _gp.GetItemInfo(item);
                        if (itemInfo.Name == "Policy Agreement Package")
                        {
                            FoundItemInInventory = true;
                        }
                    }
                    if (FoundItemInInventory)
                    {
                        //2018-05-16: Updated to consolidate process logic:
                        CompleteItem();

                        Globals.BlankLine();
                        Globals.Write("You have just completed Signing the Policy Agreement Package.", true);
                        Globals.Write("This item has been marked Complete in your Inventory.", true);
                        Globals.BlankLine();
                        Globals.Write("Press any key to continue... > ", false);
                        Console.ReadLine();
                        InRoom2Complete = false;
                    }
                    if (!FoundItemInInventory)
                    {
                        //Item Not Found in Inventory:
                        Globals.BlankLine();
                        Globals.Write("A Policy Agreement Package is not yet in your Inventory.", true);
                        Globals.Write("This item has not yet been picked up or completed.", true);
                        Globals.BlankLine();
                        Globals.Write("Press any key to continue... > ", false);
                        Console.ReadLine();
                        InRoom2Complete = false;
                    }
                }
                else
                {
                    //No Items in Inventory to Complete:
                    Globals.BlankLine();
                    Globals.Write("There are no Items in your Inventory yet.", true);
                    Globals.Write("Please pick up an Item first, then Complete it.", true);
                    Globals.BlankLine();
                    Globals.Write("Press any key to continue... > ", false);
                    Console.ReadLine();
                    InRoom2Complete = false;
                }
            }
        }

        private void moRoom3SelectComplete()
        {
            var playerInfo = _gp.GetPlayerInfo();

            Globals.Clear();
            InRoom3Complete = true;
            while (InRoom3Complete)
            {
                bool FoundItemInInventory = false;
                //Verify Player Has Item in Inventory:
                if (playerInfo.Inventory.Count > 0)
                {
                    foreach (var item in playerInfo.Inventory)
                    {
                        var itemInfo = _gp.GetItemInfo(item);
                        if (itemInfo.Name == "Building Fob")
                        {
                            FoundItemInInventory = true;
                        }
                    }
                    if (FoundItemInInventory)
                    {
                        //2018-05-16: Updated to consolidate process logic:
                        CompleteItem();

                        Globals.BlankLine();
                        Globals.Write("You have just successfully tested your new Building Fob.", true);
                        Globals.Write("This item has been marked Complete in your Inventory.", true);
                        Globals.BlankLine();
                        Globals.Write("Press any key to continue... > ", false);
                        Console.ReadLine();
                        InRoom3Complete = false;
                    }
                    if (!FoundItemInInventory)
                    {
                        //Item Not Found in Inventory:
                        Globals.BlankLine();
                        Globals.Write("A Building Fob is not yet in your Inventory.", true);
                        Globals.Write("This item has not yet been picked up or completed.", true);
                        Globals.BlankLine();
                        Globals.Write("Press any key to continue... > ", false);
                        Console.ReadLine();
                        InRoom3Complete = false;
                    }
                }
                else
                {
                    //No Items in Inventory to Complete:
                    Globals.BlankLine();
                    Globals.Write("There are no Items in your Inventory yet.", true);
                    Globals.Write("Please pick up an Item first, then Complete it.", true);
                    Globals.BlankLine();
                    Globals.Write("Press any key to continue... > ", false);
                    Console.ReadLine();
                    InRoom3Complete = false;
                }
            }
        }

        private void moRoom4SelectComplete()
        {
            var playerInfo = _gp.GetPlayerInfo();

            Globals.Clear();
            InRoom4Complete = true;
            while (InRoom4Complete)
            {
                bool FoundItemInInventory = false;
                //Verify Player Has Item in Inventory:
                if (playerInfo.Inventory.Count > 0)
                {
                    foreach (var item in playerInfo.Inventory)
                    {
                        var itemInfo = _gp.GetItemInfo(item);
                        if (itemInfo.Name == "Active Directory Account")
                        {
                            FoundItemInInventory = true;
                        }
                    }
                    if (FoundItemInInventory)
                    {
                        //2018-05-16: Updated to consolidate process logic:
                        CompleteItem();

                        Globals.BlankLine();
                        Globals.Write("You have just successfully built your new AD Account.", true);
                        Globals.Write("This item has been marked Complete in your Inventory.", true);
                        Globals.BlankLine();
                        Globals.Write("Press any key to continue... > ", false);
                        Console.ReadLine();
                        InRoom4Complete = false;
                    }
                    if (!FoundItemInInventory)
                    {
                        //Item Not Found in Inventory:
                        Globals.BlankLine();
                        Globals.Write("A 'build Active Directory task' is not yet in your Inventory.", true);
                        Globals.Write("This item has not yet been picked up or completed.", true);
                        Globals.BlankLine();
                        Globals.Write("Press any key to continue... > ", false);
                        Console.ReadLine();
                        InRoom4Complete = false;
                    }
                }
                else
                {
                    //No Items in Inventory to Complete:
                    Globals.BlankLine();
                    Globals.Write("There are no Items in your Inventory yet.", true);
                    Globals.Write("Please pick up an Item first, then Complete it.", true);
                    Globals.BlankLine();
                    Globals.Write("Press any key to continue... > ", false);
                    Console.ReadLine();
                    InRoom4Complete = false;
                }
            }
        }

        private void moRoom2SelectSubmit()
        {
            var playerInfo = _gp.GetPlayerInfo();
            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());

            string strMood;

            Globals.Clear();
            InRoom2Submit = true;
            while (InRoom2Submit)
            {
                bool FoundItemInInventory = false;
                //Verify Player Has Item in Inventory:
                if (playerInfo.Inventory.Count > 0)
                {
                    foreach (var item in playerInfo.Inventory)
                    {
                        var itemInfo = _gp.GetItemInfo(item);
                        if (itemInfo.Name == "In-Processing Form")
                        {
                            FoundItemInInventory = true;

                            if (!itemInfo.Completed)
                            {
                                if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                                {
                                    SubmitResult_HaveItem_NotComplete_BadMood();
                                    InRoom2Submit = false;
                                    InRoom2 = false;
                                    InGame = false;
                                    moSelectExit();
                                }
                                else
                                {
                                    SubmitResult_HaveItem_NotComplete_GoodMood();
                                    InRoom2Submit = false;
                                }
                            }
                            else
                            {
                                //Item is completed:
                                SubmitResult_HaveItem_IsComplete();

                                //Set Mood of next room to Good:
                                //Item was found in Inventory AND it was Completed! - Yay! = Good Mood:
                                strMood = "Good";
                                SetRoomMood(strMood);

                                //2018-05-16: Updated to consolidate process logic, now using new method version
                                //and passing current room from game-state:
                                SubmitRoomItem(false);

                                InRoom2Submit = false;
                            }
                        }
                    }
                    if (!FoundItemInInventory)
                    {
                        //Item Not Found in Inventory:
                        if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                        {
                            SubmitResult_NoItem_BadMood();
                            InRoom2Submit = false;
                            InRoom2 = false;
                            InGame = false;
                            moSelectExit();
                        }
                        else
                        {
                            SubmitResult_NoItem_GoodMood();
                            InRoom2Submit = false;
                        }
                    }
                }
                else
                {
                    //No Items in Inventory to Complete:
                    if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                    {
                        SubmitResult_NoItems_BadMood();
                        InRoom2Submit = false;
                        InRoom2 = false;
                        InGame = false;
                        moSelectExit();
                    }
                    else
                    {
                        SubmitResult_NoItems_GoodMood();
                        InRoom2Submit = false;
                    }
                }
            }
        }

        private void moRoom3SelectSubmit()
        {
            var playerInfo = _gp.GetPlayerInfo();
            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());

            string strMood;

            Globals.Clear();
            InRoom3Submit = true;
            while (InRoom3Submit)
            {
                bool FoundItemInInventory = false;
                //Verify Player Has Item in Inventory:
                if (playerInfo.Inventory.Count > 0)
                {
                    foreach (var item in playerInfo.Inventory)
                    {
                        var itemInfo = _gp.GetItemInfo(item);
                        if (itemInfo.Name == "Policy Agreement Package")
                        {
                            FoundItemInInventory = true;

                            if (!itemInfo.Completed)
                            {
                                if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                                {
                                    SubmitResult_HaveItem_NotComplete_BadMood();
                                    InRoom3Submit = false;
                                    InRoom3 = false;
                                    InGame = false;
                                    moSelectExit();
                                }
                                else
                                {
                                    SubmitResult_HaveItem_NotComplete_GoodMood();
                                    InRoom3Submit = false;
                                }
                            }
                            else
                            {
                                //Item is completed:
                                SubmitResult_HaveItem_IsComplete();

                                //Set Mood of next room to Good:
                                //Item was found in Inventory AND it was Completed! - Yay! = Good Mood:
                                strMood = "Good";
                                SetRoomMood(strMood);

                                //2018-05-16: Updated to consolidate process logic, now using new method version
                                //and passing current room from game-state:
                                SubmitRoomItem(false);

                                InRoom3Submit = false;
                            }
                        }
                    }
                    if (!FoundItemInInventory)
                    {
                        //Item Not Found in Inventory:
                        if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                        {
                            SubmitResult_NoItem_BadMood();
                            InRoom3Submit = false;
                            InRoom3 = false;
                            InGame = false;
                            moSelectExit();
                        }
                        else
                        {
                            SubmitResult_NoItem_GoodMood();
                            InRoom3Submit = false;
                        }
                    }
                }
                else
                {
                    //No Items in Inventory to Complete:
                    if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                    {
                        SubmitResult_NoItems_BadMood();
                        InRoom3Submit = false;
                        InRoom3 = false;
                        InGame = false;
                        moSelectExit();
                    }
                    else
                    {
                        SubmitResult_NoItems_GoodMood();
                        InRoom3Submit = false;
                    }
                }
            }
        }

        private void moRoom4SelectSubmit()
        {
            var playerInfo = _gp.GetPlayerInfo();
            var roomInfo = _gp.GetRoomInfo(_gp.GetCurrentRoom());

            Globals.Clear();
            InRoom4Submit = true;
            while (InRoom4Submit)
            {
                bool FoundItemInInventory = false;
                //Verify Player Has Item in Inventory:
                if (playerInfo.Inventory.Count > 0)
                {
                    foreach (var item in playerInfo.Inventory)
                    {
                        var itemInfo = _gp.GetItemInfo(item);
                        if (itemInfo.Name == "Building Fob")
                        {
                            FoundItemInInventory = true;

                            if (!itemInfo.Completed)
                            {
                                if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                                {
                                    SubmitResult_HaveItem_NotComplete_BadMood();
                                    InRoom4Submit = false;
                                    InRoom3 = false;
                                    InGame = false;
                                    moSelectExit();
                                }
                                else
                                {
                                    SubmitResult_HaveItem_NotComplete_GoodMood();
                                    InRoom4Submit = false;
                                }
                            }
                            else
                            {
                                //Item is completed:
                                SubmitResult_HaveItem_IsComplete();

                                //2018-05-16: Updated to consolidate process logic, now using new method version
                                //and passing current room from game-state:
                                SubmitRoomItem(false);

                                InRoom4Submit = false;
                            }
                        }
                    }
                    if (!FoundItemInInventory)
                    {
                        //Item Not Found in Inventory:
                        if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                        {
                            SubmitResult_NoItem_BadMood();
                            InRoom4Submit = false;
                            InRoom3 = false;
                            InGame = false;
                            moSelectExit();
                        }
                        else
                        {
                            SubmitResult_NoItem_GoodMood();
                            InRoom4Submit = false;
                        }
                    }
                }
                else
                {
                    //No Items in Inventory to Complete:
                    if (roomInfo.Person.Mood == Person.MoodStatus.Bad)
                    {
                        SubmitResult_NoItems_BadMood();
                        InRoom4Submit = false;
                        InRoom3 = false;
                        InGame = false;
                        moSelectExit();
                    }
                    else
                    {
                        SubmitResult_NoItems_GoodMood();
                        InRoom4Submit = false;
                    }
                }
            }
        }

        private void SubmitResult_HaveItem_NotComplete_BadMood()
        {
            Globals.BlankLine();
            Globals.Write("You are FIRED!", true);
            Globals.Write("You Submitted an incomplete task to a manager in a bad mood.", true);
            Globals.Write("Not recommended.", true);
            Globals.BlankLine();
            Globals.Write("Press any key to continue... > ", false);
            Console.ReadLine();
        }

        private void SubmitResult_HaveItem_NotComplete_GoodMood()
        {
            Globals.BlankLine();
            Globals.Write("Wow, that was close!", true);
            Globals.Write("You Submitted an incomplete task to a manager in a Good mood.", true);
            Globals.Write("You are very Fortunate!", true);
            Globals.Write("You have been given another chance!", true);
            Globals.BlankLine();
            Globals.Write("Press any key to continue... > ", false);
            Console.ReadLine();
        }

        private void SubmitResult_HaveItem_IsComplete()
        {
            Globals.BlankLine();
            Globals.Write("Great Job!", true);
            Globals.Write("The task you submitted is complete!", true);
            Globals.BlankLine();
            Globals.Write("Press any key to continue... > ", false);
            Console.ReadLine();
        }

        private void SubmitResult_NoItem_BadMood()
        {
            Globals.BlankLine();
            Globals.Write("You are FIRED!", true);
            Globals.Write("You Submitted a task you don't have to a manager in a bad mood!", true);
            Globals.Write("Not recommended.", true);
            Globals.BlankLine();
            Globals.Write("Press any key to continue... > ", false);
            Console.ReadLine();
        }

        private void SubmitResult_NoItem_GoodMood()
        {
            Globals.BlankLine();
            Globals.Write("Wow, that was close!", true);
            Globals.Write("You Submitted a task you don't have to a manager in a Good mood.", true);
            Globals.Write("You are very Fortunate!", true);
            Globals.Write("You have been given another chance!", true);
            Globals.BlankLine();
            Globals.Write("Press any key to continue... > ", false);
            Console.ReadLine();
        }

        private void SubmitResult_NoItems_BadMood()
        {
            Globals.BlankLine();
            Globals.Write("You are FIRED!", true);
            Globals.Write("You don't have any items at all to Submit to a grumpy manager!", true);
            Globals.BlankLine();
            Globals.Write("Press any key to continue... > ", false);
            Console.ReadLine();
        }

        private void SubmitResult_NoItems_GoodMood()
        {
            Globals.BlankLine();
            Globals.Write("Wow, that was close!", true);
            Globals.Write("You don't have any items to submit!", true);
            Globals.Write("You are very Fortunate the office manager is in a good mood!", true);
            Globals.Write("You have been given another chance!", true);
            Globals.BlankLine();
            Globals.Write("Press any key to continue... > ", false);
            Console.ReadLine();
        }

        private void moSelectRestart()
        {
            InRoom1 = false;
            InRoom2 = false;
            InRoom3 = false;
            InRoom4 = false;
            InGame = false;
            _gp.Restart();
            BuildMainMenu();
        }

        private void moSelectExit()
        {
            var gamePlayed = _gp.GetGamePlayedStatus();

            Globals.Clear();
            Globals.BlankLine();
            if (gamePlayed.Played)
            {
                Globals.Write("Sorry to see you go; thank you for playing!", true);
            }
            else
            {
                Globals.Write("Too bad you'd rather not play; maybe next time!", true);
            }

            Globals.BlankLine();
            Globals.Write("Exiting Game ...", true);
            Globals.Write("Press any key to continue... > ", false);

            Console.ReadLine();
            InRoom1 = false;
            InRoom2 = false;
            InRoom3 = false;
            InRoom4 = false;
            Running = false;
        }


    }


}
