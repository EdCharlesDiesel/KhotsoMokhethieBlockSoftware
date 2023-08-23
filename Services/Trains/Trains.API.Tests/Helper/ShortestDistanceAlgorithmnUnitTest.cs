using Xunit;

namespace Trains.API.Tests.Helper
{
    public class ShortestDistanceAlgorithmnUnitTest
    {
        [Fact]
        public void CalculateDistanceUnitTest()
        {
            int start = 0;
            int[][][] roads = {
            new int[][] { new int[] { 1, 7 } },
            new int[][] { new int[] { 2, 6 }, new int[] { 3, 20 }, new int[] { 4, 3 } },
            new int[][] { new int[] { 3, 14 } },
            new int[][] { new int[] { 4, 2 } },
            new int[][] {},
            new int[][] {}
            };

            int[] expected = { 0, 7, 13, 27, 10, -1 };
            int[] actual = API.Helper.ShortestDistanceAlgorithmn.CalculateDistance(start, roads);

            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(expected[i] == actual[i]);
            }
        }
    }
}