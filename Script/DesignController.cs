using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignController : MonoBehaviour
{
    public Color colorOfCube;
    public Color colorOfSpline;

    public Material cube;
    public Material splineTile;
    public Material splineExtrusion;
    public Material bubbles;
    public TrailRenderer trail;

    float coeficcient = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        cube.color = colorOfCube;
        splineExtrusion.color = colorOfSpline;
        trail.startColor = trail.endColor = colorOfCube;
        splineTile.color = new Color(colorOfSpline.r - coeficcient, colorOfSpline.g - coeficcient, colorOfSpline.b - coeficcient);//darker then spline
        bubbles.color = new Color(colorOfCube.r - coeficcient, colorOfCube.g - coeficcient, colorOfCube.b - coeficcient);//darker then cube
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
