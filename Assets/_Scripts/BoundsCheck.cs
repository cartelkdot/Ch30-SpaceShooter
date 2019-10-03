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
        if(pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
        }
        if(pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
        }
        if(pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
        }
        transform.position = pos;
    }

    //Draw the bounds in the Scene pane using OnDrawGizmos()
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
