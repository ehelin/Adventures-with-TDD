using System;
using System.IO;
using Shared.interfaces;

namespace WindowsFileImpl
{
    public class WindowsFileImpl : IWindowsFile
    {
        public bool CreateFile(string path)
        {
            if (!File.Exists(path))
                File.Create(path).Close();

            return true;
        }

        public bool DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);

            return true;
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

        public bool WriteToFile(string path, string msg)
        {
            StreamWriter sw = null;
            bool result = false;

            try
            {
                sw = new StreamWriter(path);
                sw.WriteLine(msg);

                result = true;
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

            return result;
        }
    }
}
