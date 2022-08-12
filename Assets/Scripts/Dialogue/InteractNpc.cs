using UnityEngine;
using UnityEngine.Audio;
using DapperDino.Interactables;

namespace DapperDino.Items
{
    public class InteractNpc : MonoBehaviour, IInteractable
    {
        public Dialogue dialogue;
        public MouseLook scriptlook;
        public GunSystem scriptgun;
        public bool Interact(GameObject other)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Cursor.lockState = CursorLockMode.None;
            //scriptlook.mouseSensitivity=0f;
            scriptlook.enabled = false;
            return true;
        }
        
    }
}
