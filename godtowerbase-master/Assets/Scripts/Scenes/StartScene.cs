using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour {

	public void OnStartButtonClicked(){
        TKSceneManager.ChangeScene("Level1");
    }

    public void OnContinueButtonClicked() {

    }

}
