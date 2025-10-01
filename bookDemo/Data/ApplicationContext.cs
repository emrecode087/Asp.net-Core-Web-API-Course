using bookDemo.Models;

namespace bookDemo.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book { Id = 1, Price = 120, Title = "Nutuk - Mustafa Kemal Atatürk" },
                new Book { Id = 2, Price = 95, Title = "Saatleri Ayarlama Enstitüsü - Ahmet Hamdi Tanpınar" },
                new Book { Id = 3, Price = 80, Title = "Tutunamayanlar - Oğuz Atay" },
                new Book { Id = 4, Price = 65, Title = "Kürk Mantolu Madonna - Sabahattin Ali" },
                new Book { Id = 5, Price = 70, Title = "İnce Memed - Yaşar Kemal" },
                new Book { Id = 6, Price = 60, Title = "Çalıkuşu - Reşat Nuri Güntekin" },
                new Book { Id = 7, Price = 55, Title = "Yaban - Yakup Kadri Karaosmanoğlu" },
                new Book { Id = 8, Price = 50, Title = "Eylül - Mehmet Rauf" },
                new Book { Id = 9, Price = 85, Title = "Aşk-ı Memnu - Halit Ziya Uşaklıgil" },
                new Book { Id = 10, Price = 90, Title = "Benim Adım Kırmızı - Orhan Pamuk" },
                new Book { Id = 11, Price = 100, Title = "Masumiyet Müzesi - Orhan Pamuk" },
                new Book { Id = 12, Price = 75, Title = "Serenad - Zülfü Livaneli" },
                new Book { Id = 13, Price = 65, Title = "Leyla ile Mecnun - Sezai Karakoç" },
                new Book { Id = 14, Price = 55, Title = "Hanımın Çiftliği - Orhan Kemal" },
                new Book { Id = 15, Price = 60, Title = "Firarperest - Cemal Süreya" }
            };
        }
    }
}
