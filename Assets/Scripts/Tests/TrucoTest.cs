using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TrucoTest {

    [Test]
    public void TrucoEndOfGameAfterThreeTurnsWithReTruco() {
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

        Truco game = new Truco(2);
        game.SetTruco();
        game.SetReTruco();

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
        Assert.IsTrue(game.GetTrucoScore().score == 3);
        Assert.IsTrue(game.GetTrucoScore().winner == 0);
        // no more turns after 3
        Assert.Throws(typeof(NoMoreTurnsException), () => game.PlayTurn(secondTurnCards));
    }

    [Test]
    public void TrucoEndOfGameAfterThreeTurnsInvalidReTruco() {
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

        Truco game = new Truco(2);

        // Act
        // no more turns after 3
        Assert.Throws(typeof(InvalidReTrucoException), () => game.SetReTruco());
    }

    [Test]
    public void TrucoEndOfGameAfterThreeTurnsWithValueCuatro() {
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

        Truco game = new Truco(2);
        game.SetTruco();
        game.SetReTruco();
        game.SetValueCuatro();

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
        Assert.IsTrue(game.GetTrucoScore().score == 4);
        Assert.IsTrue(game.GetTrucoScore().winner == 0);
        // no more turns after 3
        Assert.Throws(typeof(NoMoreTurnsException), () => game.PlayTurn(secondTurnCards));
    }

    [Test]
    public void TrucoGameEndOfGameAfterThreeTurnsInvalidValeCuatro() {
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

        // Act
        // Assess
        Assert.Throws(typeof(InvalidValeCuatroException), () => game.SetValueCuatro());
    }
}