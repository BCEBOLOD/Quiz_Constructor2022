using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New SettingJSON", menuName = "JSON/Setting")]
public class SettingJSON : ScriptableObject
{

    [SerializeField] private int _progress;
    public int Progress => _progress;
    [SerializeField] private float _volume;
    public float Volume => _volume;
    [SerializeField] private string _language;
    public string Language => _language;

}
