using UnityEngine;
using System.Collections;

public class WreckingBall : MonoBehaviour {

	// Use this for initialization
	void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.AddForce(transform.right * 5f, ForceMode.Impulse);
        }
	}
	
	
}
