using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 抓取道具
/// </summary>

public class Grap : MonoBehaviour
{


    bool canGrap = false;
    private GameObject item = null;


    private void Update()
    {
        if(canGrap&&Input.GetKeyDown(KeyCode.F))
        {
            GetItem();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag==ConstKey.TAG_SPRITE_ITEM)
        {
            canGrap = false;
            item = null;

        }
        
    }

    void OnTriggerEnter2D(Collider2D collidedObject)
    {

        if (collidedObject.tag == ConstKey.TAG_SPRITE_ITEM)
        {
            canGrap = true;
            item = collidedObject.gameObject;

        }

    }


    private void GetItem()
    {
        if (UIManager.instance.curItem >= 4)
        {
            return;
        }
        UIManager.instance.AddUIItem(item.GetComponent<SpriteItem>().ItemType);
        Destroy(item);
    }




}
