using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attempts : MonoBehaviour, IAttempts
{
    [SerializeField] private int _numberAttempts;
    [SerializeField] private List<Image> _health;
    private void Start()
    {
        _numberAttempts = 3;
    }
    public void AdjustAttempts(int value, bool IsTakeDamage)
    {
        _numberAttempts += value;

        if (_numberAttempts >= 0)
        {
            if (IsTakeDamage)
            {
                UpdateHealth(IsTakeDamage);
            }
        }
        else
        {
            _numberAttempts=0;
            EndGame();
        }

    }
    private void EndGame()
    {
       
    }
    public void OnReset() // fix интерфейс
    {
        _health.ForEach(x => x.gameObject.SetActive(true));
        _numberAttempts = 3;
    }
    private void UpdateHealth(bool IsTakeDamage)
    {
        if (IsTakeDamage)
        {
            _health.FirstOrDefault(x => x.gameObject.activeSelf == true).gameObject.SetActive(false);
        }
    }
}
