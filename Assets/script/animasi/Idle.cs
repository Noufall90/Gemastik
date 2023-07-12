using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateMachineBehaviour
{
    [SerializeField]
    private float _timeUntilIdle;
    
    [SerializeField]
    private int _numberOfIdle;

    private bool _isIdle;
    private float _idleTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle(animator);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_isIdle)
        {
            _idleTime += Time.deltaTime;

            if (_idleTime > _timeUntilIdle)
            {
                _isIdle = true;
                int idleAnimation = Random.Range(1, _numberOfIdle + 1);

                animator.SetFloat("IdleAnimation", idleAnimation);
            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetIdle(animator);
        }
    }

    private void ResetIdle(Animator animator)
    {
        _isIdle = false;
        _idleTime = 0;

        animator.SetFloat("IdleAnimation", 0);
    }
}
