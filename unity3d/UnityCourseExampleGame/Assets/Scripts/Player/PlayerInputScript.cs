using UnityEngine;
using System.Collections;

public class PlayerInputScript : MonoBehaviour 
{
    Transform playerTransform;
    Rigidbody2D playerRigidBody;
    Transform gunTransform;

    private bool isGamePaused;
    public bool isOnSmallPlatform;
    private Transform currentSmallPlatform;
    int score;
    public GUITexture btnLeft;
    public GUITexture btnRight;
    public GUITexture btnJumpOne;
    public GUITexture btnJumpTwo;
    public GUIText scoreText;

    PlayerControlScript playerControlScript;
    PlayerLogicScript playerLogicScript;

	private void Start ()
    {
        playerTransform = this.transform;
        playerRigidBody = playerTransform.rigidbody2D;
        playerControlScript = GetComponent<PlayerControlScript>();
        playerLogicScript = GetComponent<PlayerLogicScript>();
        playerLogicScript.pauseGame += PauseGame;
        AudioManager.InitAudioManager(); 
	}

	private void FixedUpdate () 
    {
        UpdatePlayerInput();
        UpdateSmallPlatformState();
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GuiManager.IsGuiMatter();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("smallPlatform") || collision.collider.tag.Equals("platform"))
        {
            //Debug.Log("OnCollisionEnter");
            playerControlScript.playerState = PlayerState.Running;
        }

        if (collision.collider.tag == "smallPlatform")
        {
            if (!isOnSmallPlatform)
            {
                isOnSmallPlatform = true;
            }

            if (currentSmallPlatform != collision.transform)
            {
                currentSmallPlatform = collision.transform;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "smallPlatform")
        {
            if (isOnSmallPlatform)
            {
                isOnSmallPlatform = false;
            }

            playerControlScript.platformDelta = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "platform")
        {
            //Reset game
            Application.LoadLevel(Application.loadedLevel);
        }
        
        if (col.tag == "Coin")
        {
            if (scoreText != null)
            {
                score++;
                scoreText.text = score.ToString();
                Destroy(col.gameObject);
                AudioManager.PlayAudioSound(AudioSounds.CollectCoin, false);
            }
        }
    }

    private void UpdateSmallPlatformState()
    {
        if(!isOnSmallPlatform || isGamePaused)
        {
            return;
        }

        playerControlScript.platformDelta = currentSmallPlatform.rigidbody2D.velocity.x;
        
    }

    private void UpdatePlayerInput()
    {
        if (isGamePaused)
        {
            return;
        }

        if (playerControlScript.playerState != PlayerState.Dead)
        {
            float horizontalIncrement = GetHorizontalInput();

            if (playerControlScript.playerState == PlayerState.Jumping)
            {
                horizontalIncrement *= 2f;
            }
            
            //flip player
            if (horizontalIncrement > 0 && playerTransform.localScale.x > 0f)
            {
                playerTransform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }
            else if (horizontalIncrement < 0f && playerTransform.localScale.x < 0f)
            {
                playerTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }

            if (horizontalIncrement != 0f)
            {
                if (playerControlScript.playerState == PlayerState.Idle)
                {
                    playerControlScript.playerState = PlayerState.Running;
                }

                playerControlScript.MovePlayer(horizontalIncrement);
            }
            else if (playerControlScript.playerState == PlayerState.Running)
            {
                playerControlScript.manageAnimations.PlayCharactherAnimation(PlayerAnimations.Idle, true, true);
                playerControlScript.playerState = PlayerState.Idle;
            }
        }

        if (GetVerticalInput())
        {
            playerControlScript.Jump();
        }

    }

    private bool GetVerticalInput()
    {
        if (isGamePaused)
        {
            return false;
        }
#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8)
        if (Input.touchCount < 1)
        {
            return false;
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            if ((btnJumpOne != null && btnJumpOne.HitTest(Input.GetTouch(i).position)) || (btnJumpTwo != null && btnJumpTwo.HitTest(Input.GetTouch(i).position)))
            {
                Debug.Log("btnJump");
                return true;
            }
        }

        return false;
#else
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            return true;
        }
        else
        {
            return false;
        }
#endif
    }

#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8)
    float leftTurn = 0f;
    float rightTurn = 0f;
#endif
    private float GetHorizontalInput()
    {
        if (isGamePaused)
        {
            return 0f;
        }
#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8)

        if (Input.touchCount < 1)
        {
            rightTurn = 0f;
            leftTurn = 0f;
            return 0f;
        }

        rightTurn = 0f;
        leftTurn = 0f;

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (btnRight != null && btnRight.HitTest(Input.GetTouch(i).position))
            {
                Debug.Log("btnRight");
                rightTurn = 1f;
            }
            else if (btnLeft != null && btnLeft.HitTest(Input.GetTouch(i).position))
            {
                Debug.Log("btnLeft");
                leftTurn = -1f;
            }
        }

        return leftTurn + rightTurn;

#else
        return Input.GetAxis("Horizontal");
#endif
    }

    private void PauseGame()
    {
        isGamePaused = !isGamePaused;
        playerRigidBody.isKinematic = !playerRigidBody.isKinematic;
        
    }
}

public enum PlayerState
{
    Idle,
    Running,
    Jumping,
    Dead
}