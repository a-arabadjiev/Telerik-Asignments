namespace Board_R.Models
{
    public static class Board
    {
        private readonly static List<BoardItem> items = new List<BoardItem>();

        public static int TotalItems
        {
            get 
            { 
                return items.Count; 
            }
        }

        public static void AddItem(BoardItem item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }
            else
            {
                throw new InvalidOperationException("Item already exists on the board.");
            }
        }

    }
}
