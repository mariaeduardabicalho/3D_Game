
using UnityEngine;
using UnityEngine.UI;

public class UI_Chat : MonoBehaviour
{
   public Text message;
//    public Image speaker;
    public Text speaker;

   GameManager gm;

//    Sprite clown;

//     void Awake(){

//        Sprite clown =  Resources.Load <Sprite>("clown");
//    }

   private void OnEnable()
   {
      
       gm = GameManager.GetInstance();

    //    speaker.sprite = clown;


        speaker.text = "Você:    ";
        message.text = "      Olá! Você viu a Dori?";

   }    
   
    public void Prox()
    {
        speaker.text = gm.speaker;

        message.text = gm.message;
        
    }

    public void Fechar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}