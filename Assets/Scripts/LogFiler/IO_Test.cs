using UnityEngine;
using System;
using System.IO;
using System.Text;

public class IO_Test : MonoBehaviour
{

    private string path;
    private string writeTxt = "hello";
    private string fileName = "output.txt";

    void Start()
    {
        path = Application.dataPath + "/" + fileName;
        Debug.LogError(path);
        ReadFile();

        WriteFile(writeTxt);
    }

    void WriteFile(string txt)
    {
        FileInfo fi = new FileInfo(path);
        using (StreamWriter sw = fi.AppendText())
        {
            sw.WriteLine(txt);
        }
    }

    void ReadFile()
    {
        FileInfo fi = new FileInfo(path);
        try
        {
            using (StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8))
            {
                string readTxt = sr.ReadToEnd();
                Debug.LogError(readTxt);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

}