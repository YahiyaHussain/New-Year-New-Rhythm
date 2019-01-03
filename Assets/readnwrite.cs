using UnityEngine;
using UnityEditor;
using System.IO;

public class readnwrite
{
    private static void WriteString()
    {
        string path = "Assets/Resources/test.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();

        //Re-import the file to update the reference in the editor
        TextAsset asset = Resources.Load<TextAsset>("test");
        //Print the text from the file
        Debug.Log(asset.text);
    }
    
    public static string ReadString(string path)
    {
        //string path = "Assets/Resources/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string s = reader.ReadToEnd();
        reader.Close();
        return s;
    }

}