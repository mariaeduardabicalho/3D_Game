
using UnityEngine;
using UnityEngine.UI;

public class UI_FimDeJogo : MonoBehaviour
{
   public Text message;

   GameManager gm;
   private void OnEnable()
   {
       gm = GameManager.GetInstance();

       if(gm.lost == true)
       {
           message.text = "Você acordou o tubarão, ele não deixou você pegar a Dori ";
       }
       else
       {
           message.text = "Parabéns ! Você encontrou a dori! ";
       }
   }
   public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}