using PdfSharp.Fonts;

namespace IntranetFM
{
    public class FileFontResolver : IFontResolver // FontResolverBase
    {
        public string DefaultFontName => throw new NotImplementedException();

        public byte[] GetFont(string pfaceName)
        {
            string mfaceName= Environment.CurrentDirectory + @"\wwwroot\"+pfaceName;

            using (var ms = new MemoryStream())
            {
                using (var fs = File.Open(mfaceName, FileMode.Open))
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    return ms.ToArray();
                }
            }
        }

        public FontResolverInfo ResolveTypeface( string familyName, bool isBold, bool isItalic)
        {



            if (familyName.Equals("VERDANA", StringComparison.CurrentCultureIgnoreCase))
            {
                if (isBold && isItalic)
                {
                    //return new FontResolverInfo("Fonts/Verdana-BoldItalic.ttf");
                    return new FontResolverInfo(@"Fonts\VERDANAZ.ttf");
                }
                else if (isBold)
                {
                    //return new FontResolverInfo("Fonts/Verdana-Bold.ttf");
                    return new FontResolverInfo(@"Fonts\VERDANAB.ttf");
                }
                else if (isItalic)
                {
                    //return new FontResolverInfo("Fonts/Verdana-Italic.ttf");
                    return new FontResolverInfo(@"Fonts\VERDANAI.ttf");
                }
                else
                {
                    //return new FontResolverInfo("Fonts/Verdana-Regular.ttf");
                    return new FontResolverInfo(@"Fonts\VERDANA.ttf");
                }
            }
            return null;
        }
    }
}
