using UnityEngine;

namespace Assets.Scripts.Locations
{
    [CreateAssetMenu(fileName = "LocationSettings", menuName = "Data/Location")]
    public class LocationSettings : ScriptableObject
    {
        [SerializeField] private float updateTime;

        [SerializeField] private float playAreaBonus;
        [SerializeField] private float cinemaBonus;
        [SerializeField] private float circusBonus;
        [SerializeField] private float parkBonus;
        [SerializeField] private float planetariumBonus;
        [SerializeField] private float concertHallBonus;
        [SerializeField] private float petShopBonus;
        [SerializeField] private float pierBonus;

        public float UpdateTime => updateTime;
        public float PlayAreaBonus => playAreaBonus;
        public float CinemaBonus => cinemaBonus;
        public float CircusBonus => circusBonus;
        public float ParkBonus => parkBonus;
        public float PlanetariumBonus => planetariumBonus;
        public float ConcertHallBonus => concertHallBonus;
        public float PetShopBonus => petShopBonus;
        public float PierBonus => pierBonus;
    }
}
