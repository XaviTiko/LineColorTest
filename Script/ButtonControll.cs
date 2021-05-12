using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonControll : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject.Find("Spline").GetComponent<Controller>().TapToPlayClicked();
    }

    // Start is called before the first frame update

}
