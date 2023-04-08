using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attempts : MonoBehaviour, IAttempts
{
    [SerializeField] private int _numberAttempts;
    [SerializeField] private List<Image> _health;
    private IGameOver _serviceGameOver;


    private void Awake()
    {
        _serviceGameOver = GetComponent<IGameOver>();
    }
    private void Start()
    {
        OnRestart();
    }
    public void AdjustAttempts(int value, bool IsTakeDamage)
    {
        _numberAttempts += value;

        if (_numberAttempts > 0)
        {
            if (IsTakeDamage)
            {
                UpdateHealth(IsTakeDamage);
            }
        }
        else
        {
            _numberAttempts = 0;

            _serviceGameOver.GameOver(GameOverType.ZeroAttempts);
            
        }

    }

    private void UpdateHealth(bool IsTakeDamage)
    {
        if (IsTakeDamage)
            if (_health.Any(x => x?.gameObject.activeSelf == true))
                _health.FirstOrDefault(x => x?.gameObject.activeSelf == true)?.gameObject.SetActive(false);
    }

    public void OnRestart()
    {
        _health.ForEach(x => x.gameObject.SetActive(true));
        _numberAttempts = _health.Count;
    }
}
