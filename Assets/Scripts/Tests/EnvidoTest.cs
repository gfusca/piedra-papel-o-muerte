using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnvidoTest {

    [Test]
    public void EnvidoCountWithThreeCards() {
        // Arrange
        TrucoDeck deck = new TrucoDeck();
        deck.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ESPADA, 1),
            new TrucoCard(ColorIdentifier.ESPADA, 6),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };
        Envido envido = new Envido(2);

        // Act
        int score = envido.ComputeEnvido(deck);
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(score == 27);
    }

    [Test]
    public void EnvidoCountWithTwoCards() {
        // Arrange
        TrucoDeck deck = new TrucoDeck();
        deck.cards = new TrucoCard[] {
            new TrucoCard(ColorIdentifier.ORO, 1),
            new TrucoCard(ColorIdentifier.ESPADA, 10),
            new TrucoCard(ColorIdentifier.ESPADA, 12)
        };
        Envido envido = new Envido(2);

        // Act
        int score = envido.ComputeEnvido(deck);
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(score == 20);
    }

    [Test]
    public void SetEnvidoSuccess() {
        // Arrange
        Envido envido = new Envido(2);
        // Act
        envido.SetEnvido();
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(envido.GetEnvidoScore().score == 2);
    }

    [Test]
    public void SetRealEnvidoSuccess() {
        // Arrange
        Envido envido = new Envido(2);
        // Act
        envido.SetRealEnvido();
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(envido.GetEnvidoScore().score == 3);
    }
}