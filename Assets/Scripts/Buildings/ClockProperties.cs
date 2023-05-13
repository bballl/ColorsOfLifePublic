using UnityEngine;

namespace Assets.Scripts.Buildings
{
    [CreateAssetMenu]
    public class ClockProperties : ScriptableObject
    {

        [SerializeField] private GameObject clockPrefab;
        [SerializeField] private float aboveBuilding;

        public GameObject ClockPrefab => clockPrefab;
        public float AboveBuilding => aboveBuilding;
    }
}
