using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Test
{
    internal class TestCharacterMovementController
    {
        private Rigidbody2D _rb;
        private TestInputController _inputController;
        private float _threshold = 0.01f;

        private float speed = 3.5f;

        internal TestCharacterMovementController(Rigidbody2D rb)
        {
            _rb = rb;
            _inputController = new TestInputController();
        }

        /// <summary>
        /// Движение персонажа.
        /// </summary>
        /// <returns>Направление движения по горизонтали.</returns>
        public float Move()
        {
            float horizontalDirection = HoryzontalMove();
            float verticalDirection = VerticalMove();

            if (horizontalDirection == 0 && verticalDirection == 0)
                _rb.velocity = Vector2.zero;

            return horizontalDirection;
        }

        /// <summary>
        /// Логика горизонтального движения.
        /// </summary>
        /// <returns>Направление движения</returns>
        private float HoryzontalMove()
        {
            float direction = _inputController.GetHorizontal();

            if (Mathf.Abs(direction) < _threshold)
                return 0;

            _rb.velocity = new Vector2(direction * speed, _rb.velocity.y);

            return direction;
        }

        /// <summary>
        /// Логика вертикального движения.
        /// </summary>
        /// <returns>Направление движения</returns>
        private float VerticalMove()
        {
            float direction = _inputController.GetVertical();

            if (Mathf.Abs(direction) < _threshold)
                return 0;

            _rb.velocity = new Vector2(_rb.velocity.x, direction * speed);

            return direction;
        }
    }
}
