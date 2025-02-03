using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Room")] /* This will create a new menu item in the Unity Editor called 
"TextAdventure" with a sub-menu item called "Room" that will allow you to create a new Room asset */
public class Room : ScriptableObject /* This is a scriptable object, which is a type of asset that can be created 
 in the Unity Editor and saved as a file in your project folder */
{
    [TextArea] // This attribute will make the description field appear as a multi-line text area in the Unity Editor
    public string description; // This is a string that will hold the description of the room
    public string roomName; // This is a string that will hold the name of the room
    public Exit[] exits; // This is an array of Exit objects that will hold the exits of the room
}
