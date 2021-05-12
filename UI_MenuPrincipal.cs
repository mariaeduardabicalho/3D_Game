using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuPrincipal : MonoBehaviour
{

  GameManager gm;

  private void OnEnable()
  {
      gm = GameManager.GetInstance();
  }
 
  public void Comecar()
  {
      gm.ChangeState(GameManager.GameState.OPEN);
  }

  public void Info()
  {
      gm.ChangeState(GameManager.GameState.INFO);
  }
}