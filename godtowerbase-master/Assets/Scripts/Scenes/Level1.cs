using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour {
    public InputField passwordInput;
    public Text hintTextField;

    public void OnSubmitButtonClicked()
    {
        if(passwordInput.text == "kabul")
        {
            Application.LoadLevel("StartScene");
        }
        else
        {
            hintTextField.color = Color.red;
            hintTextField.text = "ACCESS DENIED!!!";
        }
    } 
}
