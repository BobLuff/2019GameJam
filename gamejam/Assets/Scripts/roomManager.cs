using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomManager : MonoBehaviour
{
    public Light light;

    public GameObject itemManager;
    public bool lightStatus = false;
    // Start is called before the first frame update
    void Start()
    {
        if(light==null)
        {
            Debug.LogError("Light needs attach to roomManager");
        }
    
        light.gameObject.SetActive(lightStatus);

        itemManager.SetActive(lightStatus);

        
    }




    public void lightOn()
    {
        lightStatus = true;
        light.gameObject.SetActive(lightStatus);
        itemManager.SetActive(lightStatus);


    }

    public void lightOff()
    {
        lightStatus = false;

        light.gameObject.SetActive(lightStatus);
        itemManager.SetActive(lightStatus);

    }


    /// <summary>
    /// 启动荧光棒的倒计时
    /// </summary>
    /// <param name="m"></param>
    public void Timer(int m)
    {
        StartCoroutine("CountDown", m);
    }


    IEnumerator CountDown(int second)
    {
 
        while (second > 0)
        {
            yield return new WaitForSeconds(1f);
            second--;
   
        }
        if (second <= 0)
        {
            // light off
            lightOff();
        }

    }







}
