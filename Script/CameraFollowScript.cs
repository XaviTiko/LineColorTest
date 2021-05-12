using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform followObject;
    Vector3 gap;
    // Start is called before the first frame update
    void Start()
    {
        gap = transform.position - followObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followObject.position + gap;
    }
}
