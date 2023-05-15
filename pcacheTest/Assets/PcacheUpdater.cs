using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PcacheUpdater : MonoBehaviour
{
    void Start()
    {
        string pcacheFilePath = "Assets\\test.pcache";
        string newDataFilePath = "Assets\\TestField.pcache";


        List<string> pcacheLines = new List<string>();
        List<string> newLines = new List<string>();
        int numNewPoints = 0;

        // Read the existing pcache file
        using (StreamReader sr = new StreamReader(pcacheFilePath))
        {
            string line;
            bool headerEnded = false;
            while ((line = sr.ReadLine()) != null)
            {
                if (headerEnded)
                {
                    pcacheLines.Add(line);
                }
                else if (line.StartsWith("end_header"))
                {
                    headerEnded = true;
                    pcacheLines.Add(line);
                    numNewPoints += CountPoints(newDataFilePath); 
                }
                else
                {
                    pcacheLines.Add(line);
                }
            }
        }

        // Read the new data file
        using (StreamReader sr = new StreamReader(newDataFilePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                newLines.Add(line);
            }
        }

        // Update the value of elements
        int numPoints = pcacheLines.Count - 11 + numNewPoints;
        pcacheLines[3] = "elements " + numPoints;

        // Write the updated pcache file
        using (StreamWriter sw = new StreamWriter(pcacheFilePath))
        {
            foreach (string line in pcacheLines)
            {
                sw.WriteLine(line);
            }
        }

        // Append the new data to the pcache file /////////////
        using (StreamWriter sw = new StreamWriter(pcacheFilePath, true))
        {
            foreach (string line in newLines)
            {
                sw.WriteLine(line);
            }
        }
    }


    // Helper function to count the number of points in a file
    int CountPoints(string filePath)
    {
        int count = 0;
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (!line.StartsWith("#") && !line.StartsWith("format") && !line.StartsWith("comment") && !line.StartsWith("element") && !line.StartsWith("property") && !line.StartsWith("end_header"))
                {
                    count++;
                }
            }
        }
        return count;
    }

}
