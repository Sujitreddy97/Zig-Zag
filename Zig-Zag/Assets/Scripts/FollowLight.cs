using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLight : MonoBehaviour
{
    [SerializeField] GameObject ball;
    private Vector3 offset;
    public bool gameOver;
    public float lerpRate = 2f;

    private void Start()
    {
        offset = ball.transform.position + transform.position;
       
    }

    private void Update()
    {
        if(!gameOver)
        {
             Follow();
            //transform.position = ball.transform.position + offset;
        }

    }
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position + offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
