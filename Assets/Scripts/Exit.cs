using UnityEngine;

[System.Serializable]
public class Exit
{
    public string keyString; // This is a string that will hold the key required to unlock the exit
    public string exitDescription; // This is a string that will hold the description of the exit
    public Room valueRoom; // This is a reference to the room that the exit leads to
}
