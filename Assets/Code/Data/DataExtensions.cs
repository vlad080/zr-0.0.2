using UnityEngine;

namespace Code.Data
{
    public static class DataExtensions
    {
        public static Vector3Data ConvertToVector3Data(this Vector3 vector) =>
            new Vector3Data(vector.x, vector.y, vector.z);

        public static Vector3 ConvertToUnityVector(this Vector3Data vector3data) =>
            new Vector3(vector3data.X, vector3data.Y, vector3data.Z);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);

        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);
        
        public static float SqrMagnitudeTo(this Vector3 from, Vector3 to) => 
            Vector3.SqrMagnitude(to - from);
    }
}