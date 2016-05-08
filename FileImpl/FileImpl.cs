using System;
using Shared.interfaces;
using System.IO;

namespace FileImpl
{
    public class FileImpl : IFile
    {
        public void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        public void DeleteDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    File.Delete(file);
                }

                Directory.Delete(directory);
            }
        }

        public void CreateFile(string path)
        {
            if (!File.Exists(path))
                File.Create(path).Close();
        }

        public void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public string ReadFromFile(string path)
        {
            StreamReader sr = null;
            string result = string.Empty;

            try
            {
                sr = new StreamReader(path);
                result = sr.ReadToEnd();        
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
            }

            return result;
        }

        public void WriteToFile(string path, string msg)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(path);
                sw.WriteLine(msg);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
            }
        }
    }
}
