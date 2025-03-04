using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public int curHealth = 20;
    public int maxHealth = 20;
    public HealthBar healthBar;
    void Start()
    {
        curHealth = maxHealth;
    }
    void Update()
    {
        //if( Input.GetKeyDown( KeyCode.Space ) )
        //{
        //    DamagePlayer(1);
        //}
        if (curHealth <= 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();

            // Get the build index of the current scene
            int sceneIndex = currentScene.buildIndex;
            PlayerPrefs.SetInt("SceneDead", sceneIndex);
            SceneManager.LoadScene(5);
        }
    }
    public void DamagePlayer( int damage )
    {
        curHealth -= damage;
        healthBar.SetHealth( curHealth );
    }
    public void HealPlayer(int heal)
    {
        curHealth += heal;
        print("heal");
        if(curHealth > maxHealth){
            curHealth = maxHealth;
        }
        
        healthBar.SetHealth(curHealth);
    }
}
//Code language: C# (cs)