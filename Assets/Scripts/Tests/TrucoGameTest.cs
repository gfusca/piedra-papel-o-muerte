using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TrucoGameTest {

    [Test]
    public void TrucoGamePlayEnvido() {
        // Arrange
        TrucoDeck deck1 = new TrucoDeck();
        deck1.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 1),
            new TrucoCard(ColorIdentifier.ESPADA, 10),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };

        TrucoDeck deck2 = new TrucoDeck();
        deck2.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 3),
            new TrucoCard(ColorIdentifier.ESPADA, 7),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };

        TrucoGame game = new TrucoGame();
        game.SetEnvido();

        // Act
        EnvidoScore envido = game.PlayEnvido(new TrucoDeck[]{deck1, deck2});
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(envido.score == 2);
        Assert.IsTrue(envido.winner == 1);
    }

    [Test]
    public void TrucoGamePlayRealEnvido() {
        // Arrange
        TrucoDeck deck1 = new TrucoDeck();
        deck1.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 1),
            new TrucoCard(ColorIdentifier.ESPADA, 10),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };

        TrucoDeck deck2 = new TrucoDeck();
        deck2.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 3),
            new TrucoCard(ColorIdentifier.ESPADA, 7),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };

        TrucoGame game = new TrucoGame();
        game.SetRealEnvido();

        // Act
        EnvidoScore envido = game.PlayEnvido(new TrucoDeck[]{deck1, deck2});
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(envido.score == 3);
        Assert.IsTrue(envido.winner == 1);
    }

    [Test]
    public void TrucoGamePlayEnvidoOnDrawWinFirstPlayer() {
        // Arrange
        TrucoDeck deck1 = new TrucoDeck();
        deck1.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 1),
            new TrucoCard(ColorIdentifier.ESPADA, 10),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };

        TrucoDeck deck2 = new TrucoDeck();
        deck2.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 10),
            new TrucoCard(ColorIdentifier.ORO, 12),
            new TrucoCard(ColorIdentifier.ESPADA, 1)
        };

        TrucoGame game = new TrucoGame();
        game.SetEnvido();

        // Act
        EnvidoScore envido = game.PlayEnvido(new TrucoDeck[]{deck1, deck2});
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(envido.score == 2);
        Assert.IsTrue(envido.winner == 0);
    }

    [Test]
    public void TrucoGamePlayOneTurnFirstPlayerWon() {
        // Arrange
        TrucoDeck deck1 = new TrucoDeck();
        deck1.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 3),
            new TrucoCard(ColorIdentifier.COPA, 7),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };
        TrucoDeck deck2 = new TrucoDeck();
        deck2.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 2),
            new TrucoCard(ColorIdentifier.COPA, 3),
            new TrucoCard(ColorIdentifier.COPA, 12)
        };

        TrucoGame game = new TrucoGame();

        TrucoCard[] cards = new TrucoCard[]{
            deck1.cards[0],
            deck2.cards[0]
        };

        // Act
        TrucoTurn turn = game.PlayTurn(cards);

        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(turn.winner == 0);
    }

    
    [Test]
    public void TrucoGamePlayOneTurnSecondPlayerWon() {
        // Arrange
        TrucoDeck deck1 = new TrucoDeck();
        deck1.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 1),
            new TrucoCard(ColorIdentifier.COPA, 7),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };
        TrucoDeck deck2 = new TrucoDeck();
        deck2.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.COPA, 2),
            new TrucoCard(ColorIdentifier.COPA, 3),
            new TrucoCard(ColorIdentifier.COPA, 12)
        };

        TrucoGame game = new TrucoGame();

        TrucoCard[] cards = new TrucoCard[]{
            deck1.cards[0],
            deck2.cards[0]
        };

        // Act
        TrucoTurn turn = game.PlayTurn(cards);
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(turn.winner == 1);
    }

     [Test]
    public void TrucoGamePlayOneTurnDraw() {
        // Arrange
        TrucoDeck deck1 = new TrucoDeck();
        deck1.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 1),
            new TrucoCard(ColorIdentifier.COPA, 7),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };
        TrucoDeck deck2 = new TrucoDeck();
        deck2.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.COPA, 1),
            new TrucoCard(ColorIdentifier.COPA, 3),
            new TrucoCard(ColorIdentifier.COPA, 12)
        };

        TrucoGame game = new TrucoGame();

        TrucoCard[] cards = new TrucoCard[]{
            deck1.cards[0],
            deck2.cards[0]
        };

        // Act
        TrucoTurn turn = game.PlayTurn(cards);
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(turn.winner < 0);
    }

    
    [Test]
    public void TrucoGameEndOfGameWithDraw() {
        // Arrange
        TrucoDeck deck1 = new TrucoDeck();
        deck1.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 1),
            new TrucoCard(ColorIdentifier.COPA, 7),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };
        TrucoDeck deck2 = new TrucoDeck();
        deck2.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.COPA, 1),
            new TrucoCard(ColorIdentifier.COPA, 3),
            new TrucoCard(ColorIdentifier.COPA, 12)
        };

        TrucoGame game = new TrucoGame();

        TrucoCard[] firstTurnCards = new TrucoCard[]{
            deck1.cards[0],
            deck2.cards[0]
        };

        TrucoCard[] secondTurnCards = new TrucoCard[]{
            deck1.cards[1],
            deck2.cards[1]
        };


        // Act
        TrucoTurn turn1 = game.PlayTurn(firstTurnCards);
        TrucoTurn turn2 = game.PlayTurn(secondTurnCards);

        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(turn1.winner == -1);
        Assert.IsTrue(turn2.winner == 1);
        Assert.IsTrue(game.GetPlayerScore(1) == 1);
        Assert.IsTrue(game.GetPlayerScore(0) == 0);
        Assert.Throws(typeof(NoMoreTurnsException), () => game.PlayTurn(secondTurnCards));
    }

    [Test]
    public void TrucoGameEndOfGameAfterThreeTurns() {
        // Arrange
        TrucoDeck deck1 = new TrucoDeck();
        deck1.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 3),
            new TrucoCard(ColorIdentifier.COPA, 7),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };
        TrucoDeck deck2 = new TrucoDeck();
        deck2.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.COPA, 2),
            new TrucoCard(ColorIdentifier.COPA, 3),
            new TrucoCard(ColorIdentifier.COPA, 12)
        };

        TrucoGame game = new TrucoGame();

        TrucoCard[] firstTurnCards = new TrucoCard[]{
            deck1.cards[0],
            deck2.cards[0]
        };

        TrucoCard[] secondTurnCards = new TrucoCard[]{
            deck1.cards[1],
            deck2.cards[1]
        };

        
        TrucoCard[] thridTurnCards = new TrucoCard[]{
            deck1.cards[2],
            deck2.cards[2]
        };


        // Act
        TrucoTurn turn1 = game.PlayTurn(firstTurnCards);
        TrucoTurn turn2 = game.PlayTurn(secondTurnCards);
        TrucoTurn turn3 = game.PlayTurn(thridTurnCards);

        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(turn1.winner == 0);
        Assert.IsTrue(turn2.winner == 1);
        Assert.IsTrue(turn3.winner == 0);
        Assert.IsTrue(game.GetPlayerScore(1) == 0);
        Assert.IsTrue(game.GetPlayerScore(0) == 1);
        // no more turns after 3
        Assert.Throws(typeof(NoMoreTurnsException), () => game.PlayTurn(secondTurnCards));
    }

    [Test]
    public void TrucoGameEndOfGameAfterThreeTurnsWithTruco() {
        // Arrange
        TrucoDeck deck1 = new TrucoDeck();
        deck1.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 3),
            new TrucoCard(ColorIdentifier.COPA, 7),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };
        TrucoDeck deck2 = new TrucoDeck();
        deck2.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.COPA, 2),
            new TrucoCard(ColorIdentifier.COPA, 3),
            new TrucoCard(ColorIdentifier.COPA, 12)
        };

        TrucoGame game = new TrucoGame();
        game.SetTruco();

        TrucoCard[] firstTurnCards = new TrucoCard[]{
            deck1.cards[0],
            deck2.cards[0]
        };

        TrucoCard[] secondTurnCards = new TrucoCard[]{
            deck1.cards[1],
            deck2.cards[1]
        };

        
        TrucoCard[] thridTurnCards = new TrucoCard[]{
            deck1.cards[2],
            deck2.cards[2]
        };


        // Act
        TrucoTurn turn1 = game.PlayTurn(firstTurnCards);
        TrucoTurn turn2 = game.PlayTurn(secondTurnCards);
        TrucoTurn turn3 = game.PlayTurn(thridTurnCards);

        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(turn1.winner == 0);
        Assert.IsTrue(turn2.winner == 1);
        Assert.IsTrue(turn3.winner == 0);
        Assert.IsTrue(game.GetPlayerScore(1) == 0);
        Assert.IsTrue(game.GetPlayerScore(0) == 2);
        // no more turns after 3
        Assert.Throws(typeof(NoMoreTurnsException), () => game.PlayTurn(secondTurnCards));
    }
}
