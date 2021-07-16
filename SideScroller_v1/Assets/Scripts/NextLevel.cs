using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Finish")
        {
            FadeToLevel();
        }
    }
    public void FadeToLevel() // moze byc string namelevel
    {
        animator.SetTrigger("Fade_Out");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
