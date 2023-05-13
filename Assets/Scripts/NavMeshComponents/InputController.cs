using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.NavMeshComponents
{
    public class InputController : MonoBehaviour
    {
        public static Vector3 GetHorizontalMove()
        {
            return Vector3.forward * Time.fixedDeltaTime;
        }

        public static Vector3 GetVerticalMove()
        {
            return Vector3.right * Time.fixedDeltaTime;
        }

        public static Vector3 GetLeftMouseButton()
        {
            return UnityEngine.Input.mousePosition;
        }
    }
}
