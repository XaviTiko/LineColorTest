using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Controller mainController;
    public GameObject loseParticleSystem;
    public GameObject[] loseUnableElements = new GameObject[2];//0 particles, 1 cube
    GameObject obstacle;//need to delete if player click continue
    public Color mainColor;
    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        print("Collider is " + other.tag);
        if (other.tag == "Finish")
        {
            winFunction();
        }
        else if (other.tag == "Obstacle")
        {
            obstacle = other.gameObject;
            loseFunction();
        }
    }
    void winFunction() {
        mainController.WinFunc();
    }

    void loseFunction()
    {
        mainController.LoseFunc();
        foreach (GameObject element in loseUnableElements)
        {
            element.SetActive(false);
        }
        GetComponent<BoxCollider>().enabled = false;
        loseParticleSystem.SetActive(true);
        loseParticleSystem.GetComponent<ParticleSystem>().Play();

    }
}
