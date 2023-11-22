using System;

public class NotEnoughCardsToPlayException : Exception {
    public NotEnoughCardsToPlayException(string message) : base(message) {
    }
}