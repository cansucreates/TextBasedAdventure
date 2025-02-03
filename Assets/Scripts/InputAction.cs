using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    public string keyWord; // This is the keyword that the player will type to trigger the action
    public abstract void RespondToInput(GameController controller, string[] seperatedInputWords); // This is the method that will be called when the player types the keyword
}
