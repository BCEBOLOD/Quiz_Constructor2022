using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InitButtonsLoadLvlIndex : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>().ToList();
    }

    private void Start()
    {
    
    }


    private void SetIndex(int index)    
    {
        print(index);
    }
}
