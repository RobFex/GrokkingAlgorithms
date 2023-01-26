namespace GrokkingAlgorithms.Chapter_8
{
    public class Greedy
    {
        public static List<string> SearchStations(List<string> statesNeeded, Dictionary<string, List<string>> stations)
        {
            string bestStation = string.Empty;
            List<string> statesCovered = new List<string>();
            List<string> result = new List<string>();

            while (statesCovered.Count < statesNeeded.Count)
            {
                foreach (string key in stations.Keys)
                {
                    if (bestStation == string.Empty)
                    {
                        bestStation = key;
                    }

                    else
                    {
                        for (int i = 0; i < statesCovered.Count; i++)
                        {
                            string state = statesCovered[i];
                            for (int j = 0; j < stations[key].Count; j++)
                            {
                                string keyState = stations[key][j];
                                if (keyState == state)
                                {
                                    stations[key].Remove(keyState);
                                }
                            }
                        }

                        for (int i = 0; i < statesCovered.Count; i++)
                        {
                            string state = statesCovered[i];
                            for (int j = 0; j < stations[bestStation].Count; j++)
                            {
                                string bestState = stations[bestStation][j];
                                if (bestState == state)
                                {
                                    stations[bestStation].Remove(bestState);
                                }
                            }
                        }

                        if (stations[bestStation].Count < stations[key].Count)
                            bestStation = key;
                    }
                }

                statesCovered.AddRange(stations[bestStation]);
                result.Add(bestStation);
            }

            return result;
        }
    }
}
