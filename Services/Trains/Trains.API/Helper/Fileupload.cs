namespace Trains.API.Helper
{
    public class Fileupload
    {

        private static void ReadFile(string fileName)
        {
            string word = "start = 0";
            try
            {
                StreamReader reader = new StreamReader(fileName);
                using (reader)
                {
                    int occurrences = 0;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        int index = line.IndexOf(word);
                        while (index != -1)
                        {
                            occurrences++;
                            index = line.IndexOf(word, (index + 1));
                        }
                        line = reader.ReadLine();
                    }


                    System.Diagnostics.Debug.WriteLine(
                    "The word {0} occurs {1} times.", word, occurrences);
                }
            }
            catch (FileNotFoundException)
            {
                {
                    System.Diagnostics.Debug.WriteLine(
                    "Can not find file {0}.", fileName);
                }
            }
            catch (IOException)
            {
                System.Diagnostics.Debug.WriteLine(
                "Cannot read the file {0}.", fileName);
            }
        }
    }
}
