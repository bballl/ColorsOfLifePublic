using UnityEngine;
using Assets.Scripts.Mafias;

namespace Assets.Scripts.Paths
{
    public class Path : MonoBehaviour
    {
        // ����� ������
        [SerializeField] protected CircleArea startArea;
        // ������ �����
        [SerializeField] private CircleArea[] points;

        public CircleArea StartArea => startArea;
        public int Length => points.Length;
        public CircleArea this[int i] => points[i];

#if UNITY_EDITOR
        private static readonly Color GizmoColor = new(0, 0, 1, 0.3f);

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = GizmoColor;
            foreach (var point in points)
                Gizmos.DrawSphere(point.transform.position, point.Radius);
        }
#endif
    }
}

