using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Diagnostics;

public class JSONArchiver : MonoBehaviour
{
    private static String archivePath;
    private static String loadPath;
    private static String tosavePath;

    #region GetterSetter
    public static string JSONPath
    {
        get
        {
            if (tosavePath == null)
            {
                return JSONArchiver.tosavePath = Path.Combine(Application.persistentDataPath, "save", "tosave");
            }
            return JSONArchiver.tosavePath;
        }
    }

    public static string ArchivePath
    {
        get
        {
            if (archivePath == null)
            {
                return JSONArchiver.archivePath = Path.Combine(Application.persistentDataPath, "save", "archive");
            }
            return JSONArchiver.archivePath;
        }
    }
    #endregion
    private void Awake()
    {
        JSONArchiver.tosavePath = Path.Combine(Application.persistentDataPath, "save", "tosave");
        JSONArchiver.archivePath = Path.Combine(Application.persistentDataPath, "save", "archive");
        Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "save"));
        Directory.CreateDirectory(archivePath);
        Directory.CreateDirectory(tosavePath);
    }
#if UNITY_EDITOR

    [MenuItem("PathMenu/Save Path %g")]
    static void SavePath()
    {
        Application.OpenURL(Path.Combine(Application.persistentDataPath, "save"));

    }

    [MenuItem("PathMenu/Projet Path %j")]
    static void ProjetPath()
    {
        Application.OpenURL(Application.dataPath.Replace("/Assets", ""));

    }

    [MenuItem("PathMenu/Clear Path %h")]
    static void ClearPath()
    {
        Directory.Delete(Path.Combine(Application.persistentDataPath, "save"), true);
    }
    [MenuItem("PathMenu/Git Push %p")]
    static void GitPush()
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = Application.dataPath.Replace("/Assets", "") + "/gitSend.sh";
        psi.UseShellExecute = false;
        psi.RedirectStandardOutput = true;
        psi.Arguments = "";

        Process p = Process.Start(psi);
        string strOutput = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        UnityEngine.Debug.Log(strOutput);
    }
#endif

    public static void archiveJSON(int archiveNumber)
    {
        try
        {
            IEnumerable<String> jsonFiles = Directory.EnumerateFiles(tosavePath, "*.json");

            StreamWriter sw = new StreamWriter(Path.Combine(archivePath, "archive_" + archiveNumber + ".data"), false);

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
            UnityEngine.Debug.LogError(e.Message);
        }
    }

    public static void loadJSONsFromArchive(int archiveNumber)
    {
        try
        {
            Directory.Delete(tosavePath);
            Directory.CreateDirectory(tosavePath);
            StreamReader sr = new StreamReader(Path.Combine(archivePath, "archive_" + archiveNumber + ".data"));

            String res;
            while (!sr.EndOfStream)
            {
                int pos = 0;
                while ((res = sr.ReadLine()) == "") { }
                String filename = res;
                String fileSize = sr.ReadLine();
                UnityEngine.Debug.Log("filename : " + filename + ", size : " + fileSize + ", reader pos : ");
                Char[] buf = new char[int.Parse(fileSize)];
                pos += sr.ReadBlock(buf, 0, buf.Length);
                StreamWriter sw = new StreamWriter(tosavePath + "\\" + filename);
                sw.Write(buf);
                sw.Close();
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError(e.Message);
        }
    }

    public static void SaveJSONsFile(string path, string name, string content)
    {
        try
        {
            StreamWriter sw = new StreamWriter(Path.Combine(path, name + ".json"), false);
            sw.Write(content);
            sw.Close();
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError(e.Message);
        }
    }

    public static string LoadJsonsFile(string path, string name, out bool existe)
    {
        string pathComb = Path.Combine(path, name + ".json");
        existe = File.Exists(pathComb);
        if (existe)
        {
            try
            {
                StreamReader sr = new StreamReader(pathComb);
                String result = sr.ReadToEnd();
                sr.Close();
                return result;
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError(e.Message);
                existe = false;
                return "";
            }
        }
        return "";
    }
}
