using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace WebAPIUserServices.Service
{
    public static class ImageControlHelper
    {

        /// <summary>
        /// Folder to upload internal
        /// </summary>
        //   private string uploaddirectory = string.Empty;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1307:SpecifyStringComparison", MessageId = "System.String.EndsWith(System.String)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1307:SpecifyStringComparison", MessageId = "System.String.StartsWith(System.String)")]
        public static void OnFileUpload(MultipartFormDataStreamProvider provider)
        {
            if (provider != null)
            {
                foreach (var file in provider.FileData)
                {
                    // This illustrates how to get the file names for uploaded files.
                    string fileName = file.Headers.ContentDisposition.FileName;
                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Trim('"');
                    }
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                    {
                        fileName = Path.GetFileName(fileName);
                    }

                    string imagesFolder = AppDomain.CurrentDomain.BaseDirectory+@"Imagenes\Files";
                    CheckApplicationImagesFolder(imagesFolder);
                    string locaFile = file.LocalFileName;
                    string destiny = string.Format(CultureInfo.InvariantCulture, "{0}/{1}", imagesFolder, fileName);

                    if (File.Exists(destiny))
                    {
                        File.Delete(destiny);
                    }
                    File.Move(locaFile, destiny);
                }
            }
        }

        /// <summary>
        /// Cheks app images folder exists or creates it
        /// </summary>
        /// <param name="path"></param>
        public static void CheckApplicationImagesFolder(string path)
        {
            try
            {
                //Create applications images folder if it does no exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                throw;
            }
            catch (IOException ex)
            {
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
