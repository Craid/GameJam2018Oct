using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

    public FloatingText popupText;
    public GameObject canvas;
    private int cordX = 1920;
    private int cordY = 1080;

    public void CreateFloatingText(string text, Transform location){
        //   Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);

        Vector3 v3 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float v2X = (cordX * v3.x) * 0.3807292f;
        float v2Y = (cordY * v3.y) * 0.3807292f;
        Vector3 v2 = new Vector3(v2X, v2Y, 0);
        Debug.Log(v2);

        //FloatingText instance = Instantiate(popupText, Camera.main.ScreenToViewportPoint(Input.mousePosition),new Quaternion(), canvas.transform);
        FloatingText instance = Instantiate(popupText, canvas.transform, false);
        //Debug.Log(Input.mousePosition);
        Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        //instance.transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        // instance.transform.SetParent(canvas.transform, false);

        instance.transform.position = v2;
        instance.SetText(text);
    }
}
