using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    private bool _isActive { get; set; }
    public bool IsActive => _isActive;
    public void StateActive(bool state)
    {
        _isActive = state;
        _animator.SetTrigger("Damage");
    }
    public void OnRestart(){
         _isActive = true;
        _animator.SetTrigger("Reset");
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
