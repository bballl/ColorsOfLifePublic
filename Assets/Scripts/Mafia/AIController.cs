using System;
using UnityEngine;
using Assets.Scripts.Timers;
using Assets.Scripts.Paths;
using Assets.Scripts.Character;
using System.Collections;

namespace Assets.Scripts.Mafias
{
    /// Типы поведения АИ. Null - нет поведения, RandomPatrol - патрулирует по рандомным точкам в AIPointPatrol, PointPatrol - патрулирует по заданному пути.
    public enum AIBehaviour
    {
        Null,
        RandomPatrol,
        PointPatrol
    }

    [RequireComponent(typeof(Mafia))]
    public class AIController : MonoBehaviour
    {
        public static event Action OnСharacterСontact; //добавил Глеб
        public event Action EventOnCatch;

        /// Ссылка на зону патрулирования, при типе поведения RandomPatrol.
        [SerializeField] private CircleArea patrolPoint;
        /// Список точек пути. Мафия идет по ним по порядку, когда доходит до конца идет к первой.
        [SerializeField] private Path path;
        private float lifeTime;
        private bool isTemporary;
        /// Хранение типа поведения.
        [SerializeField] private AIBehaviour aiBehaviour;
        private Mafia mafia;
        private OnColliderTrigger colliderTrigger;
        private SpriteRenderer sprite;
        private Vector3 movePosition;
        private int numberPointTarget;
        /// Скорость перемеещения.
        private float navigationLinear;
        /// Скорость вращения.
        private float navigationAngular;
        /// Время для изменения позиции.
        private float randomSelectMovePointTime;
        private float radiusPointProximity;
        private int layerMask = 6;
        private float timeWithoutAggression;
        private bool isTimerWithourAggressionFinish;

        private TimerM randomizeDirectionTimer;
        private TimerM lifeTimer;
        private TimerM withoutAggresssionTimer;

        public bool IsTimerWithourAggressionFinish => isTimerWithourAggressionFinish;

        private void Start()
        {
            mafia = GetComponent<Mafia>();
            colliderTrigger = GetComponentInChildren<OnColliderTrigger>();
            sprite = GetComponentInChildren<SpriteRenderer>();

            InitTimers();
            withoutAggresssionTimer.Start(timeWithoutAggression);

            if (colliderTrigger)
            {
                colliderTrigger.EventOnColliderEnter += OnColliderEnter;
            }

            if (aiBehaviour == AIBehaviour.PointPatrol)
            {
                numberPointTarget = 0;
                movePosition = path[numberPointTarget].transform.position;
            }
        }

        private void Update()
        {
            UpdateTimers();
            UpdateAI();
        }

        private void OnDestroy()
        {
            if (colliderTrigger)
            {
                colliderTrigger.EventOnColliderEnter -= OnColliderEnter;
            }
        }

        public void SetPath(Path path)
        {
            this.path = path;
        }

        public void SetProperties(MafiaProperties mp)
        {
            lifeTime = mp.LifeTime;
            isTemporary = mp.IsTemporary;
            aiBehaviour = mp.TypeOfAIBehabiour;
            radiusPointProximity = mp.RadiusPointProximity;
            layerMask = mp.MafiaLayerMask;
            navigationLinear = mp.NavigationLinear;
            navigationAngular = mp.NavigationAngular;
            randomSelectMovePointTime = mp.RandomSelectMovePointTime;
            timeWithoutAggression = mp.TimeWithoutAggression;
        }

        private void UpdateAI()
        {
            if (isTemporary == true && lifeTimer.IsFinished == true)
            {
                StartCoroutine("Disappearance");
            }

            if (aiBehaviour == AIBehaviour.Null)
            {
                Stop();
                return;
            }

            if (aiBehaviour == AIBehaviour.RandomPatrol ||
                aiBehaviour == AIBehaviour.PointPatrol)
            {
                UpdateBehaviourPatrol();
            }

            if (withoutAggresssionTimer.IsFinished)
                isTimerWithourAggressionFinish = true;
        }

