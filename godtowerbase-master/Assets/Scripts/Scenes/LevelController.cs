using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static string LEVEL_TEXT = "LEVEL";
    public static string ACCESS_DENIED_TEXT = "ACCESS DENIED!";
    public static float NAME_CHANGE_INTERVAL = 1;

    public string password;
    public string levelName;
    public string levelHintText;
    public string nextLevelScenefilename;
    

    public InputField passwordInput;
    public Text hintTextField;
    public Text levelNameTextField;
    public Button nextHintButton;
    public List<GameObject> levelHintList;

    private float nextLevelNameChangeTimestamp = NAME_CHANGE_INTERVAL;  //thời gian chuyển đổi qua lại giữa "LEVEL" và số màn
    private Coroutine hintTextCoroutine;
    private int currentHintIndex = 0;

    public void Start()
    {
        hintTextField.text = levelHintText;
        if (levelHintList.Count > 1)
        {
            nextHintButton.gameObject.SetActive(true);
            DisplayCurrentHint();
        }
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad > nextLevelNameChangeTimestamp)
        {
            nextLevelNameChangeTimestamp += NAME_CHANGE_INTERVAL;
            levelNameTextField.text = (levelNameTextField.text == LEVEL_TEXT) ? levelName : LEVEL_TEXT;
        }
    }

    public void OnNextHintButtonClicked()
    {
        currentHintIndex++;
        currentHintIndex %= levelHintList.Count;
        if (currentHintIndex == levelHintList.Count - 1)
        {
            nextHintButton.transform.localScale = new Vector3(-1,1,1) ;
        }
        else
        {
            nextHintButton.transform.localScale = Vector3.one;
        }

        DisplayCurrentHint();
    }
    //chuyển nút ngược lại 
    private void DisplayCurrentHint()
    {
        for (int i = 0; i < levelHintList.Count; i++)
        {
            levelHintList[i].SetActive(i == currentHintIndex);
        }
    }

    public void OnSubmitButtonClicked()
    {
        if (passwordInput.text == password)
        {
      
            Application.LoadLevel(nextLevelScenefilename);
        }
        else
        {
            passwordInput.text = "";
            hintTextField.color = Color.red;
            hintTextField.text = ACCESS_DENIED_TEXT;

            if (hintTextCoroutine != null)
            {
                StopCoroutine(hintTextCoroutine);
            }
            hintTextCoroutine = StartCoroutine(ChangeHintTextBack());
        }
    }

    private IEnumerator ChangeHintTextBack() //thông dụng để làm animation
    {
        //yield return null;
        yield return new WaitForSeconds(2);
        hintTextField.text = levelHintText;
        hintTextField.color = Color.black;
    }

}
