using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom; // This is a reference to the current room the player is in
    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>(); // This is a dictionary that will store the exits in the current room
    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom() // This method will unpack the exits in the current room and add them to the interaction descriptions
    {
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom); // This will add the exit to the dictionary
            controller.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription); // This will add the exit description to the interaction descriptions
        }
    }

    public void AttempToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn("You head off to the " + directionNoun);
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn("There is no path to the " + directionNoun);
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
