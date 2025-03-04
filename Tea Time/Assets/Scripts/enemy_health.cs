using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class enemy_health : MonoBehaviour
{
    public int curHealth = 2;
    public int maxHealth = 4;
    public BoxCollider2D change_scene;
    void Start()
    {
        curHealth = maxHealth;
        change_scene.enabled = false;
    }
    void Update()
    {
        Debug.Log(curHealth);
        if(curHealth <= 0)
        {
            Destroy(gameObject);
            change_scene.enabled = true;
        }
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    DamageEnemy(1);
        //}
    }
    public void DamageEnemy( int damage )
    {
        curHealth -= damage;
        //healthBar.SetHealth( curHealth );
    }
}