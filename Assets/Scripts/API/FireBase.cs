using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class FireBase : MonoBehaviour
{
    public string firebaseLink;
    public static float LoadHealth = 0f;

    public void PostToDatabase(PlayerData playerData)
    {
        RestClient.Put(firebaseLink + playerData.WorldName+".json", playerData);
    }

    public void GetToDatabase(string worldName)
    {
        RestClient.Get<PlayerData>(firebaseLink + worldName + ".json").Then(callback=>
        {
            Debug.Log(callback.health);
            LoadHealth = callback.health;
        });
    }
}
