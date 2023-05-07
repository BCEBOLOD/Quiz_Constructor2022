using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;
public class AnswersAnimationShowCorrectService : AnswersAnimationService
{
    public override event UnityAction e_NextQuesting;
    public override event UnityAction e_AwaitNewQuesting;
   // [SerializeField] private List<QuestionButtonMV> _buttonsList;
    [SerializeField] private int idtemp;
   //[SerializeField] private Coroutine _waitAndAnimateCoroutine;
    //private bool _isRunningCorutine;
    public override void OnStartDescreseAnimation(int id)
    {
        e_AwaitNewQuesting?.Invoke();
        idtemp = id;
        foreach (var item in _buttonsList)
        {
            item.Button.interactable = false;
            if (item.Id != id)
            {
                item.Animator.SetTrigger(GameConst.Anim_OnDecrease);
            }
            else
            {
                //   Invoke("OnlyOnDescreseAnimation", 2);
                // Invoke("OnIncreaseButtonAnimation", 3);
             _waitAndAnimateCoroutine =   StartCoroutine(WaitAndAnimate(2,1));
            }
        }
    }
    public override void TryStopCoroutine()
    {
        if (_isRunningCorutine && _waitAndAnimateCoroutine != null)
            StopCoroutine(_waitAndAnimateCoroutine);
            foreach (var item in _buttonsList)
        {
            item.Animator.SetTrigger(GameConst.Anim_OnIncrease);
            item.Button.interactable = true;
        }
    }
    public override IEnumerator WaitAndAnimate(float waitTimeOne,float waitTimeTwo)
    {
        _isRunningCorutine = true;
        yield return new WaitForSeconds(waitTimeOne);
        OnlyOnDescreseAnimation();
         yield return new WaitForSeconds(waitTimeTwo);
        OnIncreaseButtonAnimation();
        _isRunningCorutine = false;

    }
    private void OnlyOnDescreseAnimation()
    {
        _buttonsList[idtemp].Animator.SetTrigger(GameConst.Anim_OnDecrease);
    }
    public override void OnIncreaseButtonAnimation()
    {       
        foreach (var item in _buttonsList)
        {
            item.Animator.SetTrigger(GameConst.Anim_OnIncrease);
            item.Button.interactable = true;
        }
        e_NextQuesting?.Invoke();
    }
}




/*
1.При клике, вервый ответ показывается

2.При клике все уменьшаются
*/