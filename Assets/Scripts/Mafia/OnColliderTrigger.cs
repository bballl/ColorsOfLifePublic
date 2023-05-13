using System;
using UnityEngine;
using Assets.Scripts.Character;

namespace Assets.Scripts.Mafias
{
    class OnColliderTrigger : MonoBehaviour
    {
        public event Action EventOnColliderEnter;
        public event Action EventOnColliderExit;

        private Collider2D lastCollider;

        public Collider2D LastCollider => lastCollider;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //TODO: заменить временный класс на класс игрока
            //var player = collision.transform.root.GetComponent<TEMPERARYCLASS_PLAYER>();
            var player = collision.transform.root.GetComponent<WASDMove>();

            if (player)
            {
                lastCollider = collision;
                EventOnColliderEnter?.Invoke();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            //TODO: заменить временный класс на класс игрока
            //var player = collision.transform.root.GetComponent<TEMPERARYCLASS_PLAYER>();
            var player = collision.transform.root.GetComponent<WASDMove>();

            if (player)
            {
                lastCollider = null;
                EventOnColliderExit?.Invoke();
            }
        }
    }
}
