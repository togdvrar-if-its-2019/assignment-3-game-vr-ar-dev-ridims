using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour{

    public void playGame(){
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
