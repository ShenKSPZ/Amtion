using UnityEngine;

namespace Framework
{
    public static class MathC
    {
        public static float Angle_360(Vector3 from, Vector3 to)
        {
            Vector3 temp = Vector3.Cross(from, to);
            if (temp.y > 0)
                return Vector3.Angle(from, to);
            else
                return 360 - Vector3.Angle(from, to);
        }

        public static Vector3 Direction(Vector3 from, Vector3 to)
        {
            return (to - from).normalized;
        }

        public static bool Precision(float a, float b, float percision, bool equal = true)
        {
            if(equal)
            {
                if (a <= b + percision && a >= b - percision)
                    return true;
                else
                    return false;
            }
            else
            {
                if (a < b + percision && a > b - percision)
                    return true;
                else
                    return false;
            }
        }

        public static bool IsInSquare(Vector2 OriginPos, Vector2 SquarePos, Vector2 SquareSize)
        {
            if (OriginPos.x > SquarePos.x - SquareSize.x / 2
                && OriginPos.x < SquarePos.x + SquareSize.x / 2
                && OriginPos.y > SquarePos.y - SquareSize.y / 2
                && OriginPos.y < SquarePos.y + SquareSize.y / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}