using UnityEngine;
using System.Collections;

public delegate void PauseGame();

public class PlayerLogicScript : MonoBehaviour
{
    public event PauseGame pauseGame;
    public GUITexture btnPause;
    public GUITexture btnClose;

	// Use this for initialization
	void Start ()
    {
        GuiManager.InitGui();

        //add the xisting subscriber to the event
        GameObject existingPlatform = GameObject.FindGameObjectWithTag("smallPlatform");
        if (existingPlatform != null)
        {
            pauseGame += existingPlatform.GetComponent<PlatformScript>().PauseGame;
        }


	}


	// Update is called once per frame
	void Update () 
    {
#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8)
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase != TouchPhase.Began)
            {
                return;
            }

            if (btnPause != null && btnPause.HitTest(Input.GetTouch(i).position))
            {
                pauseGame.Invoke();
            }
            else if (btnClose != null && btnClose.HitTest(Input.GetTouch(i).position))
            {
                Application.Quit();
            }
        }
#else
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        if (btnPause != null && btnPause.HitTest(Input.mousePosition))
        {
            pauseGame.Invoke();
        }
        else if (btnClose != null && btnClose.HitTest(Input.mousePosition))
        {
            Application.Quit();
        }
#endif
	}

}
