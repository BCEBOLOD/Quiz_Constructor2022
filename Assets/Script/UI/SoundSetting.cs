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
    private void Awake()
    {
        _sliderSound = gameObject.GetComponent<Slider>();
        _singlton = FindObjectOfType<Singlton>();
    }
    private void Start()
    {
        _sliderSound.value = _saveloadManager.GameData.volume;
      //   _onSound.onClick.AddListener(() => UpdateVolume(0));
       // _onSound.onClick.AddListener(() => UpdateVolume(1));
    }
    public void UpdateVolume(float value)
    {
        _saveloadManager.GameData.volume = value;
         _sliderSound.value = value;
        _saveloadManager.SaveGameData();
    }
}
