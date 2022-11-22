using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float speed = 0.1f;
    private Vector3 moveVector;
    void Update()
    {      
        cameraMove();
    }
    private void cameraMove()
    {
        float xMove = Input.GetAxis("Mouse X");
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        float yMove = Input.GetAxis("Mouse Y");
        float zMove = Input.GetAxis("Mouse ScrollWheel");
        moveVector = new Vector3(xMove, yMove, zMove);
        if (Input.GetKey(KeyCode.Mouse1))
        {
            this.gameObject.transform.Translate(new Vector3(hMove * speed, 0f, vMove * speed));
            this.gameObject.transform.Rotate(moveVector);
            
        }
    }
}
