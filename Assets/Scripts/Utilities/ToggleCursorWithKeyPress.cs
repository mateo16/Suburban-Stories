using UnityEngine;

namespace DapperDino.Utilities
{
    public class ToggleCursorWithKeyPress : MonoBehaviour
    {
        [SerializeField] private KeyCode keyCode = KeyCode.None;
        private bool locked = true;
        public MouseLook scriptlook;
        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                if (locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                    locked = false;
                    scriptlook.enabled = false;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    locked = true;
                    scriptlook.enabled = true;
                }
                
            }
        }
    }
}

