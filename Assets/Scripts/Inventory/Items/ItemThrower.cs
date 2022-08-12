using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DapperDino.Items
{
    public class ItemThrower : MonoBehaviour
    {
        [SerializeField] private GameObject[] pickUpPrefabs;
        [SerializeField] private Transform fpsCam,player,firePoint;
        [SerializeField] private float dropForwardForce, dropUpwardForce;
        [SerializeField] private HandShow hand;
        private GameObject selectedPrefab;

        private int slotIndex = 0;

        private void OnDisable() => slotIndex = -1;

        public void Activate(ItemSlot itemSlot, int slotIndex,Inventory inventory)
        {

        foreach (var prefab in pickUpPrefabs)
        {
            if (prefab.name == itemSlot.item.ColouredName)
            {
                selectedPrefab = prefab;
            }
        }

        if(selectedPrefab != null)
        {
             Rigidbody rb = Instantiate(selectedPrefab, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.velocity = player.GetComponent<Rigidbody>().velocity;
            rb.AddForce(fpsCam.forward * dropForwardForce , ForceMode.Impulse);
            rb.AddForce(fpsCam.up * dropUpwardForce , ForceMode.Impulse);
            
            float random = Random.Range(-1f,1f);
            rb.AddTorque(new Vector3(random,random,random)*10);
            Ammo.showCrossHair = false;
            }
            this.slotIndex = slotIndex;

            inventory.RemoveAt(slotIndex);
            
            hand.ChangePrefab("");
            selectedPrefab = null;
        }
    }
}

