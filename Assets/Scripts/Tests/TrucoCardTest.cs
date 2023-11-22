using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TrucoCardTest {
    // A Test behaves as an ordinary method
    [Test]
    public void EspecialCardComparisionTest() {
        // Arrange
        TrucoCard card = new TrucoCard(ColorIdentifier.ESPADA, 1);
        TrucoCard anotherCard = new TrucoCard(ColorIdentifier.BASTO, 1);

        // Act
        bool cardWon = card > anotherCard;
        
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(cardWon);
    }

    [Test]
    public void SimpleCardWinComparisionTest() {
        // Arrange
        TrucoCard card = new TrucoCard(ColorIdentifier.ESPADA, 3);
        TrucoCard anotherCard = new TrucoCard(ColorIdentifier.BASTO, 4);

        // Act
        bool cardWon = card > anotherCard;
        
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(cardWon);
    }

    [Test]
    public void SimpleCardDrawComparisionTest() {
        // Arrange
        TrucoCard card = new TrucoCard(ColorIdentifier.ESPADA, 3);
        TrucoCard anotherCard = new TrucoCard(ColorIdentifier.BASTO, 3);

        // Act
        bool cardDraw = card == anotherCard;
        
        // Assess: Use the Assert class to test conditions
        Assert.IsTrue(cardDraw);
    }
}
