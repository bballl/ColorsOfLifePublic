using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class CharacterAnimationAct : MonoBehaviour
    {
        private int _vect = -1;
        private Animator _animator;
        private Animation _anim;
        private bool _isDetected = false;
        void Start()
        {
            _animator = GetComponent<Animator>();
            //_anim = GetComponent<Animation>();
            //_anim["DownWalk"].speed = 2.0f;
            //_anim["UpperWalk"].speed = -1.0f;
            _animator.speed = 1f;
            Assets.Scripts.Mafias.AIController.On—haracter—ontact += HeDied;
        }

        void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (!_isDetected)
            {
                if (h < 0)
                {

                    _animator.ResetTrigger("Stopped");
                    _animator.SetTrigger("Left");
                    _vect = 3;

                }
                else if (h > 0)
                {
                    _animator.ResetTrigger("Stopped");
                    _animator.SetTrigger("Right");
                    _vect = 4;
                }
                else if (v > 0)
                {
                    _animator.ResetTrigger("Stopped");
                    _animator.SetTrigger("Upper");
                    _vect = 1;

                }
                else if (v < 0)
                {

                    _animator.ResetTrigger("Stopped");
                    _animator.SetTrigger("Down");
                    _vect = 2;

                }
                else
                {
                    _vect = -1;
                    //_animator.SetInteger("State", -1);
                    _animator.SetTrigger("Stopped");
                }
            }
        }
        private void HeDied()
        {
            _isDetected = true;
            _animator.SetTrigger("Dead");
            _animator.SetTrigger("RIP");
            _animator.ResetTrigger("Left");
            _animator.ResetTrigger("Right");
            _animator.ResetTrigger("Upper");
            _animator.ResetTrigger("Down");
            _animator.ResetTrigger("Stopped");
            Invoke("HeInLife", 2f);
        }

        private void HeInLife()
        {
            _isDetected = false;
            _animator.SetTrigger("Stopped");
        }

    }
}