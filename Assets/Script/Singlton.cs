using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Singlton : MonoBehaviour
{
    [SerializeField] private AudioSource _audiosource;
    //private void Awake() {
    //    DontDestroyOnLoad(this);
    //}
    private static Singlton instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Удаляем дубликат, если он уже существует
            Destroy(gameObject);
        }
    }

    public static Singlton Instance
    {
        get { return instance; }
    }
}
