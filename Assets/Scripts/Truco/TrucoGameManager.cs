using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrucoGameManager : MonoBehaviour {
    public GameObject playerDeckArea;
    public GameObject enemyDeckArea;
    public GameObject playDeckArea;
    public GameObject scoreArea;
    public GameObject cardPrefab;

    private TrucoDeck playerDeck;
    private TrucoDeck enemyDeck;

    public TrucoGame trucoGame;

    // Start is called before the first frame update
    void Start() {
        trucoGame = new TrucoGame(2);
        playerDeck = trucoGame.GenerateTrucoTurnDeck();
        foreach(TrucoCard card in playerDeck.cards) {
            Debug.Log($"p card {card.color} {card.value}, {GetCardAssetNameByCard(card)}");
            GenerateCardObject(card, playerDeckArea, 0.35f, true); 
        }
        enemyDeck = trucoGame.GenerateTrucoTurnDeck();
        foreach(TrucoCard card in enemyDeck.cards) {
            Debug.Log($"e card {card.color} {card.value}, {GetCardAssetNameByCard(card)}");
            GenerateCardObject(card, enemyDeckArea);
        }
        
    }

    // Update is called once per frame
    void Update() {
     // TODO: hand player card select   
    }

    private GameObject GenerateCardObject(TrucoCard card, GameObject parent, float scale = 0.25f, bool flip = false) {
            GameObject obj = Resources.Load<GameObject>(GetCardAssetNameByCard(card));  
            obj.transform.localScale = new Vector3(scale, scale, 1); 
            obj.GetComponent<Card>().flipped = flip;
            Instantiate(obj, parent.transform);
            Debug.Log(obj);
            return obj;
    }

    private string GetCardAssetNameByCard(TrucoCard card) {
        string colorName = card.color.ToString().Substring(0,1).ToUpper() + card.color.ToString().Substring(1).ToLower();
        return $"Deck/Card{colorName}{card.value}";
    }
}
