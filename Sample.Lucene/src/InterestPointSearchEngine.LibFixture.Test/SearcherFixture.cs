using System.Collections.Generic;
using Xunit;

namespace InterestPointSearchEngine.Test
{
    public class SearcherFixture
    {        
        [Fact]
        public void Search_Should_Return_Results_Found()
        {
            //Arrange
            var path = @"D:\Practice Work\Sample4.Lucene\test-data\test-generated-data2";
            Setup setup = new Setup();
            setup.SetupIndexer(path);
            Searcher searcher = new Searcher();

            //Act
            var resultFound = searcher.Search(path, "Hotel");

            //Assert
            Assert.NotNull(resultFound);
        }

        [Fact]
        public void Search_Should_Return_Valid_Results()
        {
            //Arrange
            var path = @"D:\Practice Work\Sample4.Lucene\test-data\test-generated-data3";
            Setup setup = new Setup();
            setup.SetupIndexer(path);
            Searcher searcher = new Searcher();
            int i = 0;

            //Act
            var resultsFound = searcher.Search(path, "Hotel");

            //Assert            
            foreach(var expectedVal in GetValueFromDataGenerator())
            {
                var actualValue = resultsFound[i++].ToString();               
                Assert.Equal(expectedVal, actualValue);               
            }            
        }

        public IEnumerable<string> GetValueFromDataGenerator()
        {
            yield return "Hotel is Zakarta(A perfect place for perfect cuisine)" ;
            yield return "Hotel is Pimpo(A good place for perfect cuisine)";
            yield return "Hotel is Django(A fine place for perfect cuisine)";
        }

    }
}
