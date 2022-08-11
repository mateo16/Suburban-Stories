using UnityEngine;

namespace DapperDino.Utilities
{
    public class ToggleActiveWithKeyPress : MonoBehaviour
    {
        [SerializeField] private KeyCode keyCode = KeyCode.None;
        [SerializeField] private GameObject objecToToggle = null;

        private void Start()
        {
            objecToToggle.SetActive(true);
            Invoke("SetActivation", 0.01f);
        }

        private void SetActivation()
        {
            objecToToggle.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                objecToToggle.SetActive(!objecToToggle.activeSelf);
                
            }
        }
    }
}


