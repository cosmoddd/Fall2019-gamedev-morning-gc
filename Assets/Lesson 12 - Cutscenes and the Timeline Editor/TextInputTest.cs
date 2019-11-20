using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInputTest : MonoBehaviour
{
    public TMP_InputField inputField;

    public void GetLetter(string _s)
    {
        // inputField.ProcessEvent(Event.KeyboardEvent(_s));
        // inputField.ForceLabelUpdate();
    
        inputField.text = inputField.text+_s;
        inputField.MoveTextEnd(true);

    }

    public void BackSpace()
    {
        if (inputField.text != "")
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }
}
