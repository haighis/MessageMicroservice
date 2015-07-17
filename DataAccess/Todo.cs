namespace TodoDataAccess
{
    /// <summary>
    /// Todo Data Model representation of a Todo that encapsulates a Todo entry with a Task name and Description.
    /// </summary>
    public class Todo
    {
        public int TodoId { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }
    }
}
