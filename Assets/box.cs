using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class box : MonoBehaviour
{
    public float time
    {
        get;    set;
    }
    public Color defaultColor;
    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            this.gameObject.GetComponent<Image>().color = Color.black;
        }
        if(time < 0)
        {
            this.gameObject.GetComponent<Image>().color = defaultColor;
        }
    }
    public void getInput()
    {
        if(time > 0)
        {
            GameObject g = GameObject.Find("ReflexioneOne_GameManager");
            g.GetComponent<ReflexioneOne_GameManager>().increaseScore();
        }
        if(time < 0)
        {
            GameObject g = GameObject.Find("ReflexioneOne_GameManager");
            g.GetComponent<ReflexioneOne_GameManager>().decreaseScore();
        }
    }
}
