using System;
using System.Collections;

public enum ColorIdentifer {
    ORO,
    BASTO,
    ESPADA,
    COPA
}

public class TrucoCard:  IComparable<TrucoCard> {
    public ColorIdentifer color;
    public int value;
    public static TrucoCard[] specialCards = new TrucoCard[] {
        new TrucoCard(ColorIdentifer.ESPADA, 1),
        new TrucoCard(ColorIdentifer.BASTO, 1),
        new TrucoCard(ColorIdentifer.ESPADA, 7),
        new TrucoCard(ColorIdentifer.ORO, 7)
    };

    public TrucoCard(ColorIdentifer color, int value) {
        this.value = value;
        this.color = color;
    }
    // compare two cards to decide which may win 
    // returns -1 if playerCard is bigger
    // returns 0 if cards are equal in value
    // returns 1 if enemyCard is bigger
    public int CompareTo(TrucoCard anotherCard) {
        if (!isCardEspecial(this) && !isCardEspecial(anotherCard)) {
            // not especial cards, so just a simple numeric comparision
            return this.value.CompareTo(anotherCard.value);
        }

        if (isCardEspecial(this) || !isCardEspecial(anotherCard)) {
            // especial card alway wins over other cards
            return -1;
        }

        if (!isCardEspecial(this) || isCardEspecial(anotherCard)) {
            // especial card alway wins over other cards
            return 1;
        }

        if (isCardEspecial(this) && isCardEspecial(anotherCard)) {
            return Array.FindIndex(
                    specialCards, 
                    element => (element.color == this.color && element.value == this.value)
                    ).CompareTo(
                        Array.FindIndex(
                            specialCards,
                            element => (element.color == anotherCard.color && element.value == anotherCard.value)));
        }

        return -1;
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

    private bool isCardEspecial(TrucoCard card) {
        return Array.FindIndex<TrucoCard>(
            specialCards, 
            element => (element.color == card.color && element.value == card.value)
        ) >= 0;
    }
}