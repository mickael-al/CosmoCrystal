//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
//using System.Text;

public class JSONArchiver : MonoBehaviour
{

    private String archivePath;
    private String loadPath;
    private String tosavePath;
    //[SerializeField] private bool archive = false;
    
    void Start()
    {
        this.archivePath = Path.Combine(Application.persistentDataPath, "save", "archive");
        this.loadPath = Path.Combine(Application.persistentDataPath, "save", "load");
        this.tosavePath = Path.Combine(Application.persistentDataPath, "save", "tosave");

        //Debug.Log(Application.persistentDataPath);
        Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "save"));
        Directory.CreateDirectory(archivePath);
        Directory.CreateDirectory(loadPath);
        Directory.CreateDirectory(tosavePath);
    }

    /*void Update()
    {
        if(archive)
        {
            archive = false;
            archiveJSON();
            Debug.Log("archivage ok");
            loadJSONsFromArchive();
            Debug.Log("load ok");
        }
    }*/
    
    public void archiveJSON()
    {
        
        try
        {
             IEnumerable<String> jsonFiles = Directory.EnumerateFiles(tosavePath, "*.json");

            StreamWriter sw = new StreamWriter(Path.Combine(archivePath, "archive.data"), false);

            foreach (string currentFile in jsonFiles)
            {
                StreamReader sr = new StreamReader(currentFile);
                String content = sr.ReadToEnd();
                sr.Close();

                sw.WriteLine("");
                sw.WriteLine((new FileInfo(currentFile)).Name);
                sw.WriteLine((new FileInfo(currentFile)).Length);
                sw.Write(content);
            }

            sw.Close();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void loadJSONsFromArchive()
    {
        try
        {
            StreamReader sr = new StreamReader(Path.Combine(archivePath, "archive.data"));

            String res;
            while (!sr.EndOfStream)
            {
                int pos = 0;
                while((res = sr.ReadLine()) == "") { }
                String filename = res;
                String fileSize = sr.ReadLine();
                Debug.Log("filename : " + filename + ", size : " + fileSize + ", reader pos : ");
                Char[] buf = new char[int.Parse(fileSize)];
                pos += sr.ReadBlock(buf, 0,  buf.Length);
                StreamWriter sw = new StreamWriter(loadPath + "\\" + filename);
                sw.Write(buf);
                sw.Close();
            }
        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
