using UnityEngine;
using System;
using System.Collections;

public class PlatformScript : MonoBehaviour 
{

    public bool isMoving;
    public float speed;
    public Transform playerTransform;
    private bool isGamePaused;

    public void GenerateCoins(GameObject coinPrefab)
    {
        int number = UnityEngine.Random.Range(1, 5);

        float xOffset = 0f;

        float offset = (3.21f - number * 0.5f - (number - 1) * 0.1f) / 2;
        offset -= 1.605f;

        for (int i = 0; i <= number; i++)
        {
            GameObject currentCoin = GameObject.Instantiate(coinPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            currentCoin.transform.parent = this.transform;
            currentCoin.transform.localPosition = new Vector3(xOffset + offset, 0.5f, 0f);
            xOffset += 0.57f;
        }
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        if (!isMoving || isGamePaused)
        {
            return;
        }

        if (speed == 0f)
        {
            return;
        }

        transform.rigidbody2D.velocity = new Vector2(-speed, transform.rigidbody2D.velocity.y);

        //platform went outside the screen
        if (transform.position.x <= -10f)
        {
            if (playerTransform != null)
            {
                playerTransform.GetComponent<PlayerLogicScript>().pauseGame -= PauseGame;
            }

            Destroy(this.gameObject);
        }
	}

    public void PauseGame()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            transform.rigidbody2D.velocity = Vector2.zero;
        }
    }
}
