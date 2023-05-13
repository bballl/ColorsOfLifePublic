using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _controllerTransform;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _leftLimit;
        [SerializeField] private float _rightLimit;
        [SerializeField] private float _upLimit;
        [SerializeField] private float _downLimit;

        void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var nextPosition = Vector3.Lerp(transform.position, _controllerTransform.position + _offset, _speed * Time.fixedDeltaTime);
            transform.position = nextPosition;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit),
                                                        Mathf.Clamp(transform.position.y, _downLimit, _upLimit),
                                                        transform.position.z);
        }
    }
}
