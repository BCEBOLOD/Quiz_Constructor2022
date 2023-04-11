using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingPanel : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private Button _settingButtonOpen;
    [SerializeField] private Button _settingButtonBackgroundClose;
    [SerializeField] private Button _settingButtonPanelClose;


    private void Start()
    {
        _settingButtonOpen.onClick.AddListener(() =>
        {
            _settingPanel.SetActive(true);
            _settingButtonBackgroundClose.gameObject.SetActive(true);
        });
        _settingButtonBackgroundClose.onClick.AddListener(() =>
        {
            _settingButtonBackgroundClose.gameObject.SetActive(false);
            _settingPanel.SetActive(false);
        });
        _settingButtonPanelClose.onClick.AddListener(() =>
        {
            _settingPanel.SetActive(false);
            _settingButtonBackgroundClose.gameObject.SetActive(false);
        });
    }


}
