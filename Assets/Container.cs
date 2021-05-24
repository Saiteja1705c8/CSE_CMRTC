using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    public float time;
    public Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            this.gameObject.GetComponent<Image>().color = Color.black;
        }
        if (time < 0)
        {
            this.gameObject.GetComponent<Image>().color = defaultColor;
        }
    }
}
