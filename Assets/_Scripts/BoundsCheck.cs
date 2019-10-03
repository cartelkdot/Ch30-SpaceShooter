﻿using System.Collections;
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
    public bool keepOnScreen = true;

    [Header("Set Dynamically")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;
    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

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
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        if(pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            isOnScreen = false;
            offRight = true;
        }
        if(pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            isOnScreen = false;
            offLeft = true;
        }
        if(pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
            isOnScreen = false;
            offUp = true;
        }
        if(pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
            isOnScreen = false;
            offDown = true;
        }

        isOnScreen = !(offRight || offLeft || offUp || offDown);
        if(keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
        
    }

    //Draw the bounds in the Scene pane using OnDrawGizmos()
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
