using UnityEngine;
using System;

public class TrucoGame {
    private static  int baseScore = 20;
    private TrucoTurn[] turns; 
    private int currentTurn;
    private int players;

    public TrucoGame() {
        turns = new TrucoTurn[3];
        currentTurn = 0;
        players = 2;
    }
    
    // one card for each player ordered by index
    public void playTurn(TrucoCard[] cards) {
    }
    
    // find two cards with the same color
    // if there's more than two pick best two (max value)
    // examples:
    //      (E 1,E 7,O 1) => 28
    //      (E 12,O 1,E 6) => 26
    //      (E 6,E 7,O 1) => 33
    //      (E 6,E 7,E 12) => 33
    //      (E 6,C 7,O 12) => 7
    public int ComputeEnvido(TrucoDeck deck) {
        int firstCardIndex = 0;
        int secondCardIndex = -1;
        for (int i = 0; i < deck.cards.Length; i++) {
            for (int j = i+1; j < deck.cards.Length; j++) {
                // same color, see if it maximizes value
                if (deck.cards[i].color == deck.cards[j].color) {
                    Debug.LogFormat("Same Color: {0},  {1}", deck.cards[i].value, deck.cards[j].value);
                    if (secondCardIndex < 0) {
                        // first time to assing a second card
                        secondCardIndex = j;
                        firstCardIndex = i;
                    } else {
                        // another card with the same color has been found before
                        if (GetEnvidoValue(deck.cards[j]) > GetEnvidoValue(deck.cards[firstCardIndex])) {
                            firstCardIndex = j;
                        } else if (GetEnvidoValue(deck.cards[j]) > GetEnvidoValue(deck.cards[secondCardIndex])) { 
                            secondCardIndex = j;
                        }
                    }
                }
            }
        }

        bool envido = firstCardIndex >= 0 && secondCardIndex >= 0;
        if (envido) {
            return baseScore + GetEnvidoValue(deck.cards[firstCardIndex]) 
                + GetEnvidoValue(deck.cards[secondCardIndex]);
        } else {
            // pick best card
            int score = 0;
            foreach(TrucoCard c in deck.cards) {
                if (GetEnvidoValue(c) > score) {
                    score = GetEnvidoValue(c);
                }
            }
            return score;
        }
    }

    private int GetEnvidoValue(TrucoCard card) {
        if (card.value > 9) {
            return 0;
        }
        return card.value;
    }

}