using System.IO;
using System.Linq;
using Xunit;
namespace InterestPointSearchEngine.Test
{
    public class IndexerFixture
    {
        [Fact]
        public void Write_Should_Document_InterestPoints_To_Physical_Location()
        {
            //Arrange
            Indexer indexer = new Indexer();
            string dirPath = @"D:\Practice Work\Sample4.Lucene\test-data\test-generated-data1";
            Setup setup = new Setup();
            InterestPointRepo repo = setup.SetInterestPointRepo(new InterestPointRepo());
            
            //Act
            indexer.Write(dirPath, repo.InterestPoints);
            var actualDirLen = DirSize(new DirectoryInfo(dirPath));

            //Assert
            Assert.NotNull(actualDirLen);            
        }        
        
        public long DirSize(DirectoryInfo dir)
        {
            return dir.GetFiles().Sum(fi => fi.Length) +
                   dir.GetDirectories().Sum(di => DirSize(di));
        }        
    }
}
