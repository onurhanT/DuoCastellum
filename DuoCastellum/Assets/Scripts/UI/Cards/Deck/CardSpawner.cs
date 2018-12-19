using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {
    private ICardSpawnStrategy cardSpawnStrategy;
    public GameObject cardPanel;
    public GameObject heroPanel;
    public int startSize;
    private bool firstCards = true;

	// Use this for initialization
	void Start () {
        cardSpawnStrategy = new RandomCardSpawnStrategy();
        for(int i = 0; i < startSize; i++)
        {
            SpawnCard();
        }
        firstCards = false;
	}
	
    public void SpawnCard()
    {
        Player player = heroPanel.GetComponent<Player>();
        if (player.CanDrawCard(1) || firstCards){
            MinionCard minionCard = cardSpawnStrategy.SpawnCard();
            InstantiateCard(minionCard);
            player.ReduceMana(1f);
        }
    }

    private void InstantiateCard(MinionCard minionCard)
    {
        GameObject card = Resources.Load<GameObject>("Cards/" + minionCard.GetName());
        if (card != null)
        {
            if(card.GetComponent<CardData>() == null)
            {
                card.AddComponent<CardData>();
                card.GetComponent<CardData>().Clone(minionCard);
            }
            GameObject newCard = Instantiate(card) as GameObject;
            newCard.transform.SetParent(cardPanel.transform);
            newCard.transform.localScale = new Vector3(0.70f, 0.70f);
        }
    }
	
}
