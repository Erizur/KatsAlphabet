using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    public bool isHidden = false;
    public GameObject minimap;
    public Camera cam;

    void Start()
    {
        minimap.SetActive(isHidden);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            isHidden = !isHidden;
            minimap.SetActive(isHidden);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            if(cam.orthographicSize < 120) cam.orthographicSize += 5;
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            if(cam.orthographicSize > 5) cam.orthographicSize -= 5;
        }
    }
}
