using UnityEngine;

namespace Assets.Scripts.Pictures
{
    [CreateAssetMenu]
    public class PictureProperties : ScriptableObject
    {
        [SerializeField] private float valueColor;
        [SerializeField] private int fillingPercentage;

        public float ValueColor => valueColor;
        public int FillingPercentage => fillingPercentage;
    }
}
