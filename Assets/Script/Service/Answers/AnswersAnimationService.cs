using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class AnswersAnimationService : MonoBehaviour
{
    [SerializeField] protected List<QuestionButtonMV> _buttonsList;
    protected Coroutine _waitAndAnimateCoroutine;
    protected bool _isRunningCorutine;
    public abstract event UnityAction e_NextQuesting;
    public abstract event UnityAction e_AwaitNewQuesting;

    //
    public abstract void TryStopCoroutine();
    public abstract void OnIncreaseButtonAnimation();
    public abstract IEnumerator WaitAndAnimate(float waitTimeOne, float waitTimeTwo);
    public abstract void OnStartDescreseAnimation(int id);
}
