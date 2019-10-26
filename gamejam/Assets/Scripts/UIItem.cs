using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ItemType
{
    GlowStick,
    Battery,
    Null



}


public class UIItem : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType=ItemType.Null;

    private Image image;
    // Start is called before the first frame update      

   
    void Start()
    {
        image = transform.GetComponent<Image>();
        LoadImage();
        
    }

    public ItemType GetItemType()
    {
        return itemType;
    }

    public void SetItemType(ItemType type)
    {
        itemType = type;
        LoadImage();

    }

    private void LoadImage()
    {
        string path = itemType.ToString();
        image.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
    }


}                                                                                
