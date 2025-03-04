using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class boss_health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 20;
    public HealthBar healthBar;
    void Start()
    {
        curHealth = maxHealth;
    }
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            DamageBoss(1);
        }
    }
    public void DamageBoss( int damage )
    {
        curHealth -= damage;
        healthBar.SetHealth( curHealth );
    }
}