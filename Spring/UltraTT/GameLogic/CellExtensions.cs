namespace GameLogic
{
    public static class CellExtensions
    {
        public static Cell SwitchOwner(this Cell cell)
        {
            switch (cell)
            {
                case Cell.Cross:
                    return Cell.Nought;
                case Cell.Nought:
                    return Cell.Cross;
                default:
                    return Cell.Empty;
            }
        }
    }
}