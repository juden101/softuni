using UnityEngine;
using System.Collections;

public class ParalaxEffectScript : MonoBehaviour 
{
    public float scrollSpeed;
    private Vector2 savedOffset;
    private bool isPaused;
    PlayerLogicScript playerLogicScript;
    public float fullscreenXRatio = 1f;
    public float fullscreenYRatio = 1f;
    public float viewPortXPosition = 0.5f;
    public float viewPortYPosition = 0.5f;

	// Use this for initialization
	void Start () 
    {
        savedOffset = renderer.sharedMaterial.GetTextureOffset("_MainTex");
        playerLogicScript = GameObject.FindWithTag("Player").GetComponent<PlayerLogicScript>();

        if (playerLogicScript == null)
        {
            Debug.Log("Unable to get player input script!");
        }
        else
        {
            playerLogicScript.pauseGame += PauseGame;
        }

        transform.localScale = new Vector3(1f, 1f, 1f);

        float width = renderer.bounds.size.x / fullscreenXRatio;
        float height = renderer.bounds.size.y / fullscreenYRatio;

        double worldScreenHeight = Camera.main.orthographicSize * 2.0;
        double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3((float)(worldScreenWidth / width), (float)(worldScreenHeight / height), transform.localScale.z);
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewPortXPosition, viewPortYPosition, 2f));
	}
	
	// Update is called once per frame
    float xOffset;
	void FixedUpdate () 
    {
        if (isPaused)
        {
            return;
        }

        xOffset += Time.fixedDeltaTime * scrollSpeed; //You could use that but if game got paused -> on resume value will not be correct Mathf.Repeat(Time.time * scrollSpeed, 1);
        if (xOffset >= 1f)
        {
            xOffset = 0f;
        }

        Vector2 offset = new Vector2(xOffset, savedOffset.y);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
	}

    void OnDisable()
    {
        renderer.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);

        if (playerLogicScript != null)
        {
            playerLogicScript.pauseGame -= PauseGame;
        }
    }

    private void PauseGame()
    {
        isPaused = !isPaused;

        if (isPaused)
        {

        }
    }
}
