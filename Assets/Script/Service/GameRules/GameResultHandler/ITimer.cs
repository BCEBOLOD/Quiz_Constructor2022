using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimer: IRestart
{
   public void SelfActiveTimer(bool active);
}
