using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandShow : MonoBehaviour
{
    [SerializeField] private GameObject[] holdablePrefabs;
    [SerializeField] private Transform gunContainer;
    private GameObject selectedPrefab = null;
    private GameObject currentPrefab = null;

    public void ChangePrefab(string name)
    {
        if (name.Trim() == "")
        {
            Destroy(currentPrefab);
            return;
        }

        if (currentPrefab != null)
        {
            Destroy(currentPrefab);
        }
        

        foreach (var prefab in holdablePrefabs)
        {
            if (prefab.name == name)
            {
                selectedPrefab = prefab;
            }
        }

        if(selectedPrefab != null)
        {
            currentPrefab = Instantiate(selectedPrefab);
            currentPrefab.transform.SetParent(gunContainer);
            currentPrefab.transform.localPosition = Vector3.zero;
            currentPrefab.transform.localRotation = Quaternion.Euler(Vector3.zero);
            currentPrefab.transform.localScale = Vector3.one;
        }

    }
}
