using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScene : MonoBehaviour
{
    int scenereturn;
    public void restartGame()
    {
        if(PlayerPrefs.HasKey("SceneDead")){
            scenereturn = PlayerPrefs.GetInt("SceneDead");
        }
        else{
            scenereturn = 3;
        }
        SceneManager.LoadScene(scenereturn);

    }
}
