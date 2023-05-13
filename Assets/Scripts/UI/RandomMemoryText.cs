using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class RandomMemoryText : MonoBehaviour
    {
        public Text NotePad;

        private void Start ()
        {
            Assets.Scripts.Locations.MemoryTrigger.Mem += UpdateText;
        }

        private void UpdateText(string text)
        {
            NotePad.text = text;
        }
    }
}
