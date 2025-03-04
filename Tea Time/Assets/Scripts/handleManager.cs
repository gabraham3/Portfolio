using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleManager : MonoBehaviour
{
    public int handleC;
    public int tea;
    public int teaC;
    public static handleManager Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance.handleC = 0;
        Instance.tea = 0;
        Instance.teaC = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            // Transfer state to the existing instanc
            return;
        }

        // If this is the first instance, set it and keep it alive across scenes
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
