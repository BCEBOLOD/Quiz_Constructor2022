using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindBugPanel : MonoBehaviour
{
    [SerializeField] private GameObject _findBugPanel;
    [SerializeField] private Button _findBugButtonOpen;
    [SerializeField] private Button _findBugButtonBackgroundClose;
    [SerializeField] private Button _findBugButtonPanelClose;

    private void Start()
    {
        _findBugButtonOpen.onClick.AddListener(() =>
        {
            _findBugPanel.SetActive(true);
            _findBugButtonBackgroundClose.gameObject.SetActive(true);
        });
        _findBugButtonBackgroundClose.onClick.AddListener(() =>
        {
            _findBugButtonBackgroundClose.gameObject.SetActive(false);
            _findBugPanel.SetActive(false);
        });
        _findBugButtonPanelClose.onClick.AddListener(() =>
        {
            _findBugPanel.SetActive(false);
            _findBugButtonBackgroundClose.gameObject.SetActive(false);
        });
    }
}
