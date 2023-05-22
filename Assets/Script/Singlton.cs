using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Singlton : MonoBehaviour
{

    public static int CountLvl { get; private set; } = 6;
    private static Singlton instance;    
    public AudioSource AudioSource;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
        AudioSource = gameObject.GetComponent<AudioSource>();
       
    }

    public static Singlton Instance
    {
        get { return instance; }
    }
  
}
