using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SerializeEvaluation
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public SerializeEvaluation(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public void Save(EvaluationData evaluationData, string fileID)
    {
        dataFileName = dataFileName + fileID + ".json";
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(evaluationData, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

        }
        catch (Exception e)
        {
            Debug.LogError("Error occured during evaluation serialization to file: " + fullPath + "\n" + e);
        }
    }
}
