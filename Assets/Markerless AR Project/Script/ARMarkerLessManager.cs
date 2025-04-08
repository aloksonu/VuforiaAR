using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMarkerLessManager : MonoBehaviour
{
    public GameObject car;
    public float speed = 5f; // Car movement speed
    private bool isMoving = false;
    private Vector3 initialPosition; // Store the initial position
    public AudioSource carAudio; // Reference to the AudioSource component

    void Start()
    {
        initialPosition = car.transform.position;  // Save the starting position
    }
    void Update()
    {
        if (isMoving)
        {
            MoveCar();
        }
    }

    public void OnTouchStart()
    {
        isMoving = true;
        if (carAudio != null && !carAudio.isPlaying)
        {
            carAudio.Play();  // Play sound when touch starts
        }
    }

    public void OnTouchEnd()
    {
        isMoving = false;
        if (carAudio != null && carAudio.isPlaying)
        {
            carAudio.Stop();  // Stop sound when touch ends
        }
    }

    void MoveCar()
    {
        car.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void OnTargetFound()
    {

    }
    public void OnTargetLost()
    {
        car.transform.position = initialPosition;
        carAudio.Stop();  // Stop sound when touch ends
    }
}
