using UnityEngine;
using UnityEngine.SceneManagement;
 
public class ChangeScene : MonoBehaviour
{
    public string scene;
    public void NewScene()
    {
        SceneManager.LoadScene(scene);
    }
    public void Quit()
    {
        Application.Quit();
        
    }
}
