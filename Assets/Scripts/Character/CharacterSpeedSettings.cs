using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Character
{
    [CreateAssetMenu]
    public class CharacterSpeedSettings : ScriptableObject
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}