        private void UpdateBehaviourPatrol()
        {
            ActionFindNewMovePosition();
            ActionControlShip();
        }

        private void ActionFindNewMovePosition()
        {
            if (aiBehaviour == AIBehaviour.Null)
                return;

            if (aiBehaviour == AIBehaviour.RandomPatrol)
            {
                
                if (patrolPoint != null)
                {
                    bool isInsidePatrolZone = (patrolPoint.transform.position - transform.position).sqrMagnitude < patrolPoint.Radius * patrolPoint.Radius;
                    
                    if (isInsidePatrolZone == true)
                    {
                        if (randomizeDirectionTimer.IsFinished)
                        {
                            Vector2 newPoint = UnityEngine.Random.onUnitSphere * patrolPoint.Radius + patrolPoint.transform.position;
                            movePosition = newPoint;
                            
                            randomizeDirectionTimer.Start(randomSelectMovePointTime);
                        }
                    }
                    else
                    {
                        movePosition = patrolPoint.transform.position;
                    }
                }
            }
            
            if (aiBehaviour == AIBehaviour.PointPatrol)
            {                
                bool isNearPointTarget = (movePosition - transform.position).sqrMagnitude < radiusPointProximity * radiusPointProximity;
                
                if (isNearPointTarget == true)
                {
                    numberPointTarget++;

                    if (mafia.IsLoop == true && numberPointTarget > path.Length - 1)
                    {
                        //Destroy(gameObject);
                        StartCoroutine("Disappearance");
                    }

                    if (numberPointTarget > path.Length - 1)
                        numberPointTarget = 0;

                        movePosition = path[numberPointTarget].transform.position;
                }
            }
        }
        private void Stop()
        {
            mafia.ThrustControl = 0;
            mafia.TorqueControl = 0;
        }

        private void ActionControlShip()
        {
            mafia.ThrustControl = navigationLinear;
            mafia.TorqueControl = ComputeAliginTorgueNormalized(movePosition, mafia.transform) * navigationAngular;
        }

        private const float MAX_ANGLE = 45.0f;
        private static float ComputeAliginTorgueNormalized(Vector3 targetPosition, Transform ship)
        {
            Vector2 localTargetPosition = ship.InverseTransformPoint(targetPosition);
            float angle = Vector3.SignedAngle(localTargetPosition, Vector3.up, Vector3.forward);
            angle = Mathf.Clamp(angle, -MAX_ANGLE, MAX_ANGLE) / MAX_ANGLE;
            return -angle;
        }

        private void OnColliderEnter()
        {
            if (mafia.IsAggressive && withoutAggresssionTimer.IsFinished == true) ////////
            {
                var target = colliderTrigger.LastCollider;

                float distance = Vector2.Distance(transform.position, target.transform.position);
                Vector2 direction = target.transform.position - transform.position;

                var player = Physics2D.Raycast(transform.position, direction, distance, 1 << layerMask).transform.root.GetComponent<WASDMove>();
                
                if (player)
                {
                    OnСharacterСontact.Invoke(); //добавил Глеб                    
                    EventOnCatch?.Invoke();
                }
            }          
        }
        private IEnumerator Disappearance()
        {
            for (float f = 1f; f >= 0; f -= 0.05f)
            {
                Color color = sprite.material.color;
                color.a = f;
                sprite.material.color = color;

                if (sprite.material.color.a <= 0.05f)
                {
                    Destroy(gameObject);
                }

                yield return new WaitForSeconds(0.05f);                
            }
        } 

        #region Timers
        private void InitTimers()
        {
            randomizeDirectionTimer = new TimerM(randomSelectMovePointTime);
            lifeTimer = new TimerM(lifeTime);
            withoutAggresssionTimer = new TimerM(timeWithoutAggression);
        }

        private void UpdateTimers()
        {
            randomizeDirectionTimer.RemoveTime(Time.deltaTime);
            lifeTimer.RemoveTime(Time.deltaTime);
            withoutAggresssionTimer.RemoveTime(Time.deltaTime);
        }
        #endregion
    }
}
