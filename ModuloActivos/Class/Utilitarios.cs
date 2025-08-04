using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Text;

namespace IntranetFM
{
    public static class Utilitarios
    {
        public static string BuscarConfigLine(string Param)
        {
            string fmypath = Environment.CurrentDirectory + "/wwwroot/Config/App.config";
            string mvalor = "";
            string line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fmypath);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    if (line != "")
                    {
                        if (line.Substring(0, 1) == "[")
                        {
                            if (line.Substring(0, 8) == "[" + Param + "]")
                            {
                                mvalor = line.Substring(9);
                                line = null;
                            }
                        }
                    }
                    //write the line to console window
                    //Console.WriteLine(line);
                    //Read the next line
                    if (mvalor == "")
                    {
                        line = sr.ReadLine();
                    }
                }
                //close the file
                sr.Close();
                //Console.ReadLine();
            }

            catch (Exception e)
            {

                //Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
            }

            return mvalor;
        }

        public static string ContenidodeArchivo(string pfilepath,System.Text.Encoding pEncodeType=null)
        {
            string mfileContents = "";

            if (File.Exists(pfilepath))
            {
                if (pEncodeType == null) { mfileContents = System.IO.File.ReadAllText(pfilepath); }
                else { mfileContents = System.IO.File.ReadAllText(pfilepath, pEncodeType); }
            }
            else
            {
                mfileContents = "";
            }
            return mfileContents;
        }

        public static bool WriteLog(IntranetFM.Modelos.ApplicationLog plog, HttpContext _httpcontext = null)
        {

            //            string mlogpath = Environment.CurrentDirectory + "/Library/App.log";

            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            if (plog._ipaddress == "")
            {
                if (_httpcontext != null)
                {
                    plog._ipaddress = Utilitarios.GetIPAddress(_httpcontext);
                }
            }

            string mlogpath = Utilitarios.BuscarConfigLine("LOGFLE") + "Log_" + DateTime.Now.ToString("MM") + ".log";

            using (StreamWriter outputFile = new StreamWriter(mlogpath, true))
            {
                outputFile.Write(plog._date.ToString() + "|" + plog._ipaddress + "|" + plog._user + "|" + plog._action + "\r");
            }
            return true;
        }

        internal static string GetIPAddress(HttpContext _httpcontext)
        {
            return _httpcontext.Connection.RemoteIpAddress.ToString();
        }


    }

    public class LayoutHelper
    {
        private readonly PdfDocument _document;
        private readonly XUnit _topPosition;
        private readonly XUnit _bottomMargin;
        private XUnit _currentPosition;
        private PageOrientation _PageOrientation;
        public LayoutHelper(PdfDocument document, XUnit topPosition, XUnit bottomMargin,PageOrientation pPageOrientation= PageOrientation.Portrait)
        {
            _document = document;
            _topPosition = topPosition;
            _bottomMargin = bottomMargin;
            // Set a value outside the page - a new page will be created on the first request.
            _currentPosition = bottomMargin + 10000;
            _PageOrientation = pPageOrientation;
        }

        public XUnit GetLinePosition(XUnit requestedHeight)
        {
            return GetLinePosition(requestedHeight, -1f);
        }

        public XUnit GetLinePosition(XUnit requestedHeight, XUnit requiredHeight)
        {
            XUnit required = requiredHeight == -1f ? requestedHeight : requiredHeight;
            if (_currentPosition + required > _bottomMargin)
                CreatePage();
            XUnit result = _currentPosition;
            _currentPosition += requestedHeight;
            return result;
        }

        public XGraphics Gfx { get; private set; }
        public PdfPage Page { get; private set; }

        void CreatePage()
        {
            Page = _document.AddPage();
            Page.Orientation = _PageOrientation;
            Page.Size = PageSize.Letter;
            Gfx = XGraphics.FromPdfPage(Page);
            _currentPosition = _topPosition;
        }
    }

}
