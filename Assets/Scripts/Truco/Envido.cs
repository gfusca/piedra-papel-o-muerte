using System;

public struct EnvidoScore {
    public int score;
    public int winner;
}

public class Envido {
    private EnvidoScore envidoScore;
    private int players;

    private static  int baseScore = 20;
    
    public Envido(int players) {
        envidoScore.score = 0;
        envidoScore.winner = -1;
        this.players = players;
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
                    if (secondCardIndex < 0) {
                        // first time to assing a second card
                        secondCardIndex = j;
                        firstCardIndex = i;
                    } else {
                        // another card with the same color has been found before
                        if (deck.cards[j].GetEnvidoValue() > deck.cards[firstCardIndex].GetEnvidoValue()) {
                            firstCardIndex = j;
                        } else if (deck.cards[j].GetEnvidoValue() > deck.cards[secondCardIndex].GetEnvidoValue()) { 
                            secondCardIndex = j;
                        }
                    }
                }
            }
        }

        bool envido = firstCardIndex >= 0 && secondCardIndex >= 0;
        if (envido) {
            return baseScore + deck.cards[firstCardIndex].GetEnvidoValue()
                + deck.cards[secondCardIndex].GetEnvidoValue();
        } else {
            // pick best card
            int score = 0;
            foreach(TrucoCard c in deck.cards) {
                if (c.GetEnvidoValue() > score) {
                    score = c.GetEnvidoValue();
                }
            }
            return score;
        }
    }

    public EnvidoScore SetDiscardEnvidoPlay(int playerWinner) {
        this.envidoScore.winner = playerWinner;
        this.envidoScore.score = envidoScore.score/2;
        return this.envidoScore;
    }

    public EnvidoScore SetRealEnvido() {
        envidoScore.score += 3;
        return envidoScore;
    }
    public EnvidoScore SetEnvido() {
        envidoScore.score += 2;
        return envidoScore;
    }

    public EnvidoScore SetFaltaEnvido() {
        // TODO: implement
        return envidoScore;
    }

    public EnvidoScore GetEnvidoScore() {
        return envidoScore;
    }
    
    public EnvidoScore DecideEnvidoWinner(TrucoDeck[] playerDecks) {
        if (playerDecks.Length != players) {
            throw new IncorrectAmountOfPlayersException($"There are more cards than players. Expected {players} got {playerDecks.Length}");
        }

        int maxScore = -1;
        int playerIndex = 0;
        int winnerIndex = 0;
        foreach(TrucoDeck deck in playerDecks) {
            int score = this.ComputeEnvido(deck);
            if (score > maxScore) {
                maxScore = score;
                winnerIndex = playerIndex;
            }
            playerIndex++;
        }

        envidoScore.winner = winnerIndex;
        return envidoScore;
    }
}