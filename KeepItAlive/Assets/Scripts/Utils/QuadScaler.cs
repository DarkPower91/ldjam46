using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScaler : MonoBehaviour
{
    public bool scaleWidth = false;
    public bool scaleHeight = false;

    // Start is called before the first frame update
    void Start()
    {
        double height = Camera.main.orthographicSize * 2.0;
        double width = height * Screen.width / Screen.height;

        Vector3 newScale = transform.localScale;

        if(scaleWidth)
        {
            newScale[0] = (float)width;
        }    
        if(scaleHeight)
        {
            newScale[1] = (float)height;
        }

        transform.localScale = newScale;
    }
}
