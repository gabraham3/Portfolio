using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class timer_scene_change : MonoBehaviour
{
    public int SceneIndex;
    public int time;
    void OnEnable()
    {
        StartCoroutine(Scene());
    }
    
    IEnumerator Scene(){
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneIndex, LoadSceneMode.Single);
    }
}