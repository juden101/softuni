using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour 
{
    float speed = 0.5f;
    public float timer = 0f;
    private float updateTimer;
    private bool isRotating;
    private bool isMoving;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Start");
        updateTimer = timer;
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isRotating)
        {
            this.transform.Rotate(speed, 0f, 0f);
        }


	}

    void FixedUpdate()
    {
        if (isRotating)
            return;

        updateTimer -= Time.fixedDeltaTime;
        
        if (updateTimer <= 0f)
        {
            Debug.Log("Start rotate");
            isRotating = true;
            updateTimer = timer;
        }
    }
}
