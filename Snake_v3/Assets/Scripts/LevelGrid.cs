using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CodeMonkey;

public class LevelGrid
{
    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    private int width;
    private int height;
    private Snake snake;

    public LevelGrid(int width, int height) 
    {
        this.width = width;
        this.height = height;
        //FunctionPeriodic.Create(SpawnFood, 1f);
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;

        SpawnFood(); // utworzenie jedzenia jak zaczynamy poziom 
    }

    private void SpawnFood()
    {
        do {
        foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height)); // tworzenie pozycji dla jedzenia
        } while (snake.GetGridPosition() == foodGridPosition);

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));                    // wizualizacja
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.foodSprite;     // i.foodSprite - odniesienie do GameAssets
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y); //locating in correct position 
    }

    public void SnakeMoved(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            CMDebug.TextPopupMouse("SnIki snEke zjadL jaPłko");
        }
    }
}
