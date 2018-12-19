using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {
    private CardData cardData;
    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;
    public Text mana;
    public Text damage;
    public Text health;

    // Use this for initialization
    void Start () {
        cardData = this.transform.GetComponent<CardData>() as CardData;
        nameText.text = cardData.Name;
        descriptionText.text = cardData.description;
        mana.text = cardData.manaCost.ToString();
        damage.text = cardData.damage.ToString();
        health.text = cardData.health.ToString();
        artworkImage.sprite = Resources.Load<Sprite>("Sprites/" + cardData.Name);
    }

}
