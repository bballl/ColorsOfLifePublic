using UnityEngine;

namespace Assets.Scripts.Mafias
{
   [CreateAssetMenu]
    public class MafiaProperties : ScriptableObject
    {
        [Header("Properties")]
        // Тип агресии: true - нападет, false - не нападает
        [SerializeField] private bool isAggressive;
        // Тип зацикливания: true - ходит по кругу, false - пропадает в конце пути 
        [SerializeField] private bool isLoop;
        // Радиус триггер-коллайдера (Расстояние, на котором мафия заметит игрока)
        [SerializeField] private float colliderRadius;
        // Хранение типа поведения.
        [SerializeField] private AIBehaviour aiBehaviour;
        // Пропадает ли через время. True - пропадает, false - нет
        [SerializeField] private bool isTemporary;
        // Время жизни
        [SerializeField] private float lifeTime;
        // Допустимая погрешность при подходе к точке назначения
        [SerializeField] private float radiusPointProximity = 0.1f;
        // Время после появление, когда мафия не будет убивать игрока
        [SerializeField] private float timeWithoutAggression;
        // Layer мафии
        [SerializeField] private int layerMask = 6;


        [Header("Mobility")]
        // Масса для автоматической установки у rigidbody.
        [SerializeField] private float mass = 1;
        // Толкающая вперед сила.
        [SerializeField] private float thrust = 1000;
        // Вращающая сила.
        [SerializeField] private float mobility = 2000;
        // Максимальная линейная скорость.
        [SerializeField] private float maxLinearVelocity = 3;
        // Максимальная вращательная скорость. В градусах/сек
        [SerializeField] private float maxAngularVelocity = 360;
        // Скорость перемеещения.
        [Range(0.0f, 1.0f)]
        [SerializeField] private float navigationLinear = 0.3f;
        // Скорость вращения.
        [Range(0.0f, 1.0f)]
        [SerializeField] private float navigationAngular = 0.3f; 
        // Время для изменения позиции.
        [SerializeField] private float randomSelectMovePointTime = 5;

        public bool IsAggressive => isAggressive;
        public bool IsLoop => isLoop;
        public float ColliderRadius => colliderRadius;
        public AIBehaviour TypeOfAIBehabiour => aiBehaviour;
        public bool IsTemporary => isTemporary;
        public float LifeTime => lifeTime;
        public float RadiusPointProximity => radiusPointProximity;
        public float TimeWithoutAggression => timeWithoutAggression;
        public int MafiaLayerMask => layerMask;

        public float Mass => mass;
        public float Thrust => thrust;
        public float Mobility => mobility;
        public float MaxLinearVelocity => maxLinearVelocity;
        public float MaxAngularVelocity => maxAngularVelocity;
        public float NavigationLinear => navigationLinear;
        public float NavigationAngular => navigationAngular;
        public float RandomSelectMovePointTime => randomSelectMovePointTime;
    }
}
