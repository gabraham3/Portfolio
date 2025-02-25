using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    public Rule rule;
    public TMP_Text b;



    // Update is called once per frame
    void Update()
    {
       b.text = rule.title;
    }

    public void NewScene()
    {
        PlayerPrefs.SetString("RuleName", rule.title);
        SceneManager.LoadScene("Rule");

    }
}
