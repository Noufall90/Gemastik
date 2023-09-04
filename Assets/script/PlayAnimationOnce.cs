using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnce : StateMachineBehaviour
{
    private bool animationPlayed = false; // Variabel untuk melacak apakah animasi telah diputar

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animationPlayed)
        {
            // Mainkan animasi hanya jika belum diputar
            animator.Play(stateInfo.fullPathHash, -1, 0f);
            animationPlayed = true;
        }
    }
}
