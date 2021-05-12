using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager{
   public enum GameState { MENU, GAME, PAUSE, ENDGAME,CHAT, SOUND, INFO, OPEN };
   public GameState gameState { get; private set; }
   

   public string message;
   public string speaker;
   public bool lost;
   

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

   private static GameManager _instance;

   public static GameManager GetInstance(){
       if(_instance == null){
           _instance = new GameManager();
       }
       return _instance;
   }
   private GameManager(){
       message = " ";
       speaker = " ";
       lost = false;
       gameState = GameState.MENU;
   }

    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.GAME) Reset();
        gameState = nextState;
        changeStateDelegate();
    }
    private void Reset()
    {
        message = " ";
        speaker = " ";
        lost = false;

    }
}
