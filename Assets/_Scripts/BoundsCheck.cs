using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To type the next 4 lines, start by typing /// and the nTab.
/// <summary>
/// Keeps a GameObject on screen.
/// Note that this only works for a n orthographic Main Camera at [0,0,0]
/// </summary>

public class BoundsCheck : MonoBehaviour
{
    [Header("Set In Inspector")]
    public float radius = 1f;

    [Header("Set Dynamically")]
    public float camWidth;
    public float camHeight;

    // Start is called before the first frame update
    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;

        if(pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
        }

    }
}
