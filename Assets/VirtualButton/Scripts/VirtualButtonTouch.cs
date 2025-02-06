using UnityEngine;
using Vuforia;

public class VirtualButtonTouch : MonoBehaviour
{
    public GameObject cubeButton;  // Assign the cube button in the Inspector
    public GameObject targetObject;  // Object that will be affected by button press

    void Update()
    {
        if (Input.touchCount > 0)  // Check if user touches the screen
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == cubeButton)  // Check if the cube is touched
                    {
                        Debug.Log("Virtual Button Pressed!");
                        targetObject.SetActive(!targetObject.activeSelf); // Toggle object visibility
                    }
                }
            }
        }
    }
}
