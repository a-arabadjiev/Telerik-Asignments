namespace Board_R.Models
{
    using Board_R.Models.Base;

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

        public static void LogHistory()
        {
            foreach (BoardItem item in items) 
            {
                Console.WriteLine(item.ViewHistory());
            }
        }
    }
}
