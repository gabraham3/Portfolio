using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemScript : MonoBehaviour
{

    public Item item;
    public TMP_Text a;
    public TMP_Text b;



    // Update is called once per frame
    void Update()
    {
       a.text = item.Name;
       b.text = item.cost;

    }

    public void NewScene()
    {
        PlayerPrefs.SetString("ItemName", item.Name);
        SceneManager.LoadScene("Item");

    }
}
