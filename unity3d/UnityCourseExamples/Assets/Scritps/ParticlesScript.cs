using UnityEngine;
using System.Collections;

public class ParticlesScript : MonoBehaviour 
{
    ParticleSystem particleSystem;

	// Use this for initialization
	void Start () 
    {
        particleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (particleSystem.isPlaying)
            {
                Debug.Log("Stop");
                particleSystem.Stop();
            }
            else
            {
                Debug.Log("Play");
                particleSystem.Play();
            }
            
        }
	
	}
}
