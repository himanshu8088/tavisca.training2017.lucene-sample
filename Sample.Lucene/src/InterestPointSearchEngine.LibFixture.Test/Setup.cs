using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestPointSearchEngine.Test
{
    public class Setup
    {        

        public InterestPointRepo SetInterestPointRepo(InterestPointRepo repo)
        {
            repo.Add("Zakarta", "Hotel", "A perfect place for perfect cuisine");
            repo.Add("Pimpo", "Hotel", "A good place for perfect cuisine");
            repo.Add("Django", "Hotel", "A fine place for perfect cuisine");
            repo.Add("Django", "Resort", "A great place for perfect cuisine");
            repo.Add("Malaka", "Restuarant", "A perfect place for perfect cuisine");
            return repo;
        }

        public void SetupIndexer(string dirPath)
        {
            Indexer indexer = new Indexer();            
            var repo= SetInterestPointRepo(new InterestPointRepo());
            indexer.Write(dirPath, repo.InterestPoints);
        }
    }
}
