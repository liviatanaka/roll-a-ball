using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField]float remainingTime;

    void Update(){
        if(remainingTime <= 0){
            remainingTime = 0;
            timerText.color = Color.red;
        }
        else{
            remainingTime -= Time.deltaTime;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnTriggerEnter(Collider other) {

    if (other.gameObject.CompareTag("PlusTime")){
         remainingTime += 10;
      }
   }


}
