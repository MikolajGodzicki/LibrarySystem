namespace LibraryAPI.Entities
{
    public class BookCopy
    {
        public int BookCopyID { get; set; }
        public int BookID { get; set; }
        public virtual Book Book {  get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
