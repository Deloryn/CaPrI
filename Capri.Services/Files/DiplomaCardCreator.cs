using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Capri.Services.Files
{
    public class DiplomaCardCreator: IDiplomaCardCreator
    {
        public IServiceResult<MemoryStream> CreateDiplomaCard()
        {
            using (MemoryStream mem = new MemoryStream())
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(mem, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());

                    run.AppendChild(new Text("Hello world!"));

                    wordDocument.Close();

                    
                }
                return ServiceResult<MemoryStream>.Success(mem);
            }
        }
    }
}
