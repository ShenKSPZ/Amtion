using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunctionExtend
{
    public static class VectorExtension
    {
        /// <summary>
        /// 将原本的Vector3中的Y归零，仅保留X和Z
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3 ZeroY(this Vector3 v)
        {
            return new Vector3(v.x, 0, v.z);
        }

        /// <summary>
        /// 将原本的Vector3中的X和Z归零，仅保留Y
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3 ZeroXZ(this Vector3 v)
        {
            return new Vector3(0, v.y, 0);
        }

        /// <summary>
        /// 计算只包括X和Z的向量大小
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float MagnitudeXZ(this Vector3 v)
        {
            return ZeroY(v).magnitude;
        }

        /// <summary>
        /// 计算目标与世界Forward方向的夹角，返回0~360之间的数值
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float AngleXZ(this Vector3 v)
        {
            Vector3 temp = ZeroY(v);
            return Vector3.Angle(Vector3.forward, temp) ;
        }

        /// <summary>
        /// 计算目标与世界Forward方向的夹角，返回-180~180之间的数值
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float SignedAngleXZ(this Vector3 v)
        {
            Vector3 temp = ZeroY(v);
            return Vector3.SignedAngle(Vector3.forward, temp, Vector3.forward);
        }

        /// <summary>
        /// 计算其与世界Up向量之间的夹角，返回0~360之间的数值
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float Angle(this Vector2 v)
        {
            return Vector2.Angle(Vector2.up, v);
        }

        /// <summary>
        /// 计算其与世界Up向量之间的夹角，返回-180~180之间的数值
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float SignedAngle(this Vector2 v)
        {
            return Vector2.SignedAngle(Vector2.up, v);
        }
    }

}
