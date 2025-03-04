using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ending_scene : MonoBehaviour
{
    public handleManager hm;
    public int time;
    
    // Start is called before the first frame update
    void Start()
    {
        hm = handleManager.Instance;
        StartCoroutine(Scene());
    }
    IEnumerator Scene(){
        yield return new WaitForSeconds(time);
        if (hm == null){
                SceneManager.LoadScene(6);
            }
            else if (hm.handleC > 0){
                SceneManager.LoadScene(7);
            }
            else {
                SceneManager.LoadScene(6);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
