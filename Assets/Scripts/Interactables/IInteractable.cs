using UnityEngine;

namespace DapperDino.Interactables
{
    public interface IInteractable
    {
        bool Interact(GameObject other);
    }
}
