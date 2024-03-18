using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
   // Rigidbody of the player.
   private Rigidbody rb;   
   // Movement along X and Y axes.
   private float movementX;
   private float movementY;   
   // Speed at which the player moves.
   public float speed = 0;    
   private int count;
   private int lives;

   public TextMeshProUGUI countText;
   public TextMeshProUGUI livesText;


   public GameOverScreen gameOverScreen;
   public VictoryScreen victoryScreen;
   [SerializeField] private TextMeshProUGUI timerText;
   [SerializeField]float remainingTime;

   private float timeSpecial;
   private float timeSpecialLives;




   // Start is called before the first frame update.
   void Start() {
      // Get and store the Rigidbody component attached to the player.
         rb = GetComponent<Rigidbody>();
         count = 0;
         lives = 30;
         SetCountText();
         SetLiveText();
         Time.timeScale = 1;
   }
 
   // This function is called when a move input is detected.
   void OnMove(InputValue movementValue){
      // Convert the input value into a Vector2 for movement.
      Vector2 movementVector = movementValue.Get<Vector2>();

      // Store the X and Y components of the movement.
      movementX = movementVector.x; 
      movementY = movementVector.y; 
    }

   void SetCountText() {
      countText.text =  "Score: " + count.ToString();
      
      // Check if the count has reached or exceeded the win condition.
      if (count >= 42){
         Victory();
      }
   }

   void SetLiveText() {
      livesText.text = lives.ToString();
      
      // Check if the count has reached or exceeded the win condition.
      if (lives <= 0){
         GameOver();
      }
   }

   void setTimerText(){
      int minutes = Mathf.FloorToInt(remainingTime / 60);
      int seconds = Mathf.FloorToInt(remainingTime % 60);
      timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
   }
   
   

   // FixedUpdate is called once per fixed frame-rate frame.
   private void FixedUpdate() {
      // Create a 3D movement vector using the X and Y inputs.
      Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

      // Apply force to the Rigidbody to move the player.
      rb.AddForce(movement * speed); 
    }

   void OnTriggerEnter(Collider other) {
      // Check if the object the player collided with has the "PickUp" tag.
      if (other.gameObject.CompareTag("PickUp")) {
         // Deactivate the collided object (making it disappear).
         other.gameObject.SetActive(false);
         count = count + 1;
         SetCountText();
      } else if (other.gameObject.CompareTag("TripleCandle")){
         lives = lives -1;
         timeSpecialLives = 5;
         livesText.color = Color.red;
         SetLiveText();
      } else if (other.gameObject.CompareTag("PlusLive")){
         other.gameObject.SetActive(false);
         timeSpecialLives = 5;
         lives = lives + 1;
         livesText.color = Color.green;
         SetLiveText();
      } else if (other.gameObject.CompareTag("PlusTime")){
         other.gameObject.SetActive(false);
         remainingTime = remainingTime +  15;
         timeSpecial = 10;
         timerText.color = Color.green;
         setTimerText();
      }
   }


    void Update(){
        if(remainingTime <= 0){
            remainingTime = 0;
            timerText.color = Color.red;
        }
        else{
            remainingTime -= Time.deltaTime;
            if (timeSpecial > 0){
               timeSpecial -= Time.deltaTime;
            } else timerText.color = Color.white;
            if (timeSpecialLives > 0){
               timeSpecialLives -= Time.deltaTime;
            } else livesText.color = Color.black;
        }
         setTimerText();
    }

   public void GameOver(){
      gameOverScreen.Setup(count);
      Time.timeScale = 0;
   }

   public void Victory(){
      victoryScreen.Setup(lives);
      Time.timeScale = 0;
   }
}