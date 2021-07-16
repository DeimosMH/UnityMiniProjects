using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer; // przemieszczenie co pewien czas
    private float gridMoveTimerMax;

    // Start is called before the first frame update
    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);    // automatyczna pozycja węża na początku
        gridMoveTimerMax = .5f;                   // co sekundę przemieszczenie 
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0); // przemieszczenie do czasu
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInput();          //DEKLARACJA FUNKCJI - sterowanie
        HandleGridMovement();   //                   - poruszanie 
    }

    private void HandleInput()  //DEFINICJA FUNKCJI
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { //sterowanie strzałki
            if (gridMoveDirection.y != -1) //kiedy porusza się snake w dół - nie może iść w górę 
            {
                gridMoveDirection.y = +1; // modyfikujemy moveDirection
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
            gridPosition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax; //zresetowanie timera

            transform.position = new Vector3(gridPosition.x, gridPosition.y);

            // Modyfikujemy kąty Eulera (układ 3 kątów) - dla 2D to jest Z
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90); // -90 stopni bo w Unity 0 to jest w prawo
        }
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //zmiana kątów z funkcji tangens i konwersja z radianów na stopnie 
        if (n < 0)
            n += 360;

        return n;
    }
}
