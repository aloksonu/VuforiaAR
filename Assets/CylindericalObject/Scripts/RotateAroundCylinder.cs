using UnityEngine;

public class RotateAroundCylinder : MonoBehaviour
{
    public Transform cylinder;  // Reference to the cylinder
    public float speed = 50f;   // Rotation speed

    void Update()
    {
        if (cylinder != null)
        {
            // Rotate around the cylinder's Y-axis
            // transform.RotateAround(cylinder.position, Vector3.up, cylinder.position);
            transform.Rotate(speed * Time.deltaTime, 0, 0);
        }
    }
}
