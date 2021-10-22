using UnityEngine;

namespace HelicopterAttack.Global
{
    public static class VectorExtention
    {
        public static Vector2 ToVector2XZ(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }

        public static Vector2 ToVector2XY(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.y);
        }

        public static Vector3 ToVector3XZY(this Vector2 vector3)
        {
            return new Vector3(vector3.x, 0, vector3.y);
        }
    }
}