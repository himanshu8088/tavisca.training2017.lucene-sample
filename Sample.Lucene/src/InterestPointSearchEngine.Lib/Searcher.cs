using System;
using Lucene.Net.Store;
using Lucene.Net.Search;
using Lucene.Net.Documents;
using System.IO;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using System.Collections.Generic;

namespace InterestPointSearchEngine
{
    public class Searcher
    {       
        public List<InterestPoint> Search(string indexerPath,string textToSearch)
        {
            var searchedPointOfInterests = new List<InterestPoint>();
            var directory = FSDirectory.Open(new DirectoryInfo(indexerPath));
            var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);            
            var parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_30, new[] { "Type", "Name", "Description" }, analyzer);
            Query query = parser.Parse(textToSearch);
            var searcher = new IndexSearcher(directory, true);
            TopDocs topDocs = searcher.Search(query, 10);
            int results = topDocs.ScoreDocs.Length;           

            for (int i = 0; i < results; i++)
            {
                ScoreDoc scoreDoc = topDocs.ScoreDocs[i];
                float score = scoreDoc.Score;
                int docId = scoreDoc.Doc;
                Document doc = searcher.Doc(docId);
                searchedPointOfInterests.Add(new InterestPoint(doc.Get("Type"), doc.Get("Name"),doc.Get("Description")));               
            }
            return searchedPointOfInterests;
        }
    }
}
