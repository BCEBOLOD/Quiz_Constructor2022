using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Slider _sliderSound;
    [SerializeField] private Button _onSound;
    [SerializeField] private Button _offSound;
    [SerializeField] private SaveLoadManager _saveloadManager;
    [SerializeField] private Singlton _singlton;
    [SerializeField] private AudioSource _audiosource;
    private void Awake()
    {
        //    _sliderSound = gameObject.GetComponent<Slider>();
        _singlton = FindObjectOfType<Singlton>();
        
    }
    private void Start()
    {
        if(_audiosource == null)
        _audiosource = _singlton.GetComponent<AudioSource>();
        _sliderSound.value = _saveloadManager.GameData.volume;
        _audiosource.volume = _saveloadManager.GameData.volume;
    }
    public void UpdateVolume()
    {
        _saveloadManager.GameData.volume = _sliderSound.value;
        _singlton.AudioSource.volume = _sliderSound.value;
        _saveloadManager.SaveGameData();
    }
    public void SwitchStateMusic(float value){
          _saveloadManager.GameData.volume =value;
        _singlton.AudioSource.volume = value;
           _sliderSound.value = value;
        _saveloadManager.SaveGameData();
    }
}
