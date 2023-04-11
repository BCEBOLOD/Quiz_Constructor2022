using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ChoiceLvlService : MonoBehaviour
{
    [SerializeField] private GameObject _buttonsHolder;//Ссылка на go, который содержит все кнопки
    [SerializeField] private List<Button> _buttonsList = new(10);

    private void Start()
    {
        _buttonsList = _buttonsHolder.GetComponentsInChildren<Button>().ToList();
    }
}
