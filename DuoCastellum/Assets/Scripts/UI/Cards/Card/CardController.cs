using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    private Transform parent;
    private bool destroy = false;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        parent = this.transform.parent.transform;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (destroy)
        {
            Destroy(gameObject, 0.1f);
        }
        else
        {
            this.transform.SetParent(parent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void DestroyCard()
    {
        destroy = true;
    }
}
