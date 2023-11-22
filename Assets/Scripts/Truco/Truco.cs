using System;


public struct TrucoScore {
    public int score;
    public int winner;
}

public class Truco {
    private TrucoScore trucoScore;
    private int players;
    private int currentTurn;
    private TrucoTurn[] turns; 

    public Truco(int players) {
        turns = new TrucoTurn[3];
        this.players = 2;
        this.currentTurn = -1;
        trucoScore.score = 1;
        trucoScore.winner = -1;       
    }

    public TrucoTurn PlayTurn(TrucoCard[] cards) {
        if (cards.Length != players) {
            throw new IncorrectAmountOfPlayersException($"There are more cards than players. Expected {players} got {cards.Length}");
        }
        if (IsEndOfGame()) {
            throw new NoMoreTurnsException($"All the turns have been played");
        }
        
        // decide winner, -1 no winner (draw) else player index
        TrucoTurn turn = CreateTrucoTurn(cards);
        ++currentTurn;
        
        // if there's a draw in the last turn wins whoever won the first turn
        if (currentTurn == 2 && turn.winner == -1) {
            turn.winner = turns[0].winner;
        }

        turns[currentTurn] = turn;

        if (IsEndOfGame()) {
            DecideTrucoWinner();
        }

        return turn;
    }

    private TrucoScore DecideTrucoWinner() {
        // compute truco winner
        int playerTrucoWinner = -1;
        // player with most wins is the truco winner
        int[] wins = new int[players];
        for(int t = 0; t <= currentTurn; ++t) {
            if (turns[t].winner >= 0) {
                wins[turns[t].winner] = wins[turns[t].winner]+1;
            }
        }
        int winCount = -1;
        for(int i = 0; i < wins.Length; ++i) {
            if (wins[i] > winCount ) {
                winCount = wins[i];
                playerTrucoWinner = i;
            }
        }
        trucoScore.winner = playerTrucoWinner;

        return trucoScore;
    }

    // decide winner, -1 no winner (draw) else player index
    private TrucoTurn CreateTrucoTurn(TrucoCard[] cards) {
        int winner = -1;
        int playerIndex = 0;
        foreach(TrucoCard c in cards) {
            if (winner < 0) {
                winner = playerIndex;
            } else {
                if (c > cards[winner]) {
                    winner = playerIndex;
                } else if (c == cards[winner]) {
                    winner = -1;
                }
            }
            playerIndex++;
        }
        // new turn
        TrucoTurn turn = new TrucoTurn(cards, winner);
        return turn;
    }

    public TrucoScore GetTrucoScore() {
        return trucoScore;
    }

    public TrucoScore SetTruco() {
        trucoScore.score = 2;
        return trucoScore;
    }

    public TrucoScore SetReTruco() {
        if (trucoScore.score < 2) {
            throw new InvalidReTrucoException($"Cannot set retruco without setting truco first");
        }
        trucoScore.score = 3;
        return trucoScore;
    }

    public TrucoScore SetValueCuatro() {
        if (trucoScore.score < 3) {
            throw new InvalidValeCuatroException($"Cannot set value cuatro without setting retruco first");
        }
        trucoScore.score = 4;
        return trucoScore;
    }
    
    // no more turns to play
    private bool IsEndOfGame() {
        return currentTurn == 2 || currentTurn == 1 && turns[0].winner < 0;
    }
}