using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoteter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Position = Input.mousePosition;
        float LeftBorder = 100;
        float RightBorder = Screen.width - 100;

        if (Position.x < LeftBorder)
        {
            float speed = 100 - Position.x;
            transform.Rotate(Vector3.up * -1 * Time.deltaTime * speed);
        }

        if (Position.x > RightBorder)
        {
            float speed1 = Position.x - RightBorder;
            transform.Rotate(Vector3.up * 1 * Time.deltaTime * speed1);
        }

        if (transform.localRotation.eulerAngles.y > 30 && transform.localRotation.eulerAngles.y < 180)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, 30, transform.localRotation.eulerAngles.z);
        }

        if (transform.localRotation.eulerAngles.y < 330 & transform.localRotation.eulerAngles.y > 90)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, -30, transform.localRotation.eulerAngles.z);
        }

    }
}
