using System;

namespace InterestPointSearchEngine.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InterestPointRepo repo = SetupRepo();
            Indexer indexer = new Indexer();
            var path = @"D:\Practice Work\Sample4.Lucene\cache-data";
            indexer.Write(path,repo.InterestPoints);
            
            Searcher searcher = new Searcher();
            
            while (true)
            {
                var results=searcher.Search(path, Console.ReadLine());
                Console.WriteLine("Result Found:");
                foreach(var result in results)
                {
                    Console.WriteLine(result.ToString());
                }
            }
        }

        public static InterestPointRepo SetupRepo()
        {
            InterestPointRepo repo = new InterestPointRepo();
            repo.Add("Zakarta", "Hotel", "A perfect place for perfect cuisine");
            repo.Add("Pimpo", "Hotel", "A good place for perfect cuisine");
            repo.Add("Django", "Hotel", "A fine place for perfect cuisine");
            repo.Add("Django", "Resort", "A great place for perfect cuisine");
            repo.Add("Malaka", "Restuarant", "A perfect place for perfect cuisine");
            return repo;
        }
    }
}
