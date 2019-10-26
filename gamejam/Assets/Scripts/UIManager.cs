using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : UnitySingleton<UIManager>
{

   
    public int curItem=0;
    UIItem[] items;

    // Start is called before the first frame update
    void Start()
    {
        InitItemNum();
        
    }

    // Update is called once per frame
 


   
    public void AddUIItem(ItemType type)
    {
        curItem++;
        foreach(var item in items)
        {
            if(item.GetItemType()==ItemType.Null)
            {
                item.SetItemType(type);
                break;
            }
        }


    }




    private void InitItemNum()
    {
       items = transform.GetComponentsInChildren<UIItem>();

        foreach(var item in items)
        {
            if(item.GetItemType()!=ItemType.Null)
            {
                curItem++;
            }

        }

    }

}
