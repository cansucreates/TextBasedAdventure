using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField; // This is a reference to the InputField component that will take the player's input
    GameController controller; // This is a reference to the GameController script

    void Awake()
    {
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput); // This will add a listener to the input field that will call the AcceptStringInput method when the player presses Enter
    }

    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);

        char[] delimiterCharacters = { ' ' }; // This is an array of characters that will be used to split the user input
        string[] separatedInputWords = userInput.Split(delimiterCharacters); // This will split the user input into an array of words

        for (int i = 0; i < controller.inputActions.Length; i++) // This will loop through all the input actions
        {
            InputAction inputAction = controller.inputActions[i]; // This will store the current input action in a variable
            if (inputAction.keyWord == separatedInputWords[0]) // This will check if the first word in the user input matches the keyword of the input action
            {
                inputAction.RespondToInput(controller, separatedInputWords); // This will call the RespondToInput method of the input action
            }
        }

        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
