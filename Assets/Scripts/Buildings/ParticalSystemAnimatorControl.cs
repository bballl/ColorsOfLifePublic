using System;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    class ParticalSystemAnimatorControl : MonoBehaviour
    {
        public event Action EventOnEndAnimation;


        private Animator anim;
        private ParticleSystem particle;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            particle = GetComponent<ParticleSystem>();
        }

        public void OnEndAnimation()
        {
            anim.SetBool("isPainting", false);
            particle.Stop();
            EventOnEndAnimation?.Invoke();
        }
    }
}
