using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UltraTT.Game.View
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BattleFieldView : UserControl
    {
        public BattleFieldView()
        {
            InitializeComponent();
        }


        #region DP


        public static readonly DependencyProperty SmallCellsProperty = DependencyProperty.Register(
            "SmallCells", typeof(IEnumerable), typeof(BattleFieldView), new PropertyMetadata(default(IEnumerable)));

        public IEnumerable SmallCells
        {
            get { return (IEnumerable) GetValue(SmallCellsProperty); }
            set { SetValue(SmallCellsProperty, value); }
        }

        public static readonly DependencyProperty BigCellsProperty = DependencyProperty.Register(
            "BigCells", typeof(IEnumerable), typeof(BattleFieldView), new PropertyMetadata(default(IEnumerable)));

        public IEnumerable BigCells
        {
            get { return (IEnumerable) GetValue(BigCellsProperty); }
            set { SetValue(BigCellsProperty, value); }
        }

        public static readonly DependencyProperty CellSizeProperty = DependencyProperty.Register(
            "CellSize", typeof(int), typeof(BattleFieldView), new PropertyMetadata(default(int)));

        public int CellSize
        {
            get { return (int) GetValue(CellSizeProperty); }
            set { SetValue(CellSizeProperty, value); }
        }

        public static readonly DependencyProperty CellClickProperty = DependencyProperty.Register(
            "CellClick", typeof(ICommand), typeof(BattleFieldView), new PropertyMetadata(default(ICommand)));

        public ICommand CellClick
        {
            get { return (ICommand) GetValue(CellClickProperty); }
            set { SetValue(CellClickProperty, value); }
        }

        #endregion


    }
}
