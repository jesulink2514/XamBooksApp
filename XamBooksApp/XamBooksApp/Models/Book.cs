using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using PropertyChanged;

namespace XamBooksApp.Models
{
    public class Book : INotifyPropertyChanged
    {
        [DoNotNotify] public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public string Abstract { get; set; }
        public string AuthorName { get; set; }
        public string AuthorProfilePictureUrl { get; set; }
        public float PercentageRead { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public static class Books
    {
        public static IEnumerable<Book> All => new[]
        {
            new Book {
                Title = "Luna: Wolf Moon",
                AuthorName= "Ian McDonald",
                PercentageRead = 0.63f,
                AuthorProfilePictureUrl="https://upload.wikimedia.org/wikipedia/commons/5/56/McDonald_Ian.jpg",
                CoverUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/e/ec/Luna_Wolf_Moon-2016.png/220px-Luna_Wolf_Moon-2016.png",
                Abstract = "Recovering from his near-fatal Moon-run escape through vacuum, Lucas Corta has only one source of potential allies to reclaim his empire: Earth. But as those who have lived on the Moon for an extended period are physically incapable of surviving on Eart"},
            new Book
            {
                Title = "Beneath the Sugar Sky",
                AuthorName= "Seanan McGuire",
                PercentageRead = 0.47f,
                AuthorProfilePictureUrl="https://images.wook.pt/getresourcesservlet/GetResource?E4b6rCNEf5IJgHJVnbo4kZLC0eq7cSl+aMaZVm9qaU8=",
                CoverUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1494436031l/27366528.jpg",
                Abstract = "When Rini lands with a literal splash in the pond behind Eleanor West's Home for Wayward Children, the last thing she expects to find is that her mother, Sumi, died years before Rini was even conceived. But Rini can’t let Reality get in the way of her quest – not when she has an entire world to save! (Much more common than one would suppose.)"},
        };
    }
}
