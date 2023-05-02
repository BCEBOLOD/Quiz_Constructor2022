using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Singlton : MonoBehaviour
{
    [SerializeField] private AudioSource _audiosource;
    public static int CountLvl { get; private set; } = 10;
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
            // ������� ��������, ���� �� ��� ����������
            Destroy(gameObject);
        }
    }

    public static Singlton Instance
    {
        get { return instance; }
    }
}
