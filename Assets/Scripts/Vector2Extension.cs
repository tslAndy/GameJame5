using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class Vector3Extension
    {
        public static Vector3 Rotate(this Vector3 v, float degrees) {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float tx = v.x;
            float ty = v.z;

            v.x = (cos * tx) - (sin * ty);
            v.z = (sin * tx) + (cos * ty);
            return v;
        }
    }
}
