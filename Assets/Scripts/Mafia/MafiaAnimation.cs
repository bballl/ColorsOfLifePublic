using UnityEngine;

namespace Assets.Scripts.Mafias
{
    public class MafiaAnimation : MonoBehaviour
    {
        [SerializeField] private Transform parent;

        private Rigidbody2D rigitbody;
        private Animator animator;
        [SerializeField] private AIController aiController;

        // 0 - stay, 1 - run, 3 - shoot
        private int index;

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
        }

        private void OnDestroy()
        {
            aiController.EventOnCatch -= Shoot;
        }

        private void FindDirection()
        {
            if (Vector2.Angle(parent.up, Vector2.up) < 45)
            {
                //animator.ResetTrigger("Stop");
                animator.SetTrigger("Up");
            }
            if (Vector2.Angle(parent.up, Vector2.right) <= 45)
            {
                //animator.ResetTrigger("Stop");
                animator.SetTrigger("Right");
            }
            if (Vector2.Angle(parent.up, Vector2.down) < 45)
            {
                //animator.ResetTrigger("Stop");
                animator.SetTrigger("Bottom");
            }
            if (Vector2.Angle(parent.up, Vector2.left) <= 45)
            {
                //animator.ResetTrigger("Stop");
                animator.SetTrigger("Left");
            }
        }

        private void Shoot()
        {
            //animator.ResetTrigger("Stop");
            // animator.SetTrigger("Shoot");
            animator.SetInteger("Index", 2);
            Debug.Log("!!");
        }

        private void CheckingRun()
        {
            if (index == 2)
                return;

            var xMotion = rigitbody.velocity.x;
            var yMotion = rigitbody.velocity.y;

            if (xMotion == 0 && yMotion == 0)
            {
                //animator.SetTrigger("Stop");
                animator.SetInteger("Index", 0);
            }
            else
            {
                animator.SetInteger("Index", 1);
                //animator.ResetTrigger("Stop");
            }
        }
    }

}
