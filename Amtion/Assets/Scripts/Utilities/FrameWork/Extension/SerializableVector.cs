using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FunctionExtend
{
    public static class SerializableVector
    {
        public static Vector3 ToVector3(this SVector3 vector)
        {
            return new Vector3(vector.x, vector.y, vector.z);
        }

        public static Vector2 ToVector2(this SVector2 vector)
        {
            return new Vector2(vector.x, vector.y);
        }
    }


    //TODO: Change all Vector to SVector
    [Serializable]
    public struct SVector3
    {
        public float x 
        {
            get 
            {
                return Value[0];
            }

            set
            {
                Value[0] = value;
            }
        }

        public float y
        {
            get
            {
                return Value[1];
            }

            set
            {
                Value[1] = value;
            }
        }

        public float z
        {
            get
            {
                return Value[2];
            }

            set
            {
                Value[2] = value;
            }
        }

        public static SVector3 zero
        {
            get
            {
                return new SVector3(0, 0);
            }
        }

        public static SVector3 one
        {
            get
            {
                return new SVector3(1, 1, 1);
            }
        }
        private float[] Value;

        public SVector3(float x, float y)
        {
            Value = new float[] { x, y, 0 };
        }

        public SVector3(float x, float y, float z)
        {
            Value = new float[] { x, y, z };
        }

        public SVector3(Vector3 vector)
        {
            Value = new float[] { vector.x, vector.y, vector.z };
        }

        public SVector3(Vector2 vector)
        {
            Value = new float[] { vector.x, vector.y, 0 };
        }
    }

    [Serializable]
    public struct SVector2
    {
        public float x
        {
            get
            {
                return Value[0];
            }

            set
            {
                Value[0] = value;
            }
        }

        public float y
        {
            get
            {
                return Value[1];
            }

            set
            {
                Value[1] = value;
            }
        }

        public static SVector2 zero
        {
            get
            {
                return new SVector2(0, 0);
            }
        }

        public static SVector2 one
        {
            get
            {
                return new SVector2(1, 1);
            }
        }

        private float[] Value;

        public SVector2(float x, float y)
        {
            Value = new float[] { x, y};
        }

        public SVector2(Vector2 vector)
        {
            Value = new float[] { vector.x, vector.y};
        }
    }
}