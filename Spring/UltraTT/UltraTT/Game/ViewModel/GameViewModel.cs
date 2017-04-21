using System;
using System.Collections.Generic;
using GameLogic;
using UltraTT.Command;
using UltraTT.Game.Model;
using UltraTT.ViewModel;

namespace UltraTT.Game.ViewModel
{
    public abstract class GameViewModel : BaseViewModel
    {


        protected GameViewModel()
        {
            _cellClick = new RelayCommand(Step, IsCellValid);

            _smallCells = new List<List<ViewModelCell>>();

            for (int i = 0; i < 9; i++)
            {
                _smallCells.Add(new List<ViewModelCell>());
                for (int j = 0; j < 9; j++)
                {
                    var vmCell = new ViewModelCell {Coords = CoordChanger(i, j)};
                    _smallCells[i].Add(vmCell);
                }
            }

            _bigCells = new List<List<ViewModelCell>>();

            for (int i = 0; i < 3; i++)
            {
                _bigCells.Add(new List<ViewModelCell>());
                for (int j = 0; j < 3; j++)
                {
                    var vmCell = new ViewModelCell {Coords = null};
                    _bigCells[i].Add(vmCell);
                }
            }
        }


        #region Properties

        public virtual double CellSize => 30;

        private List<List<ViewModelCell>> _smallCells;
        public virtual List<List<ViewModelCell>> SmallCells
        {
            get
            {
                return _smallCells;
            }
            set
            {
                _smallCells = value;

                OnPropertyChanged();
            }
        }

        private List<List<ViewModelCell>> _bigCells;
        public virtual List<List<ViewModelCell>> BigCells
        {
            get
            {
                return _bigCells;
            }
            set
            {
                _bigCells = value;

                OnPropertyChanged();
            }
        }


        private RelayCommand _cellClick;
        public virtual RelayCommand CellClick
        {
            get
            {
                return _cellClick;
            }
            set
            {
                _cellClick = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region EventHandlers

        public virtual void BigCellChangedHandler(object sender, Tuple<int, Cell> args)
        {
            int position = args.Item1;

            BigCells[position / 3][position % 3].PictSource = GetBigCellPictPath(args.Item2);
        }


        public abstract void GotWinnerHandler(object sender, Cell arg);


        public abstract void OwnerSwitchedHandler(object sender, Cell args);

        public virtual void CellChangedHandler(object sender, Tuple<int, int, Cell> args)
        {
            var bigCell = args.Item1;
            var position = args.Item2;

            var i = CoordChanger(bigCell, position).Item1;
            var j = CoordChanger(bigCell, position).Item2;

            SmallCells[i][j].PictSource = GetCellPictPath(args.Item3);
        }
        #endregion


        public virtual void NewGame()
        {

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _smallCells[i][j].PictSource = GetCellPictPath(Cell.Empty);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _bigCells[i][j].PictSource = GetBigCellPictPath(Cell.Empty);
                }
            }
        }

        protected virtual void DefaultSetup(GameModel model)
        {
            model.BigCellChanged += BigCellChangedHandler;
            model.CellChanged += CellChangedHandler;
            model.GotWinner += GotWinnerHandler;
            model.OwnerSwitched += OwnerSwitchedHandler;
        }

        public abstract bool IsCellValid(object obj);

        protected abstract void Step(object obj);


        #region Static methods

        protected static string GetCellPictPath(Cell cellType)
        {
            switch (cellType)
            {
                case Cell.Empty:
                    return "../../src/game/cells/empty.png";
                case Cell.Cross:
                    return "../../src/game/cells/cross.png";
                case Cell.Nought:
                    return "../../src/game/cells/nought.png";
                default:
                    return null;
            }
        }

        protected static string GetBigCellPictPath(Cell cellType)
        {
            switch (cellType)
            {
                case Cell.Empty:
                    return "../../src/game/cells/empty.png";
                case Cell.Cross:
                    return "../../src/game/cells/big_cross.png";
                case Cell.Nought:
                    return "../../src/game/cells/big_nought.png";
                default:
                    return null;
            }
        }

        protected static Tuple<int, int> CoordChanger(int x, int y)
        {
            return new Tuple<int, int>((x / 3) * 3 + y / 3, (x % 3) * 3 + y % 3);
        }

        protected static Tuple<int, int> CoordChanger(Tuple<int, int> arg)
        {
            return new Tuple<int, int>((arg.Item1 / 3) * 3 + arg.Item2 / 3, (arg.Item1 % 3) * 3 + arg.Item2 % 3);
        }

        #endregion


    }
}