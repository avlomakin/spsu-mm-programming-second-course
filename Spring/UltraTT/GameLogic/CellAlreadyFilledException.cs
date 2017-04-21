using System;

namespace GameLogic
{
    public class CellAlreadyFilledException : Exception
    {
        public CellAlreadyFilledException() : base() { }

        public CellAlreadyFilledException(string message) : base(message) { }
    }
}