using UnityEngine;

namespace HelicopterAttack.Characters.Helicopter
{
    public static class Vector3Extention
    {
        public static Vector2 ToVector2XZ(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }

        public static Vector2 ToVector2XY(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.y);
        }
    }
}