using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMove : MonoBehaviour
{
    private Camera cam;
    public Rigidbody rb;

    public float lerpValue;
    public float minY,maxY;
    public float minX,maxX;
    public float speed;

    private bool isGameEnded = false;
    void Start()
    {
        cam = Camera.main;
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameEnded){
            rb.velocity = Vector3.forward * speed * Time.deltaTime;
        }

        if(Input.GetButton("Fire1")){
            ChangeScale();
        }
    }

    private void ChangeScale(){

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        Vector3 moveVec = cam.ScreenToWorldPoint(mousePos);

        float x = transform.localScale.x;
        moveVec.z = transform.localScale.z;
        moveVec.y *= 2f;
        moveVec.y = Mathf.Clamp(moveVec.y,minY,maxY);

        x = maxY/moveVec.y;

        moveVec.x = Mathf.Clamp(x,minX,maxX);

        transform.localScale = moveVec;

        JellyGhost.instance.ChangeScaleOfGhost(moveVec);
    }
}
