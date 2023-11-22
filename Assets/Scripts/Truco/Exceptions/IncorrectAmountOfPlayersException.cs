using System;

public class IncorrectAmountOfPlayersException : Exception {
    public IncorrectAmountOfPlayersException(string message) : base(message) {
    }
}