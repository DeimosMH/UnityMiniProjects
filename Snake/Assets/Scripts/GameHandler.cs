using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameHandler.Start"); //Debug log on start

        /************REFERENCJA ASSETU W GAMEASSETS***************/
        /*
        GameObject snakeHeadGameObject = new GameObject(); 
        SpriteRenderer snakeSpriteRenderer = snakeHeadGameObject.AddComponent<SpriteRenderer>() ;
        snakeSpriteRenderer.sprite = GameAssets.i.snakeHeadSprite; // asset reference (referencja)
        */
        /*
        int number = 0;
        FunctionPeriodic.Create(() =>                   //Powoduje działanie co pewien czas
        {
            CMDebug.TextPopupMouse("Ding! " + number);  //Wyświetla cos + liczbę 
            number++;
        }, .5f);                                        // .3f - co 0,3 sekundy 
    */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
