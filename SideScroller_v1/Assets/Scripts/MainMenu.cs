using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // ekwiwalent:// SceneManager.LoadScene(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // przeładowuje do następnej sceny
    }
    public void Back()
    {
        SceneManager.LoadScene(1);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(2);
    }
}
