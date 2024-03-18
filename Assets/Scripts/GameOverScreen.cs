using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{

    public TextMeshProUGUI pointsText;
    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " points";
    }

    public void RestartButton(){
        SceneManager.LoadScene("MiniGame");
    }


    public void ExitButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
