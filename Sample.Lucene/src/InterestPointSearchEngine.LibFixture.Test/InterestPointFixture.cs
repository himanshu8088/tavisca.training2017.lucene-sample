
using Xunit;

namespace InterestPointSearchEngine.Test
{   
    public class InterestPointFixture
    {
        [Fact]
        public void ToString_Should_Returns_POI_Details()
        {
            //Arrange
            InterestPoint poi = new InterestPoint("Zakarta", "Hotel", "A place for complete cuisine");
            string expectedVal = $"{poi.Name} is {poi.Type}({poi.Description})";

            //Act
            string actualVal = poi.ToString();

            //Assert
            Assert.Equal(expectedVal, actualVal);            
        }
    }
}
