﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class InventoryDropSpace : MonoBehaviour, IDropHandler
{

    Vector3 newScale;
    string objectDroppedTag;
    public int maxInventoryNumber = 1;
    public GameObject left;
    public GameObject right;
    public void Start()
    {
        newScale = new Vector3(1f, 1f);
        objectDroppedTag = "None";
    }
    public GameObject itemx
    {
        get
        {
            if (transform.childCount > (maxInventoryNumber - 1))
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item dropped");
        if (SceneManager.GetActiveScene().name == "NewD&D")
        {
            Debug.Log("it recognizes the scene");
            if (ItemDragHandler.itemBeingDragged.tag == "leftBracket")
            {
                ItemDragHandler.itemBeingDragged.transform.SetParent(left.transform, false);
            }
            else if (ItemDragHandler.itemBeingDragged.tag == "rightBracket")
            {
                ItemDragHandler.itemBeingDragged.transform.SetParent(right.transform, false);
            }
            else
            {
                ItemDragHandler.itemBeingDragged.transform.SetParent(transform, false);
            }
        }
        else
        {
            ItemDragHandler.itemBeingDragged.transform.SetParent(transform, false);
        }
        ItemDragHandler.itemBeingDragged.transform.localScale = DropSpace.originalTimeScale;
        gameObject.GetComponent<correctPanelOn>().updateSolved();
        Debug.Log(SceneManager.GetActiveScene().name);
    }
}
