using UnityEngine;

namespace DapperDino.Utilities
{
    public class ToggleCursor : MonoBehaviour
    {
        private bool locked = true;

        public void ToggleCursorActive()
        {

            Cursor.lockState = CursorLockMode.None;

                    
        }
        public void ToggleCursorDeactivate() {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}

