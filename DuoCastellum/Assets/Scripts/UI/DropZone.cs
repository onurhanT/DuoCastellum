using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public GameObject objectSpawner;
    public GameObject playerPanel;

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Player player = playerPanel.GetComponent<Player>();
        CardObjectSpawner cardObjectSpawner = objectSpawner.GetComponent<CardObjectSpawner>();
        CardController cardController = eventData.pointerDrag.GetComponent<CardController>();
        CardData cardData = eventData.pointerDrag.GetComponent<CardData>();
        if (cardController != null && cardData != null)
        {
            if (player.CanDrawCard(cardData.manaCost))
            {
                cardObjectSpawner.SpawnMinion(cardData);
                player.ReduceMana(cardData.manaCost);
                cardController.DestroyCard();
            }
        }
    }
}
