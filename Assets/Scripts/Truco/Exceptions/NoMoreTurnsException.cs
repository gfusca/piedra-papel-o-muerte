using System;
public class NoMoreTurnsException : Exception {
    public NoMoreTurnsException(string message) : base(message) {
    }
}

