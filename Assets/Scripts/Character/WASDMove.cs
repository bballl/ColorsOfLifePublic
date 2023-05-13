using UnityEngine;

namespace Assets.Scripts.Character
{
    public class WASDMove : MonoBehaviour
    {
        [SerializeField] private CharacterSpeedSettings character;
        private Rigidbody2D _rb;
        private Vector2 _input;
        private float speed;

        private void Start()
        {
            CharacterRespawnController.OnCharacterStop += CharacterStop;
            
            _rb = GetComponent<Rigidbody2D>();
            speed = character.Speed;
        }

        private void OnDestroy()
        {
            CharacterRespawnController.OnCharacterStop -= CharacterStop;
        }

        private void Update()
        {
            Move();
        }

        void FixedUpdate()
        {
            FixedMove();
        }

        public void Move()
        {
            _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        public void FixedMove()
        {
            _rb.MovePosition(_rb.position + _input * speed);
        }

        private void CharacterStop(bool value)
        {
            if (value)
                speed = 0;
            else
                speed = character.Speed;
        }
    }
}