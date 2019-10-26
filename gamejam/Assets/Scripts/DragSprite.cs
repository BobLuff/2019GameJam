using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 拖拽UI物体，跟随鼠标移动
/// </summary>
public class DragSprite : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    Vector3 orginPos;

    RectTransform rt;
    UIItem item;
    // Start is called before the first frame update
    void Start()
    {
        rt = transform.GetComponent<RectTransform>();
        item = transform.GetComponent<UIItem>();
        orginPos = rt.position;

    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item.GetItemType()==ItemType.Null)
        {
            return;
        }

        SetDraggedPosition(eventData);

        gameObject.GetComponent<Image>().raycastTarget = false;

    }


    public void OnDrag(PointerEventData eventData)
    {
        if (item.GetItemType() == ItemType.Null)
        {
            return;
        }


        SetDraggedPosition(eventData);

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        gameObject.GetComponent<Image>().raycastTarget = true;
        if (item.GetItemType() == ItemType.Null)
        {
            return;
        }

        GameObject room;
        if (OnRayCastSprite(out room))
        {

            roomManager roomManager = room.GetComponent<roomManager>();
            if (roomManager!=null&& roomManager.lightStatus == false)
            {

                roomManager.lightOn();
                if (item.GetItemType() == ItemType.GlowStick)
                {
                    roomManager.Timer(ConstKey.GLOW_STICK_SECOND);

                }
                item.SetItemType(ItemType.Null);
                UIManager.instance.curItem--;
            }


        }
        else
        {

            GameObject go = eventData.pointerCurrentRaycast.gameObject;
            if(go!=null&&go.tag==ConstKey.TAG_UI_ITEM)
            {
                go.GetComponent<UIItem>().SetItemType(item.GetItemType());
                item.SetItemType(ItemType.Null);
            }

        }





        rt.position = orginPos;

    }



    private bool OnRayCastSprite(out GameObject roomObj)
    {
        roomObj = null;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log("clicked object name is ---->" + hit.collider.gameObject);
            roomObj = hit.collider.gameObject;
            return true;
        }

        return false;

    }




    private void SetDraggedPosition(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        if(RectTransformUtility.ScreenPointToWorldPointInRectangle(rt,eventData.position,eventData.pressEventCamera,out globalMousePos))
        {
            rt.position = globalMousePos;
  

        }


    }

}
