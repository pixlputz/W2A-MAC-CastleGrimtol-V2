﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Interfaces;
using DataLayer.HelperMethods;

namespace DataLayer.Providers
{

    //2018-05-15: Update: Revamped all of this Provided class to consolidate original method logic.

    public class GameProvider
    {
        private Database _db;

        public GameProvider()
        {
            _db = new Database();
        }

        public ReturnGameInfo GetGameInfo()
        {
            return new ReturnGameInfo(
               _db.game.Title,
               _db.game.Version,
               _db.game.Developer,
               _db.game.DateLastUpdated,
               _db.game.Description
               );
        }

        public ReturnGamePlayedStatus GetGamePlayedStatus()
        {
            return new ReturnGamePlayedStatus(_db.game.Played);
        }

        public ReturnGamePlayedStatus SetGamePlayedStatus(bool played)
        {
            return new ReturnGamePlayedStatus(_db.game.Played = true);
        }

        //2018-05-15: Updated/Consolidated logic to use this single method now (was split out for each room):
        public Room GetCurrentRoom()
        {
            return _db.currentRoom;
        }

        //2018-05-15: Updated New method:
        public Room GetPreviousRoom()
        {
            return _db.previousRoom;
        }

        //2018-05-15: Update: New Method built to change the current-room game state, as user progresses:
        //Note: Also now using a new Game property 'CurrentRoom' and 'NextRoom' to track.
        public void ChangeCurrentRoom()
        {
            switch (_db.currentRoom.Id)
            {
                case 1:
                    _db.currentRoom = _db.roomHROffice;
                    _db.previousRoom = _db.roomAdminOffice;
                    break;
                case 2:
                    _db.currentRoom = _db.roomDepOffice;
                    _db.previousRoom = _db.roomHROffice;
                    break;
                case 3:
                    _db.currentRoom = _db.roomWorkArea;
                    _db.previousRoom = _db.roomDepOffice;
                    break;
                case 4:
                    //None; Exiting building
                    break;
            }
        }

        //2018-05-15: Update: New Method built to replace 4 (originally, a specific version for each room):
        public Room GetRoomInfo(Room room)
        {
            return room;
        }

        //2018-05-15: Update: New Method built to replace 4 (originally, a specific version for each room item):
        public void AddRoomItemToInventory()
        {
            bool bolAlreadyExists = false;
            switch (_db.currentRoom.Id)
            {
                //2018-05-15: Update: Adding logic to keep user from adding more than once:
                case 1:
                    foreach (var i in _db.player.Inventory)
                    {
                        if (i.Id == _db.currentRoom.Id)
                        {
                            //Already Exists; don't add again.
                            bolAlreadyExists = true;
                        }
                    }
                    if (bolAlreadyExists)
                    {
                        //Already Exists; don't add again.
                    }
                    else
                    {
                        _db.player.Inventory.Add(_db.itemInProcessingForm);
                    }
                    break;
                case 2:
                    foreach (var i in _db.player.Inventory)
                    {
                        if (i.Id == _db.currentRoom.Id)
                        {
                            //Already Exists; don't add again.
                            bolAlreadyExists = true;
                        }
                    }
                    if (bolAlreadyExists)
                    {
                        //Already Exists; don't add again.
                    }
                    else
                    {
                        _db.player.Inventory.Add(_db.itemPolicyAgreementPackage);
                    }
                    break;
                case 3:
                    foreach (var i in _db.player.Inventory)
                    {
                        if (i.Id == _db.currentRoom.Id)
                        {
                            //Already Exists; don't add again.
                            bolAlreadyExists = true;
                        }
                    }
                    if (bolAlreadyExists)
                    {
                        //Already Exists; don't add again.
                    }
                    else
                    {
                        _db.player.Inventory.Add(_db.itemBuildingFob);
                    }
                    break;
                case 4:
                    foreach (var i in _db.player.Inventory)
                    {
                        if (i.Id == _db.currentRoom.Id)
                        {
                            //Already Exists; don't add again.
                            bolAlreadyExists = true;
                        }
                    }
                    if (bolAlreadyExists)
                    {
                        //Already Exists; don't add again.
                    }
                    else
                    {
                        _db.player.Inventory.Add(_db.itemActiveDirectoryAccount);
                    }
                    break;
            }
        }

        //2018-05-15: Update: New Method built to replace 4 (originally, a specific version for each room item):
        public void CompleteRoomItem()
        {
            //2018-05-15: Update: New logic, replacing original switch bock with 1 line of code:
            _db.currentRoom.Item.Completed = true;
        }

        //2018-05-15: Update: New Method built to replace 4 (originally, a specific version for each room item):
        public void SubmitRoomItem(bool leavingBuilding)
        {
            bool bolLeavingBuilding = false;

            //2018-05-15: Update: New logic, replacing original switch bock with 1 line of code:
            _db.previousRoom.Item.Submitted = true;
            if (bolLeavingBuilding) { _db.currentRoom.Item.Submitted = true; }
        }

        //2018-05-15: Update: New Method built to replace 4 (originally, a specific version for each room):
        public void SetRoomPersonMood(string mood)
        {
            //We actually want to set the mood of the current room (room just changed), based on actions in previous room:
            if (mood == "Good")
            {
                _db.currentRoom.Person.Mood = Person.MoodStatus.Good;
            }
            else
            {
                _db.currentRoom.Person.Mood = Person.MoodStatus.Bad;
            }
        }

        public ReturnPlayerInfo GetPlayerInfo()
        {
            return new ReturnPlayerInfo(
               _db.player.Inventory
               );
        }

        public ReturnItemInfo GetItemInfo(Item item)
        {
            return new ReturnItemInfo(item.Id.ToString(), item.Name, item.Completed, item.Submitted);
        }

        public void Restart()
        {
            _db = new Database();
        }

    }

}
