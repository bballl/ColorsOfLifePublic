using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Locations
{
    [CreateAssetMenu]
    public class TimerProperties : ScriptableObject
    {
        [SerializeField] private float _time;
        [SerializeField] private float _delay;
        
        public float Time => _time;
        public float Delay => _delay;
    }
}
