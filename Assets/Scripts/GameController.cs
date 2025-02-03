using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text displayText; // This is a reference to the Text component that will display the game text

    [HideInInspector]
    public RoomNavigation roomNavigation; // This is a reference to the RoomNavigation script

    [HideInInspector]
    public List<string> interactionDescriptionsInRoom = new List<string>(); // This will store the descriptions of the interactions in the room
    List<string> actionLog = new List<string>(); // This will store the player's actions

    void Awake() // This will be called when the script is loaded
    {
        roomNavigation = GetComponent<RoomNavigation>();
    }

    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray()); // This will join all the strings in the action log with a new line character
        displayText.text = logAsText; // This will set the text of the displayText object to the logAsText string
    }

    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom(); // This will clear the collections for the new room
        UnpackRoom();

        string joinedInteractionDescriptions = string.Join(
            "\n",
            interactionDescriptionsInRoom.ToArray()
        ); // This will join all the strings in the interaction descriptions with a new line character
        string combinedText =
            roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions; // This will store the description of the current room
        LogStringWithReturn(combinedText); // This will add the description of the current room to the action log
    }

    private void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom(); // This will unpack the exits in the current room
    }

    void ClearCollectionsForNewRoom()
    {
        interactionDescriptionsInRoom.Clear(); // This will clear the interaction descriptions in the room
        roomNavigation.ClearExits(); // This will clear the exits in the room
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n"); // This will add the string to the action log
    }

    // Update is called once per frame
    void Update() { }
}
