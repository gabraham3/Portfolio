using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_change : MonoBehaviour
{
    public int SceneIndex;
    public Vector3 playerPositionInNextScene;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            GameObject player = other.gameObject;
            //DontDestroyOnLoad(player);
            Scene currentScene = SceneManager.GetActiveScene();

            int sceneIndex = currentScene.buildIndex;

            PlayerPrefs.SetInt("SceneDead", sceneIndex);

            SceneManager.LoadScene(SceneIndex, LoadSceneMode.Single);
            //if (player != null)
            //{
                // Set the position of the player in the next scene
                //player.transform.position = playerPositionInNextScene;
            //}
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
