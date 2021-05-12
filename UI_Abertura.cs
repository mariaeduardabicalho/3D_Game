using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Abertura : MonoBehaviour
{
    // Start is called before the first frame update
  GameManager gm;

  private void OnEnable()
  {
      gm = GameManager.GetInstance();
  }
 
  public void Inicar()
  {
      gm.ChangeState(GameManager.GameState.GAME);
  }
}

