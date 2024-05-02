namespace InfoGames.Models {
    public class EntryListViewModel {
        public List<JogoModel> Entries { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}
