using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class invItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    Image image;
    [HideInInspector] public Transform parentAfterDrag;

    void Start() {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData) {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint
        );
        transform.localPosition = localPoint;
    }

    public void OnEndDrag(PointerEventData eventData) {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        transform.localPosition = Vector3.zero;
        Debug.Log ("OnEndDrag Call");

        if (EventSystem.current.IsPointerOverGameObject()) {
            Debug.Log ("Dice back to inventory");
        } else {
            RollAttempt();
        }
    }

    
    void RollAttempt () {
        DuelManager dManager = GameObject.Find ("GameManager").GetComponent<DuelManager>();
        if (dManager != null) {
            dManager.TestDuel();
        }
    }
}
