using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CodeMonkey;
using CodeMonkey.Utils;

public class Snake : MonoBehaviour
{
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer; // przemieszczenie co pewien czas
    private float gridMoveTimerMax;
    private LevelGrid levelGrid;

    private int snakeBodySize;
    private List<Vector2Int> snakeMovePositionList; // used when we need to add size to snake body 

    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid; //przekazywanie referencji do Snake
    }

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);      // automatyczna pozycja węża na początku
        gridMoveTimerMax = .2f;                     // co sekundę. przemieszczenie 
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);   // przemieszczenie do czasu

        snakeBodySize = 1; 
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInput();                              // DEKLARACJA FUNKCJI - sterowanie
        HandleGridMovement();                       //                   - poruszanie 
    }

    private void HandleInput()  //DEFINICJA FUNKCJI
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { //sterowanie strzałki
            if (gridMoveDirection.y != -1)          //kiedy porusza się snake w dół - nie może iść w górę 
            {
                gridMoveDirection.y = +1;           // modyfikujemy moveDirection
                gridMoveDirection.x = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        { //sterowanie strzałki
            if (gridMoveDirection.y != +1)
            {
                gridMoveDirection.y = -1;
                gridMoveDirection.x = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        { //sterowanie strzałki
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection.x = +1;
                gridMoveDirection.y = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        { //sterowanie strzałki
            if (gridMoveDirection.x != +1)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
    }

    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime; //Przypisanie zegara systemowego do przemieszczenia o pole 
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax; //zresetowanie timera
            ////////
            snakeMovePositionList.Insert(0, gridPosition); // zanim poruszymy snakea dodajmy obecną pozycję do listy 
            
            if (snakeMovePositionList.Count >= snakeBodySize + 1) // sprawdzenie czy lista nie jest za duza na podstawie snakeBodySize to usuwamy 1 z listy 
            {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
            }

            for (int i = 0; i < snakeMovePositionList.Count; i++)
            {
                Vector2Int snakeMovePosition = snakeMovePositionList[i];
                World_Sprite worldSprite = World_Sprite.Create(new Vector3(snakeMovePosition.x, snakeMovePosition.y), Vector3.one * .5f, Color.white);
                FunctionTimer.Create(worldSprite.DestroySelf, gridMoveTimerMax);
            }
            ////////
            gridPosition += gridMoveDirection;
            
            transform.position = new Vector3(gridPosition.x, gridPosition.y);

            // Modyfikujemy kąty Eulera (układ 3 kątów) - dla 2D to jest Z
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90); // -90 stopni bo w Unity 0 to jest w prawo

            levelGrid.SnakeMoved(gridPosition);
        }
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //zmiana kątów z funkcji tangens i konwersja z radianów na stopnie 
        if (n < 0)
            n += 360;

        return n;
    }

    public Vector2Int GetGridPosition() 
    {
        return gridPosition;
    }
}
