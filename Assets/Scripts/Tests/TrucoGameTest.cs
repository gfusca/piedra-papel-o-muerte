using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TrucoGameTest
{
    [Test]
    public void TrucoGameEnvidoCountWithThreeCards()
    {
        // Arrange
        TrucoDeck deck = new TrucoDeck();
        deck.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifer.ESPADA, 1),
            new TrucoCard(ColorIdentifer.ESPADA, 6),
            new TrucoCard(ColorIdentifer.ESPADA, 12)
        };
        TrucoGame game = new TrucoGame();

        // Act
        int envido = game.ComputeEnvido(deck);
        Debug.Log(envido);
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(envido == 27);
    }

    [Test]
    public void TrucoGameEnvidoCountWithTwoCards()
    {
        // Arrange
        TrucoDeck deck = new TrucoDeck();
        deck.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifer.ORO, 1),
            new TrucoCard(ColorIdentifer.ESPADA, 10),
            new TrucoCard(ColorIdentifer.ESPADA, 12)
        };
        TrucoGame game = new TrucoGame();

        // Act
        int envido = game.ComputeEnvido(deck);
        Debug.Log(envido);
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(envido == 20);
    }

    [Test]
    public void TrucoGameEnvidoCountWithOneCard()
    {
        // Arrange
        TrucoDeck deck = new TrucoDeck();
        deck.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifer.ORO, 1),
            new TrucoCard(ColorIdentifer.COPA, 7),
            new TrucoCard(ColorIdentifer.ESPADA, 12)
        };
        TrucoGame game = new TrucoGame();

        // Act
        int envido = game.ComputeEnvido(deck);
        Debug.Log(envido);
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(envido == 7);
    }
}
