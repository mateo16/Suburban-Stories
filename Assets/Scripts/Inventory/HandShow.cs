using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DapperDino.Items;

public class HandShow : MonoBehaviour
{
    [SerializeField] private GameObject[] holdablePrefabs;
    [SerializeField] private Transform gunContainer;
    [SerializeField] private ItemThrower itemThrower;
    [SerializeField] private InventorySlot handSlot;

    [SerializeField] private Inventory inventory;

    private GameObject selectedPrefab = null;
    private GameObject currentPrefab = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && handSlot.ItemSlot.item != null)
        {
            itemThrower.Activate(handSlot.ItemSlot,20,inventory);
        }
    }

    public void ChangePrefab(string name)
    {
        if (name.Trim() == "")
        {
            Ammo.showAmmo = false;
            Destroy(currentPrefab);
            return;
        }

        if (currentPrefab != null)
        {
            Ammo.showAmmo = false;
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
