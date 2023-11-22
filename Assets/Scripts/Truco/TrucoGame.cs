using UnityEngine;
using System;
public class TrucoGame {
    private Envido envido;
    private Truco truco;
    private TrucoDeck deck;
    private static int[] cardsPerColor = {1,2,3,4,5,6,7,10,11,12};
    private static int totalDeckSize = 40;
    private static int cardsPerPlayer = 3;
    private bool[] playedCards;

    public TrucoGame(int players = 2, bool generateDeck = true) {
        envido = new Envido(players);
        truco = new Truco(players);
        playedCards = new bool[totalDeckSize];
        if (generateDeck)
            GenerateTrucoDeck();
    }

    public void GenerateTrucoDeck() {
        TrucoCard[] cards = new TrucoCard[totalDeckSize];
        int cardDeckPosition = 0;
        foreach (ColorIdentifier color in Enum.GetValues(typeof(ColorIdentifier))) {
            if (color == ColorIdentifier.ANY) continue;
            foreach(int cardNumber in cardsPerColor) {
                // generate card
                TrucoCard card = new TrucoCard(color, cardNumber);
                cards[cardDeckPosition] = card;
                ++cardDeckPosition;
            }
        }
        deck = new TrucoDeck();
        deck.cards = cards;
    }
    
    // one card for each player ordered by index
    public TrucoTurn PlayTurn(TrucoCard[] cards) {
        return truco.PlayTurn(cards);
    }

    public TrucoDeck GenerateTrucoTurnDeck() {
        TrucoDeck turnDeck = new TrucoDeck();
        turnDeck.cards = new TrucoCard[cardsPerPlayer];
        // get 3 random cards that have not been played before
        System.Random r = new System.Random();
        if (Array.FindAll(playedCards, elem => elem == false).Length < cardsPerPlayer) {
            throw new NotEnoughCardsToPlayException($"{cardsPerPlayer}or more cards are required");
        }

        for (int i = 0; i < cardsPerPlayer; ++i) {
            int cardDeckPosition = r.Next(totalDeckSize);
            while (playedCards[cardDeckPosition]) {
                cardDeckPosition = r.Next(totalDeckSize);
            }
            turnDeck.cards[i] = deck.cards[cardDeckPosition];
        }

        return turnDeck;
    }

    public int GetPlayerScore(int playerIndex) {
        EnvidoScore envidoScore = envido.GetEnvidoScore();
        int totalEnvido = envidoScore.winner == playerIndex ? envidoScore.score : 0;
        TrucoScore trucoScore = truco.GetTrucoScore();
        int totalTruco = trucoScore.winner == playerIndex ? trucoScore.score : 0;
        return totalEnvido + totalTruco;
    }
    public EnvidoScore PlayEnvido(TrucoDeck[] playerDecks) {
        return envido.DecideEnvidoWinner(playerDecks);
    }

    public EnvidoScore SetDiscardEnvidoPlay(int playerWinner) {
        return envido.SetDiscardEnvidoPlay(playerWinner);
    }

    public EnvidoScore SetRealEnvido() {
        return envido.SetRealEnvido();
    }
    public EnvidoScore SetEnvido() {
        return envido.SetEnvido();
    }

    public EnvidoScore SetFaltaEnvido() {
        return envido.SetFaltaEnvido();
    }
    public TrucoScore SetTruco() {
        return truco.SetTruco();
    }

    public TrucoScore SetReTruco() {
        return truco.SetReTruco();
    }

    public TrucoScore SetValueCuatro() {
        return truco.SetValueCuatro();
    }
}