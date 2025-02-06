using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class VirtualButtonAlternative : MonoBehaviour
{
    public GameObject targetObject; // Object to interact with

    void OnMouseDown()
    {
        Debug.Log("Virtual Button Pressed!");
        //targetObject.SetActive(!targetObject.activeSelf); // Toggle object visibility
        targetObject.transform.DOMoveX(this.transform.position.x,-0.268f);
    }
}
