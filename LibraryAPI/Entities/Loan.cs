namespace LibraryAPI.Entities
{
    public class Loan
    {
        public int LoanID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int BookCopyID { get; set; }
        public virtual BookCopy BookCopy { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
