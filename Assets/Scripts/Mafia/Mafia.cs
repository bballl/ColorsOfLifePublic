using UnityEngine;

namespace Assets.Scripts.Mafias
{
    public class Mafia : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer circleSprite;
        [SerializeField] private CircleCollider2D triggerCollider;

        private Rigidbody2D rigitbody;
        // Зона, в которой замечает игрока
        private float colliderRadius;
        [SerializeField] private AIController aiController;

        // Тип агресии: true - нападет, false - не нападает
        private bool isAggressive;
        // Тип зацикливания: true - ходит по кругу, false - пропадает в конце пути 
        private bool isLoop;
        // Масса для автоматической установки у rigidbody.
        private float mass;
        // Толкающая вперед сила.
        private float thrust;
        // Вращающая сила.
        private float mobility;
        // Максимальная линейная скорость.
        private float maxLinearVelocity;
        // Максимальная вращательная скорость. В градусах/сек
        private float maxAngularVelocity;

        // Управление линейной тягой. От -1.0 до +1.0.
        public float ThrustControl { get; set; }
        // Управление вращательной тягой. От -1.0 до +1.0.
        public float TorqueControl { get; set; }
        public bool IsAggressive => isAggressive;
        public bool IsLoop => isLoop;

        protected  void Start()
        {
            rigitbody = GetComponent<Rigidbody2D>();
            aiController = GetComponent<AIController>();

            if (triggerCollider)
                triggerCollider.radius = colliderRadius;

            if (circleSprite)
                circleSprite.size = new Vector2(0 * colliderRadius, 0 * colliderRadius);

            rigitbody.mass = mass;
            rigitbody.inertia = 1;
        }

        private void FixedUpdate()
        {
            UpdateRigidbody();

            if (circleSprite != null && aiController.IsTimerWithourAggressionFinish == true)
            {
                circleSprite.size = new Vector2(2 * colliderRadius, 2 * colliderRadius);
            }
        }
        public void SetProperties(MafiaProperties mp)
        {
            isAggressive = mp.IsAggressive;
            isLoop = mp.IsLoop;
            colliderRadius = mp.ColliderRadius;

            mass = mp.Mass;
            thrust = mp.Thrust;
            mobility = mp.Mobility;
            maxLinearVelocity = mp.MaxLinearVelocity;
            maxAngularVelocity = mp.MaxAngularVelocity;
        }

        /// Метод добавления сил мафии для движения.
        private void UpdateRigidbody()
        {
            rigitbody.AddForce(thrust * ThrustControl * Time.fixedDeltaTime * transform.up, ForceMode2D.Force);

            rigitbody.AddForce((thrust / maxLinearVelocity) * Time.fixedDeltaTime * -rigitbody.velocity, ForceMode2D.Force);

            rigitbody.AddTorque(TorqueControl * mobility * Time.fixedDeltaTime, ForceMode2D.Force);

            rigitbody.AddTorque(-rigitbody.angularVelocity * (mobility / maxAngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }
}
