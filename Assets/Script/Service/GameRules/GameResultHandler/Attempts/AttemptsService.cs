using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attempts : MonoBehaviour, IAttempts
{
    [SerializeField] private int _numberAttempts;
   // [SerializeField] private List<Image> _health;
   [SerializeField] private List<HealthUI> _healths;
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
            print("call");
            _serviceGameOver.GameOver(GameOverType.ZeroAttempts);
            
        }

    }

    private void UpdateHealth(bool IsTakeDamage)
    {
        if (IsTakeDamage)
            if (_healths.Any(x => x?.IsActive == true))
            //    _healths.FirstOrDefault(x => x?.isActive == true)?.gameObject.SetActive(false);
                _healths.FirstOrDefault(x => x?.IsActive == true)?.StateActive(false);
    }

    public void OnRestart()
    {
        _healths.ForEach(x => x.OnRestart());
        _numberAttempts = _healths.Count;
    }
}
