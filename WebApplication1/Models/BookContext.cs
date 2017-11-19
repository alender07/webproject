using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class BookContext:DbContext
    {
        public DbSet<Book> Books { get; set; } //типизировано моделью book
        public DbSet<Purchase> Purchases { get; set; }
    }

    public class BookObInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Бойцовский клуб", Author = "Чак Паланик", Price = 400});
            db.Books.Add(new Book { Name = "451 градус по Фаренгейту", Author = "Рэй Брэдбери", Price = 380});
            db.Books.Add(new Book { Name = "Зов Ктулху", Author = "Говард Лавкрафт", Price = 350});
           
            base.Seed(db);
        }
    }
}