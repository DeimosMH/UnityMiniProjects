using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Snake snake; //field for snake dla referencji

    private LevelGrid levelGrid;

    private void Start()     // Start is called before the first frame update
    {
        Debug.Log("GameHandler.Start"); //Debug log on start

        levelGrid = new LevelGrid(20, 20);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
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
