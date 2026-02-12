using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class invSlot  :MonoBehaviour, IDropHandler {

    public void OnDrop (PointerEventData eventData) {
        if (transform.childCount == 0) {
            invItem item = eventData.pointerDrag.GetComponent<invItem>();
            item.parentAfterDrag = transform;
        }
    }
}
