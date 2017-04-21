using System;
using GameLogic;
using UltraTT.Model;

namespace UltraTT.Game.Model
{
    public abstract class GameModel
    {
        public Field GameField { get; protected set; }
        public int CurrentCell { get; protected set; }

        protected bool IsFinished { get; set; }
        protected Cell CurrentOwner { get; set; }

        public event EventHandler<Cell> GotWinner;
        public event EventHandler<Cell> OwnerSwitched;
        public event EventHandler<Tuple<int, int, Cell>> CellChanged;
        public event EventHandler<Tuple<int, Cell>> BigCellChanged;

        protected GameModel()
        {
            GameField = new Field();
            CurrentCell = -1;
            CurrentOwner = Cell.Cross;
            IsFinished = false;
        }


        public virtual void Step(int bigCell, int position)
        {

            GameField.Set(bigCell, position, CurrentOwner);


            CurrentCell = (GameField.CoarseField.Cells[position] != Cell.Empty) ? -1 : position;


            CellChanged?.Invoke(this, new Tuple<int, int, Cell>(bigCell, position, CurrentOwner));            
            if (GameField.CoarseField.Cells[bigCell] != Cell.Empty)
            {
                BigCellChanged?.Invoke(this, new Tuple<int, Cell>(bigCell, CurrentOwner));
            }

            CurrentOwner = CurrentOwner.SwitchOwner();
            OwnerSwitched?.Invoke(this, CurrentOwner);

            CheckForWinner();
        }

        protected virtual void CheckForWinner()
        {
            var winner = GameField.Check();

            if (winner != Cell.Empty)
            {
                IsFinished = true;
                GotWinner?.Invoke(this, winner);
            }
        }

        public virtual bool IsCellValid(int bigCell, int smallCell)
        {
            return (bigCell == CurrentCell || CurrentCell == -1)
                   && GameField.FineField[bigCell].Cells[smallCell] == Cell.Empty
                   && GameField.CoarseField.Cells[bigCell] == Cell.Empty
                   && !IsFinished;
        }

        protected virtual void OnOwnerSwitched(Cell e)
        {
            OwnerSwitched?.Invoke(this, e);
        }
    }
}