using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    //aby uzyskać dostęp do public Sprite snakeHeadSprite z innej klasy
    public static GameAssets i; 
    // eg. GameAssets.i.snakeHeadSprite

    private void Awake() {
        i = this; //w ten sposob mamy dostęp do wsystkich pół za pomocą static reference
    }
    
    public Sprite snakeHeadSprite;
    public Sprite foodSprite; //LevelGrid
}
