using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlton : MonoBehaviour
{
    [SerializeField] private AudioSource _audiosource;
    private void Awake() {
        DontDestroyOnLoad(this);
    }
}
