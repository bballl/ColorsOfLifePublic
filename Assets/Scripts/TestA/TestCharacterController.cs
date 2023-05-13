using UnityEngine;

namespace Assets.Scripts.Test
{
    internal class TestCharacterController : MonoBehaviour
    {
        private TestCharacterMovementController movementController;
        private void Awake()
        {
            var rb = GetComponent<Rigidbody2D>();
            movementController = new TestCharacterMovementController(rb);
        }

        private void Update()
        {
            movementController.Move();
        }
    }
}
