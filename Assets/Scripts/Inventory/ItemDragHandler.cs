using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DapperDino.Items
{
    public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] protected ItemSlotUI itemSlotUI = null;

        private CanvasGroup canvasGroup = null;
        private Transform originalParent = null;
        private bool isHovering = false;

        public ItemSlotUI ItemSlotUI => ItemSlotUI;

        private void Start() => canvasGroup = GetComponent<CanvasGroup>();

        private void OnDisable()
        {
            if (isHovering)
            {
                //raise event
                isHovering = false;
            }
        }
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Left)
            {
                //raise event

                originalParent = transform.parent;

                transform.SetParent(transform.parent.parent);

                canvasGroup.blocksRaycasts = false;
            }
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Left)
            {
                transform.position = Input.mousePosition;
            }
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                transform.SetParent(originalParent);
                transform.localPosition = Vector3.zero;
                canvasGroup.blocksRaycasts = true;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            //onMouseStartHoverItem.Raise(ItemSlotUI.SlotItem);
            //raise event
            isHovering = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //onMouseEndHoverItem.Raise();
            //raise event
            isHovering = false;
        }
    }
}


