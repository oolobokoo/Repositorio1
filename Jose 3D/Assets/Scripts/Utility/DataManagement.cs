using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUtilities {
    public static class DataManagement {

        const string DATA_PATH = "D:/game3D.sav";

        public static void WriteDataToFile (object saveData) {
            using (FileStream fs = new FileStream (DATA_PATH, FileMode.Create)) {
                BinaryFormatter formatter = new BinaryFormatter ();
                formatter.Serialize (fs, saveData);
            }
        }

        public static object ReadDataFromFile () {
            if (File.Exists (DATA_PATH)) {
                using (FileStream fs = new FileStream (DATA_PATH, FileMode.Open)) {
                    BinaryFormatter formatter = new BinaryFormatter ();
                    return formatter.Deserialize (fs);
                }
            } else {
                return null;
            }
        }
    }

    public static class DataFormat {
        public static float[] UnityToFloatArray (this Vector3 vector) {
            return new float[] { vector.x, vector.y, vector.z };
        }
        public static float[] UnityToFloatArray (this Quaternion quaternion) {
            return new float[] { quaternion.x, quaternion.y, quaternion.z, quaternion.w };
        }
        public static Vector3 ToVector3 (this float[] floatArray) {
            Vector3 vector = Vector3.zero;
            if (floatArray.Length == 3) {
                vector = new Vector3 (floatArray[0], floatArray[1], floatArray[2]);
            } else {
                Debug.LogError("Float array does not match lenght for Vector3 (3)");
            }
            return vector; 
        }
        public static Quaternion ToQuaternion (this float[] floatArray) {
            Quaternion quaternion = Quaternion.identity;
            if (floatArray.Length == 4) {
                quaternion = new Quaternion (floatArray[0], floatArray[1], floatArray[2], floatArray[3]);
            } else {
                Debug.LogError ("Float array does not match lenght for Quaternion (4)");
            }
            return quaternion;
        }
    }
}
