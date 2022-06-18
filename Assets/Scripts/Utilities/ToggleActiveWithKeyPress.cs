using UnityEngine;

namespace DapperDino.Utilities
{
    public class ToggleActiveWithKeyPress : MonoBehaviour
    {
        [SerializeField] private KeyCode keyCode = KeyCode.None;
        [SerializeField] private GameObject objecToToggle = null;

        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                objecToToggle.SetActive(!objecToToggle.activeSelf);
            }
        }
    }
}


