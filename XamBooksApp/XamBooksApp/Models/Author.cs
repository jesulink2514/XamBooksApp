using System;
using System.Collections.Generic;
using System.Text;
using XamBooksApp.ViewModels;

namespace XamBooksApp.Models
{
    public class Author
    {
        public string Name { get; set; }
        public int Followers { get; set; }
        public string ProfilePictureUrl { get; set; }
    }

    public class SampleAuthors
    {
        public static IEnumerable<AuthorViewModel> All => new[]
        {
            new AuthorViewModel{Name ="Jeff VandeMeer", Followers= 56240, ProfilePictureUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTrvgNlafcbYAJaYIXMT4sQC-1KvpXP9XDrYQpgh5wLIjxAG2A8" },
            new AuthorViewModel{Name ="Stephen King", Followers= 120832, ProfilePictureUrl="https://static.indigoimages.ca/2019/shop/124792_03b_holidaybookshop.png" , Following= true},
            new AuthorViewModel{Name ="J.K. Rowling", Followers= 342008, ProfilePictureUrl="https://specials-images.forbesimg.com/imageserve/5dfbbb1fe961e10007397ae6/960x0.jpg?fit=scale" },
        };
    }
}
