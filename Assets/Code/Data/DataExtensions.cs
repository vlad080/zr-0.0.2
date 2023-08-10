using UnityEngine;

namespace Code.Data
{
    public static class DataExtensions
    {
        public static Vector3Data AsVector3Data(this Vector3 vector) => 
            new Vector3Data(vector.x, vector.y, vector.z);
    }
}