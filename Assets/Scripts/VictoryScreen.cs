using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public void Setup(int score){
        gameObject.SetActive(true);
        livesText.text = score.ToString() + " lives left";
    }

    public void RestartButton(){
        SceneManager.LoadScene("MiniGame");
    }


    public void ExitButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
