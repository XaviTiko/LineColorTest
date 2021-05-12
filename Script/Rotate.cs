using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(-120, 120)]
    public int RotationSpeed;
    void Update()
    {
        transform.RotateAround(GetComponent<Renderer>().bounds.center, Vector3.up ,RotationSpeed * Time.deltaTime);
    }
}
