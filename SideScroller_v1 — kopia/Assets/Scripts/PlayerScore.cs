using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Pozwala na zmianę sceny 

public class PlayerScore : MonoBehaviour
{
    private float timeLeft = 5;
    public int playerScore = 0;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if( timeLeft < 0.1f)
        {
            //SceneManager.LoadScene("_GameOver"); // Można po nazwie pliku lub po indeksie w BuildSettings  
            SceneManager.LoadScene(0);
        }
    }
}
