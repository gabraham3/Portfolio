using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tea_cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (handleManager.Instance.teaC == 1)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
