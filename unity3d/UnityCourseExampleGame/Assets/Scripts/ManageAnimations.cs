using UnityEngine;
using System.Collections;

public class ManageAnimations : MonoBehaviour 
{
    Animator playerAnimator;
    int[] playerAnimationsHashes;
    int[] playerStatesHashes;
    
    // Use this for initialization
	void Start () 
    {
        playerAnimator = GetComponent<Animator>();

        playerAnimationsHashes = new int[4];
        playerAnimationsHashes[0] = Animator.StringToHash("Idle");
        playerAnimationsHashes[1] = Animator.StringToHash("Running");
        playerAnimationsHashes[2] = Animator.StringToHash("Die");
        playerAnimationsHashes[3] = Animator.StringToHash("Fight");

        playerStatesHashes = new int[4];
        playerStatesHashes[0] = Animator.StringToHash("Base Layer.IdleState");
        playerStatesHashes[1] = Animator.StringToHash("Base Layer.CharachterRun");
        playerStatesHashes[2] = Animator.StringToHash("Base Layer.CharachterDie");
        playerStatesHashes[3] = Animator.StringToHash("Base Layer.CharachterAttack");
	}

    public void PlayCharactherAnimation(PlayerAnimations anim, bool stopTheRest = true, bool forceAnimation = false)
    {
        if (stopTheRest)
        {
            for (int i = 0; i < playerAnimationsHashes.Length; i++)
            {
                playerAnimator.SetBool(playerAnimationsHashes[i], false);
            }
        }

        if (forceAnimation)
        {
            playerAnimator.Play(playerStatesHashes[(int)anim]);
        }
        else
        {
            playerAnimator.SetBool(playerAnimationsHashes[(int)anim], true);
        }
    }
	
}

public enum PlayerAnimations
{
    Idle = 0,
    Running,
    Die,
    Fight
}

