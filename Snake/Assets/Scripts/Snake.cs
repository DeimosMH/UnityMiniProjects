using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10); // automatyczna pozycja węża na początku
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){ //sterowanie strzałki
            gridPosition.y += 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        { //sterowanie strzałki
            gridPosition.y -= 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        { //sterowanie strzałki
            gridPosition.x += 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        { //sterowanie strzałki
            gridPosition.x -= 1;
        }

        transform.position = new Vector3(gridPosition.x, gridPosition.y);
    }
}
