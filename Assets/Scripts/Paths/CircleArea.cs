using UnityEngine;

namespace Assets.Scripts.Mafias
{
    public class CircleArea : MonoBehaviour
    {
        [SerializeField] private float radius;
        public float Radius => radius;

        public Vector2 GetRandomInsideZone()
        {
            return (Vector2)transform.position + (Vector2)UnityEngine.Random.insideUnitSphere * radius;
        }

#if UNITY_EDITOR
        private static readonly Color GizmoColor = new(1, 0, 0, 0.3f);
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = GizmoColor;
            Gizmos.DrawSphere(transform.position, radius);
        }
#endif
    }
}
