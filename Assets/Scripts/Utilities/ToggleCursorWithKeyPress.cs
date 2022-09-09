using UnityEngine;
using SuburbanStories.Events;

namespace DapperDino.Utilities
{
    public class ToggleCursorWithKeyPress : MonoBehaviour
    {
        [SerializeField] private KeyCode keyCode = KeyCode.None;
        [SerializeField] private VoidEvent DisableGunSystem;

        private bool locked = true;
        public MouseLook scriptLook;
        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                if (locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                    locked = false;
                    scriptLook.enabled = false;
                    DisableGunSystem.Raise();
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    locked = true;
                    scriptLook.enabled = true;
                    DisableGunSystem.Raise();
                }
                
            }
        }
    }
}

