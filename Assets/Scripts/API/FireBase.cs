using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class FireBase : MonoBehaviour
{
    public string firebaseLink;

    public void PostToDatabase(PlayerData playerData)
    {
        RestClient.Post(firebaseLink + ".json", playerData);
    }
}
