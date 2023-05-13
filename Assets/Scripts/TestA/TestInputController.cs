using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Test
{
    internal class TestInputController
    {
        public float GetHorizontal()
        {
            return UnityEngine.Input.GetAxis("Horizontal");
        }

        public float GetVertical()
        {
            return UnityEngine.Input.GetAxis("Vertical");
        }
    }
}
