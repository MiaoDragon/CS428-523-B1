using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float dz = 1;
    float dx = 1;
    float dy = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // WSAD to move the position of the camera
        // space to move the camera higher
        // shift to move the camera lower
        if (Input.GetKey("w"))
        {
            Vector3 current_pos = this.transform.position;
            current_pos[2] = current_pos[2] + dz;
            this.transform.position = current_pos;
        }
        if (Input.GetKey("s"))
        {
            Vector3 current_pos = this.transform.position;
            current_pos[2] = current_pos[2] - dz;
            this.transform.position = current_pos;
        }
        if (Input.GetKey("a"))
        {
            Vector3 current_pos = this.transform.position;
            current_pos[0] = current_pos[0] - dx;
            this.transform.position = current_pos;
        }
        if (Input.GetKey("d"))
        {
            Vector3 current_pos = this.transform.position;
            current_pos[0] = current_pos[0] + dx;
            this.transform.position = current_pos;
        }
        if (Input.GetKey("space"))
        {
            Vector3 current_pos = this.transform.position;
            current_pos[1] = current_pos[1] + dy;
            this.transform.position = current_pos;
        }
        if (Input.GetKey("left shift"))
        {
            Vector3 current_pos = this.transform.position;
            current_pos[1] = current_pos[1] - dy;
            this.transform.position = current_pos;
        }
        if (Input.GetKey("right shift"))
        {
            Vector3 current_pos = this.transform.position;
            current_pos[1] = current_pos[1] - dy;
            this.transform.position = current_pos;
        }


    }
}
