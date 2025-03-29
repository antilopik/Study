namespace CheckList
{
    internal class CheckListItem
    {
        public readonly string title;

        public bool isDone;

        public CheckListItem(string title)
        {
            this.title = title;
        }
    }
}
