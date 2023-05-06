using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _audiosource;
    [SerializeField] private Slider _slider;
    [SerializeField] private SaveLoadManager _saveloadManager;
    private void Awake()
    {
        _audiosource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audiosource.volume = _saveloadManager.GameData.volume;
    }
    public void UpdateVolume(float volume)
    {
      _audiosource.volume = _slider.value;
      _saveloadManager.GameData.volume = _slider.value;
    }

}
