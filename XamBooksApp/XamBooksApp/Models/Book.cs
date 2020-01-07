using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using PropertyChanged;

namespace XamBooksApp.Models
{
    public class Book: INotifyPropertyChanged
    {
        [DoNotNotify]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
