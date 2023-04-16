using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FeriaVirtual{

   public class JsonHelper : MonoBehaviour{

     public static T[] GetJsonArray<T>(string jsonContent){

        string newJson = "{ \"Array\": " + jsonContent + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.Array;
    }


    [Serializable]
    private class Wrapper<T>{
        public T[] Array;
    }

   }
}

