using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using System.Collections.Generic;
using System.IO;

namespace InterestPointSearchEngine
{
    public class Indexer
    {
        public void Write(string path ,List<InterestPoint> poiList)
        {
            var dirInfo = new DirectoryInfo(path);
            if (dirInfo.Exists)
            {
                dirInfo.Delete(true);
                dirInfo = new DirectoryInfo(path);
            }

            var dir = FSDirectory.Open(dirInfo);
            var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            var writer = new IndexWriter(dir, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);

            foreach (var poi in poiList)
            {
                var doc = new Document();
                doc.Add(new Field("Type", poi.Name, Field.Store.YES, Field.Index.ANALYZED));
                doc.Add(new Field("Name", poi.Type, Field.Store.YES, Field.Index.ANALYZED));
                doc.Add(new Field("Description", poi.Description, Field.Store.YES, Field.Index.ANALYZED));
                writer.AddDocument(doc);
            }

            writer.Optimize();
            writer.Commit();
            writer.Dispose();
        }
    }
}
