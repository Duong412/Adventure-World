using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //[Header("UI")]
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {

        //throw new System.NotImplementedException();
        //GetComponent<Image>().raycastTarget = false;
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        Debug.Log("OnItem");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        Debug.Log("StayItem");
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        //throw new System.NotImplementedException();
        //GetComponent<Image>().raycastTarget = true;
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        Debug.Log("DropItem");
    }
}
