using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
   private IGameOver _serviceGameOver;
   

private void Awake() {
 _serviceGameOver   = GetComponent<IGameOver>();
}


   
}
