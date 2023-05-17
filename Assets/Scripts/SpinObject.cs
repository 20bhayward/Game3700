using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float speed = 10f;
    public bool rotateX = false;
    public bool rotateY = true;
    public bool rotateZ = false;

    void Update()
    {
        Vector3 rotationAxis = new Vector3(rotateX ? 1 : 0, rotateY ? 1 : 0, rotateZ ? 1 : 0);
        transform.Rotate(rotationAxis, speed * Time.deltaTime);
    }
}
