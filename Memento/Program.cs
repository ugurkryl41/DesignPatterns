using System;
using System.Threading;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book { Isbn = 12345, Title = "Hugo" };
            book.ShowBook();
            CareTaker careTaker = new CareTaker();
            careTaker.Memento = book.CreateUndo();
            
            book.Isbn = 54321;
            book.ShowBook();
            
            book.RestoreFromUndo(careTaker.Memento);
            book.ShowBook();
        }
    }

    class Book
    {
        private int _isbn;
        private string _title;
        private DateTime _lastEdited;

        public int Isbn { 
            get { return _isbn; }
            set { _isbn = value; SetLastEdited(); }
        }
        public string Title { 
            get { return _title; } 
            set { _title = value; SetLastEdited(); }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn,_title,_lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine(Isbn+Title+_lastEdited);
        }
    }

    class Memento
    {
        public Memento(int ısbn, string title, DateTime lastEdited)
        {
            Isbn = ısbn;
            Title = title;
            LastEdited = lastEdited;
        }

        public int Isbn { get; set; }
        public string Title { get; set; }
        public DateTime LastEdited { get; set; }                
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
