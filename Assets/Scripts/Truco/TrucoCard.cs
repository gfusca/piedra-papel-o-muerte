using System;
using System.Collections;

public enum ColorIdentifier {
    ORO,
    BASTO,
    ESPADA,
    COPA,
    ANY
}

public class TrucoCard:  IComparable<TrucoCard> {
    public ColorIdentifier color;
    public int value;

    public bool played = false;

    public static TrucoCard[] especialTrucoCardArray = new TrucoCard[] {
        new TrucoCard(ColorIdentifier.ESPADA, 1),
        new TrucoCard(ColorIdentifier.BASTO, 1),
        new TrucoCard(ColorIdentifier.ESPADA, 7),
        new TrucoCard(ColorIdentifier.ORO, 7),
    };

    public static TrucoCard[] cardOrderValueArray = new TrucoCard[] {
        new TrucoCard(ColorIdentifier.ESPADA, 1),
        new TrucoCard(ColorIdentifier.BASTO, 1),
        new TrucoCard(ColorIdentifier.ESPADA, 7),
        new TrucoCard(ColorIdentifier.ORO, 7),
        new TrucoCard(ColorIdentifier.ANY, 3),
        new TrucoCard(ColorIdentifier.ANY, 2),
        // NOT ESPADA OR BASTO
        new TrucoCard(ColorIdentifier.ANY, 1),
        new TrucoCard(ColorIdentifier.ANY, 12),
        new TrucoCard(ColorIdentifier.ANY, 11),
        new TrucoCard(ColorIdentifier.ANY, 10),
        // NOT ESPADO OR ORO
        new TrucoCard(ColorIdentifier.ANY, 7),
        new TrucoCard(ColorIdentifier.ANY, 6),
        new TrucoCard(ColorIdentifier.ANY, 5),
        new TrucoCard(ColorIdentifier.ANY, 4),
    };

    public TrucoCard(ColorIdentifier color, int value) {
        this.value = value;
        this.color = color;
    }
    // compare two cards to decide which may win 
    // returns -1 if playerCard is bigger
    // returns 0 if cards are equal in value
    // returns 1 if enemyCard is bigger
    public int CompareTo(TrucoCard anotherCard) {
        int selfCardOrder = GetTrucoCardOrder();
        int anotherCardOrder = anotherCard.GetTrucoCardOrder();
        
        return selfCardOrder.CompareTo(anotherCardOrder);
    }

    public static bool operator>(TrucoCard card, TrucoCard anotherCard) {
        return card.CompareTo(anotherCard) < 0;
    }

    public static bool operator<(TrucoCard card, TrucoCard anotherCard) {
        return card.CompareTo(anotherCard) > 0;
    }

    public static bool operator==(TrucoCard card, TrucoCard anotherCard) {
        return card.CompareTo(anotherCard) == 0;
    }

    public static bool operator!=(TrucoCard card, TrucoCard anotherCard) {
        return !(card == anotherCard);
    }

    private int GetTrucoCardOrder() {
        int selfOrder = Array.FindIndex<TrucoCard>(
            cardOrderValueArray, 
            element => (element.color == this.color && element.value == this.value)
        );

        if (selfOrder < 0) {
            // if card not found try again ignoring color
            return Array.FindIndex<TrucoCard>(
                cardOrderValueArray, 
                element => !isCardEspecial(element) && element.value == this.value
            );
        }

        return selfOrder;
    }

    public int GetEnvidoValue() {
        if (this.value > 9) {
            return 0;
        }
        return this.value;
    }

    private bool isCardEspecial(TrucoCard card) {
        return Array.FindIndex<TrucoCard>(
            especialTrucoCardArray, 
            element => (element.color == card.color && element.value == card.value)
        ) >= 0;
    }
}