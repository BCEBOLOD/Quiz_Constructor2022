using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SwitchSizeBackground : MonoBehaviour
{
    //   [SerializeField] private RectTransform _image;

    [SerializeField] private List<Image>  _background;
    private void Start()
    {
        if (Screen.height > Screen.width)
        {
            _background[1].gameObject.SetActive(true);
            return;
        }
        _background[0].GameObject().SetActive(true);
        //_image.localScale = new Vector3(2.5f,2.5f,2.5f);
    }
}
