using System;

namespace GameLogic
{
    public class Field
    {
        public BigCell CoarseField { get; }

        public BigCell[] FineField { get; }

        public Field()
        {
            CoarseField = new BigCell();
            FineField = new BigCell[9];
            for (int i = 0; i < 9; i++)
            {
                FineField[i] = new BigCell();
            }
        }

        public void Set(int bigCell, int position, Cell owner)
        {
            if (bigCell > 8 || bigCell < 0) throw new ArgumentOutOfRangeException(nameof(position));

            FineField[bigCell].Set(position, owner);
            if (FineField[bigCell].Check() != Cell.Empty)
            {
                CoarseField.Set(bigCell, owner);
            }
        }
        public Cell Check() => CoarseField.Check();

    }
}