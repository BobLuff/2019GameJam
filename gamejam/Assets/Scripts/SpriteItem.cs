using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteItem : MonoBehaviour
{

    public ItemType ItemType;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
        LoadImage();
        
    }


    private void LoadImage()
    {
        string path = ItemType.ToString();
        sprite.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
    }



}
