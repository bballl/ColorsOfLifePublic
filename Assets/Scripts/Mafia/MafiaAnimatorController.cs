using UnityEngine;

namespace Assets.Scripts.Mafias
{
    public class MafiaAnimatorController : MonoBehaviour
    {
        [SerializeField] private Transform parent;

        private Rigidbody2D rigitbody;
        private Animator animator;
        [SerializeField] private AIController aiController;
        // 0 - up, 1 - right, 2 - bottom, 3 - left
        private int dir;
        // 0 - stand, 1 - run, 2 - shoot
        private int action;

        // Index
        // Stand: 0 - up, 1 - right, 2 - bottom, 3 - left
        // Run:   4 - up, 5 - right, 6 - bottom, 7 - left
        // Shoot: 8 - up, 9 - right, 10 - bottom, 11 - left

        private void Start()
        {
            rigitbody = transform.root.GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            aiController = transform.root.GetComponent<AIController>();
            aiController.EventOnCatch += Shoot;
        }

        private void LateUpdate()
        {
            transform.up = Vector2.up;
            FindDirection();
            CheckingRun();
            SetBehaviour();
        }

        private void OnDestroy()
        {
            aiController.EventOnCatch -= Shoot;
        }

        public void ShootOver()
        {
            action = 0;
        }

        private void Shoot()
        {
            action = 3;
        }

        private void FindDirection()
        {
            if (Vector2.Angle(parent.up, Vector2.up) < 45)
            {
                dir = 0;
            }
            if (Vector2.Angle(parent.up, Vector2.right) <= 45)
            {
                dir = 1;
            }
            if (Vector2.Angle(parent.up, Vector2.down) < 45)
            {
                dir = 2;
            }
            if (Vector2.Angle(parent.up, Vector2.left) <= 45)
            {
                dir = 3;
            }
        }

        private void CheckingRun()
        {
            if (action == 3)
                return;

            var xMotion = rigitbody.velocity.x;
            var yMotion = rigitbody.velocity.y;

            if (xMotion == 0 && yMotion == 0)
            {
                action = 0;
            }
            else
            {
                action = 1;
            }
        }

        private void SetBehaviour()
        {
            if (action == 0)
            {
                switch (dir)
                {
                    case 0:
                        animator.SetInteger("Index", 0);
                        break;
                    case 1:
                        animator.SetInteger("Index", 1);
                        break;
                    case 2:
                        animator.SetInteger("Index", 2);
                        break;
                    case 3:
                        animator.SetInteger("Index", 3);
                        break;
                }
            }
            if (action == 1)
            {
                switch (dir)
                {
                    case 0:
                        animator.SetInteger("Index", 4);
                        break;
                    case 1:
                        animator.SetInteger("Index", 5);
                        break;
                    case 2:
                        animator.SetInteger("Index", 6);
                        break;
                    case 3:
                        animator.SetInteger("Index", 7);
                        break;
                }
            }
            if (action == 3)
            {
                switch (dir)
                {
                    case 0:
                        animator.SetInteger("Index", 8);
                        break;
                    case 1:
                        animator.SetInteger("Index", 9);
                        break;
                    case 2:
                        animator.SetInteger("Index", 10);
                        break;
                    case 3:
                        animator.SetInteger("Index", 11);
                        break;
                }
            }
        }
    }
}
