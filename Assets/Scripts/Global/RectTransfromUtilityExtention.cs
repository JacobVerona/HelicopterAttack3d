using HelicopterAttack.Global;
using UnityEngine;

namespace HelicopterAttack.Global
{
    public static class RectTransfromUtilityExtention
    {
        public static Vector2 WorldPositionToRectLocalPosition(
            Vector3 centerWorldPosition, 
            Vector3 targetPosition, 
            float scale)
        {
            var pos = targetPosition - centerWorldPosition;
            return pos.ToVector2XZ() * scale;
        }

        public static Vector2 WorldPositionToRectLocalPositionClampedInRect(
            Vector3 centerWorldPosition, 
            Vector3 targetPosition, 
            Rect clampRect,
            float scale)
        {
            var pos = targetPosition - centerWorldPosition;

            var resultPosition = pos.ToVector2XZ() * scale;
            resultPosition = new Vector2(Mathf.Clamp(resultPosition.x, clampRect.min.x, clampRect.max.x),
                Mathf.Clamp(resultPosition.y, clampRect.min.y, clampRect.max.y));
            return resultPosition;
        }
    }
}
