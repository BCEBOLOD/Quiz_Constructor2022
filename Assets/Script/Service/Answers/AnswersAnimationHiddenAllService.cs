using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnswersAnimationHiddenAllService : AnswersAnimationService
{
    public override event UnityAction e_NextQuesting;
    public override event UnityAction e_AwaitNewQuesting;

    public override void OnIncreaseButtonAnimation()
    {
        foreach (var item in _buttonsList)
        {
            item.Animator.SetTrigger(GameConst.Anim_OnIncrease);
            item.Button.interactable = true;
        }
        e_NextQuesting?.Invoke();

    }

    public override void OnStartDescreseAnimation(int id)
    {
        e_AwaitNewQuesting?.Invoke();
        foreach (var item in _buttonsList)
        {
            item.Button.interactable = false;
            item.Animator.SetTrigger(GameConst.Anim_OnDecrease);

        }
        _waitAndAnimateCoroutine = StartCoroutine(WaitAndAnimate(1, 1));
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

    public override IEnumerator WaitAndAnimate(float waitTimeOne, float waitTimeTwo)
    {
        _isRunningCorutine = true;
        yield return new WaitForSeconds(waitTimeOne);

        // yield return new WaitForSeconds(waitTimeTwo);
        OnIncreaseButtonAnimation();
        _isRunningCorutine = false;
    }

}
