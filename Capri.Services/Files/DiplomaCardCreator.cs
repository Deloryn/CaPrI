using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capri.Services.DiplomaCard;
using Capri.Web.ViewModels.Proposal;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace Capri.Services.Files
{
    public class DiplomaCardCreator : IDiplomaCardCreator
    {
        private readonly string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "src", "assets", "putLogo.jpg");

        private readonly IParagraphGetter _paragraphGetter;
        private readonly IDrawingGetter _drawingGetter;
        private readonly ITableGetter _tableGetter;

        public DiplomaCardCreator(
            IParagraphGetter paragraphGetter,
            IDrawingGetter drawingGetter,
            ITableGetter tableGetter)
        {
            _paragraphGetter = paragraphGetter;
            _drawingGetter = drawingGetter;
            _tableGetter = tableGetter;
        }

        public IServiceResult<MemoryStream> CreateDiplomaCard(ProposalDocRecord record)
        {
            using (MemoryStream mem = new MemoryStream())
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(mem, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    var image = _drawingGetter.getPutLogo(mainPart, imagePath);
                    body.AppendChild(new Paragraph(new Run(image)));

                    body.AppendChild(_paragraphGetter.getTitle(record));

                    body.AppendChild(new Paragraph(new Run(new Text(""))));
                    body.AppendChild(new Paragraph(new Run(new Text(""))));

                    body.AppendChild(_tableGetter.getTableWithUniversityInformation(record));

                    body.AppendChild(new Paragraph(new Run(new Text(""))));

                    body.AppendChild(_paragraphGetter.getClause());

                    body.AppendChild(_tableGetter.getTableWithStudentsInformation(record));

                    body.AppendChild(new Paragraph(new Run(new Text(""))));
                    body.AppendChild(new Paragraph(new Run(new Text(""))));

                    body.AppendChild(_tableGetter.getTableWithProposalInformation(record));

                    body.AppendChild(new Paragraph(new Run(new Text(""))));
                    body.AppendChild(new Paragraph(new Run(new Text(""))));

                    body.Append(_tableGetter.getTableWithSignature());

                    body.AppendChild(new Paragraph(new Run(new Text(""))));

                    body.Append(_tableGetter.getTableWithCity(record));

                    var sectionProp = new SectionProperties(
                        new PageSize() { Width = 11906, Height = 16838 },
                        new PageMargin() { Left = 1417, Gutter = 0, Footer = 708, Header = 708, Bottom = 709, Right = 1417, Top = 567 },
                        new Columns() { Space = "708" },
                        new DocGrid() { LinePitch = 360 }
                    );
                    body.Append(sectionProp);

                    wordDocument.Close();
                }

                return ServiceResult<MemoryStream>.Success(mem);
            }
        }

    }
}
