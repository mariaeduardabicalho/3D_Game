using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   float _baseSpeed = 10.0f;
   float _gravidade = 9.8f;
   float minFov= 15f;
    float maxFov = 90f;
    float sensitivity = 10f; 

    public Text messageClownf;
    //   public Text messagePlayer;
    // public GameObject ftextp;
    public GameObject message;

    public int click=0;

    GameManager gm;

   //Referência usada para a câmera filha do jogador
   GameObject playerCamera;
   //Utilizada para poder travar a rotação no angulo que quisermos.
   float cameraRotation;

   CharacterController characterController;

   public Vector3 originalPos;

   public AudioClip shark;

   public bool follow;

   
   
   void Start()
   {
       

        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

       characterController = GetComponent<CharacterController>();

       gm = GameManager.GetInstance();

       playerCamera = GameObject.Find("Main Camera");
       cameraRotation = 0.0f;
        follow = false;
   }

   void Update()
   {

       if (gm.gameState != GameManager.GameState.GAME) return;

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
                
                gm.ChangeState(GameManager.GameState.PAUSE);
        }

       float x = Input.GetAxis("Horizontal");
       float z = Input.GetAxis("Vertical");

         

        //Verificando se é preciso aplicar a gravidade
        float y = 0;
        if(!characterController.isGrounded){
           y = -_gravidade;
        }

       //Tratando movimentação do mouse
       float mouse_dX = Input.GetAxis("Mouse X") *3f;
       float mouse_dY = Input.GetAxis("Mouse Y")* .3f;

       ///peixe palahaco

    //    if(follow){
    //         GameObject.FindWithTag("peixep").transform.position.x += mouse_dX*slowdown;
    //         GameObject.FindWithTag("peixep").transform.position.y +=mouse_dY*slowdown;
    //         GameObject.FindWithTag("peixep").transform.position.z +=transform.forward * z;
    //     } 


       //Tratando a rotação da câmera
       cameraRotation += mouse_dY;
       Mathf.Clamp(cameraRotation, -75.0f, 75.0f);

       Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;

       characterController.Move(direction * _baseSpeed * Time.deltaTime);
       transform.Rotate(Vector3.up, mouse_dX);
       playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);

       // zoom

       float fov = Camera.main.fieldOfView;
       fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
       fov = Mathf.Clamp(fov, minFov, maxFov);
       Camera.main.fieldOfView = fov;
    }

    void LateUpdate(){
        RaycastHit hit;
        Ray ray;
       
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            
            if( hit.collider.name == "tuba" || hit.collider.name == "tuba1" || hit.collider.name == "tuba2" || hit.collider.name == "tuba3" || hit.collider.name == "tuba4" || hit.collider.name == "tuba5"){
                    
                    print(hit.distance);
                    if (hit.distance < 4){
                        gm.lost = true;
                        gameObject.transform.position = originalPos;
                        follow = true;
                        AudioSource.PlayClipAtPoint(shark, this.gameObject.transform.position);
                        gm.ChangeState(GameManager.GameState.ENDGAME);
                    }
            }
            
            if(Input.GetMouseButtonDown(0)){

                print(hit.distance);
                print(hit.collider.name);
                
                if(hit.collider.name == "peixep" ||  hit.collider.name == "messagep"){
                        gm.speaker ="Marlin:";
                        print(gm.speaker);
                        gm.message = " Ela saiu faz um tempo e não voltou! Vi ela indo em direção ao beco dos tubarões";
                        follow= true;
                        gm.ChangeState(GameManager.GameState.CHAT);
                }

                else if(hit.collider.name == "peixer" ||  hit.collider.name == "messager"){
                        gm.speaker ="Luca:";
                        print(gm.speaker);
                        gm.message = " O marlin sabe! Eu vi ele perto da estação amarela ";
                        gm.ChangeState(GameManager.GameState.CHAT);
                }

                else if(hit.collider.name == "peixea" ||  hit.collider.name == "messagea"){
                        gm.speaker ="Gil:";
                        print(gm.speaker);
                        gm.message = " O Luca viu! Acho que ele foi para aquelas rochas para minha direita";
                        gm.ChangeState(GameManager.GameState.CHAT);
                }

                else if(hit.collider.name == "dori"){
                        
                        gameObject.transform.position = originalPos;
                        follow=false;
                        gm.ChangeState(GameManager.GameState.ENDGAME);
                        
                }

                 
            }
        }


    }

    public void manageSound()
    {
        gm.ChangeState(GameManager.GameState.SOUND);
        
    }

    public void gotoinfo()
    {
        gm.ChangeState(GameManager.GameState.INFO);
        
    }
}
