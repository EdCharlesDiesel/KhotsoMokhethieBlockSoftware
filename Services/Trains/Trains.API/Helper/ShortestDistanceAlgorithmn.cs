namespace Trains.API.Helper
{
    public static class ShortestDistanceAlgorithmn
    {
        public static int[] CalculateDistance(int start, int[][][] roads)
        {
            int numberOfRoads = roads.Length;

            int[] minimumDistances = new int[roads.Length];
            Array.Fill(minimumDistances, Int32.MaxValue);
            minimumDistances[start] = 0;

            HashSet<int> visited = new HashSet<int>();

            while (visited.Count != numberOfRoads)
            {
                int[] getRoadData = getRoadWithMinDistance(minimumDistances, visited);
                int road = getRoadData[0];
                int currentMinDistance = getRoadData[1];

                if (currentMinDistance == Int32.MaxValue) { break; }

                visited.Add(road);

                foreach (var road_ in roads[road])
                {
                    int destination = road_[0];
                    int distanceToDestination = road_[1];

                    if (visited.Contains(destination)) { continue; }
                    int newPathDistance = currentMinDistance + distanceToDestination;
                    int currentDestinationDitance = minimumDistances[destination];
                    if (newPathDistance < currentDestinationDitance)
                    {
                        minimumDistances[destination] = newPathDistance;
                    }
                }
            }

            int[] finalDistance = new int[minimumDistances.Length];
            for (int i = 0; i < minimumDistances.Length; i++)
            {
                int distance = minimumDistances[i];
                if (distance == Int32.MaxValue)
                {
                    finalDistance[i] = -1;
                }
                else
                {
                    finalDistance[i] = distance;
                }
            }

            return finalDistance;
        }

        private static int[] getRoadWithMinDistance(int[] distances, HashSet<int> visited)
        {
            int currentMinDistance = Int32.MaxValue;
            int road = -1;

            for (int roadIndex = 0; roadIndex < distances.Length; roadIndex++)
            {
                int distance = distances[roadIndex];

                if (visited.Contains(roadIndex))
                {
                    continue;
                }


                if (distance<= currentMinDistance)
                {
                    road = roadIndex;
                    currentMinDistance = distance;
                }
            }

            return new int[] { road, currentMinDistance };
        }
    }
}
