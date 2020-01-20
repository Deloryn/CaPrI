using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capri.Web.ViewModels.Proposal;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace Capri.Services.Files
{
    public class DiplomaCardCreator : IDiplomaCardCreator
    {
        private readonly string clause = "Zobowiązuję/zobowiązujemy się samodzielnie wykonać pracę w zakresie wyspecyfikowanym niżej." +
                " Wszystkie elementy (m.in. rysunki, tabele, cytaty, programy komputerowe, urządzenia itp.)," +
                " które zostaną wykorzystane w pracy, a nie będą mojego/naszego autorstwa będą w odpowiedni sposób" +
                " zaznaczone i będzie podane źródło ich pochodzenia.";
        private readonly string city = "Poznań";
        private readonly string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "src", "assets", "putLogo.jpg");

        public IServiceResult<MemoryStream> CreateDiplomaCard(ProposalDocRecord record)
        {
            

            using (MemoryStream mem = new MemoryStream())
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(mem, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());


                    var image = getPutLogo(mainPart, imagePath);
                    body.AppendChild(new Paragraph(new Run(image)));

                    body.AppendChild(getTitle(record));

                    body.AppendChild(new Paragraph(new Run(new Text(""))));
                    body.AppendChild(new Paragraph(new Run(new Text(""))));

                    body.AppendChild(getTableWithUniversityInformation(record));

                    body.AppendChild(new Paragraph(new Run(new Text(""))));

                    body.AppendChild(getClause());

                    body.AppendChild(getTableWithStudentsInformation(record));

                    body.AppendChild(new Paragraph(new Run(new Text(""))));
                    body.AppendChild(new Paragraph(new Run(new Text(""))));

                    body.AppendChild(getTableWithProposalInformation(record));

                    body.AppendChild(new Paragraph(new Run(new Text(""))));
                    body.AppendChild(new Paragraph(new Run(new Text(""))));

                    body.Append(getTableWithSignature());

                    body.AppendChild(new Paragraph(new Run(new Text(""))));

                    body.Append(getTableWithCity(record, city));

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

        private Paragraph getTitle(ProposalDocRecord record)
        {
            return new Paragraph(
                new ParagraphProperties(
                    new Indentation() { Left = "1985" }
                ),
                new Run(
                        new RunProperties(
                            new RunFonts() { ComplexScript = "Times New Roman", Ascii = "Times New Roman", HighAnsi = "Times New Roman" },
                            new FontSize() { Val = "24" }
                        ),
                        new Text("Tytuł"),
                        new Break(),
                        new Text("pracy dyplomowej " + (record.Level.ToLower().Contains("mag") ? "magisterskiej" : "inżynierskiej"))
                    )
            );
        }

        private Paragraph getClause()
        {
            return new Paragraph(
                new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Both }
                    ),
                new Run(
                    new RunProperties(
                        new RunFonts() { ComplexScript = "Times New Roman", Ascii = "Times New Roman", HighAnsi = "Times New Roman" },
                        new FontSize() { Val = "14" },
                        new FontSizeComplexScript() { Val = "14" }
                    ),
                    new Text(clause)
                )
            );
        }

        private Paragraph getNormalText(string text)
        {
            return new Paragraph(
                new ParagraphProperties(
                    new SpacingBetweenLines() { After = "0", LineRule = new EnumValue<LineSpacingRuleValues>(LineSpacingRuleValues.Auto), Line = "240" }
                ),
                new Run(
                    new RunProperties(
                        new RunFonts() { ComplexScript = "Times New Roman", Ascii = "Times New Roman", HighAnsi = "Times New Roman" },
                        new FontSize() { Val = "18" },
                        new FontSizeComplexScript() { Val = "18" }
                    ),
                    new Text(text)
                )
            );
        }

        private Paragraph getNormalRightText(string text)
        {
            return new Paragraph(
                new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Right },
                    new SpacingBetweenLines() { After = "0", LineRule = new EnumValue<LineSpacingRuleValues>(LineSpacingRuleValues.Auto), Line = "240" }
                ),
                new Run(
                    new RunProperties(
                        new RunFonts() { ComplexScript = "Times New Roman", Ascii = "Times New Roman", HighAnsi = "Times New Roman" },
                        new FontSize() { Val = "18" },
                        new FontSizeComplexScript() { Val = "18" }
                    ),
                    new Text(text)
                )
            );
        }

        private Paragraph getSmallCenteredText(string text)
        {
            return new Paragraph(
                new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Center },
                    new SpacingBetweenLines() { After = "0" }
                ),
                new Run(
                    new RunProperties(
                        new RunFonts() { ComplexScript = "Times New Roman", Ascii = "Times New Roman", HighAnsi = "Times New Roman" },
                        new FontSize() { Val = "14" },
                        new FontSizeComplexScript() { Val = "14" }
                    ),
                    new Text(text)
                )
            );
        }

        private TableCellProperties getTableCellPropBorderless(string width)
        {
            return new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = width },
                new TableCellBorders(
                    new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) },
                    new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) }
            ));
        }

        private TableCellProperties getTableCellPropFilled(string width, string color)
        {
            return new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = width },
                new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center },
                new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = color },
                new TableCellBorders(new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) })
            );
        }

        private TableCellProperties getTableCellPropCentered(string width)
        {
            return new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = width },
                new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center },
                new TableCellBorders(new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) })
            );
        }

        private Drawing getPutLogo(MainDocumentPart mainPart, string imagePath)
        {
            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Png);
            using (FileStream stream = new FileStream(imagePath, FileMode.Open))
            {
                imagePart.FeedData(stream);
            }

            var image = new Drawing(
                 new DW.Anchor(
                     new DW.SimplePosition() { X = 0L, Y = 0L },
                     new DW.HorizontalPosition( new DW.PositionOffset("18415") ) { RelativeFrom = DW.HorizontalRelativePositionValues.Column },
                     new DW.VerticalPosition( new DW.PositionOffset("-635") ) { RelativeFrom = DW.VerticalRelativePositionValues.Paragraph },
                     new DW.Extent() { Cx = 880110L, Cy = 880110L },
                     new DW.EffectExtent()
                     {
                         LeftEdge = 19050L,
                         TopEdge = 0L,
                         RightEdge = 0L,
                         BottomEdge = 0L
                     },
                     new DW.WrapSquare() { WrapText = DW.WrapTextValues.BothSides },
                     new DW.DocProperties()
                     {
                         Id = (UInt32Value)1U,
                         Name = "PUT_Logo"
                     },
                     new DW.NonVisualGraphicFrameDrawingProperties(
                         new A.GraphicFrameLocks() { NoChangeAspect = true }),
                     new A.Graphic(
                         new A.GraphicData(
                             new PIC.Picture(
                                 new PIC.NonVisualPictureProperties(
                                     new PIC.NonVisualDrawingProperties()
                                     {
                                         Id = (UInt32Value)0U,
                                         Name = "PUT_Logo.jpg"
                                     },
                                     new PIC.NonVisualPictureDrawingProperties()),
                                 new PIC.BlipFill(
                                     new A.Blip()
                                     {
                                         Embed = mainPart.GetIdOfPart(imagePart),
                                         CompressionState = A.BlipCompressionValues.Print
                                     },
                                     new A.Stretch(new A.FillRectangle())),
                                 new PIC.ShapeProperties(
                                     new A.Transform2D(
                                         new A.Offset() { X = 0L, Y = 0L },
                                         new A.Extents() { Cx = 880110L, Cy = 880110L }),
                                     new A.PresetGeometry(
                                         new A.AdjustValueList()
                                     )
                                     { Preset = A.ShapeTypeValues.Rectangle }))
                         )
                         { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                 )
                 {
                     DistanceFromTop = (UInt32Value)0U,
                     DistanceFromBottom = (UInt32Value)0U,
                     DistanceFromLeft = (UInt32Value)114300U,
                     DistanceFromRight = (UInt32Value)114300U,
                     AllowOverlap = new BooleanValue(true),
                     LayoutInCell = new BooleanValue(true),
                     Locked = new BooleanValue(false),
                     BehindDoc = new BooleanValue(false),
                     RelativeHeight = (UInt32Value)251658240U,
                     SimplePos = new BooleanValue(false)
                 });

            return image;
        }

        private Table getTableWithUniversityInformation(ProposalDocRecord record)
        {
            Table universityTable = new Table();
            TableProperties universityTableProperties = new TableProperties(
                new TableBorders(
                    new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 },
                    new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 },
                    new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 }
                ),
                new TableCellMarginDefault(
                    new LeftMargin() { Type = TableWidthUnitValues.Dxa, Width = "30" },
                    new RightMargin() { Type = TableWidthUnitValues.Dxa, Width = "30" }),
                new TableLayout() { Type = new EnumValue<TableLayoutValues>(TableLayoutValues.Fixed) }
            );
            universityTable.AppendChild<TableProperties>(universityTableProperties);

            TableRow uniTableRow1 = new TableRow();
            uniTableRow1.Append(new TableRowProperties(new TableRowHeight() { HeightType = HeightRuleValues.Exact, Val = 160 }));
            TableCell uniTableCell11 = new TableCell();
            uniTableCell11.Append(getTableCellPropFilled("1842", "000000"));
            uniTableCell11.Append(getNormalText(""));
            TableCell uniTableCell12 = new TableCell();
            uniTableCell12.Append(getTableCellPropFilled("2661", "CCCCCC"));
            uniTableCell12.Append(getNormalText(""));
            TableCell uniTableCell13 = new TableCell();
            uniTableCell13.Append(getTableCellPropBorderless("283"));
            uniTableCell13.Append(getNormalText(""));
            TableCell uniTableCell14 = new TableCell();
            uniTableCell14.Append(getTableCellPropFilled("1559", "000000"));
            uniTableCell14.Append(getNormalText(""));
            TableCell uniTableCell15 = new TableCell();
            uniTableCell15.Append(getTableCellPropFilled("2835", "CCCCCC"));
            uniTableCell15.Append(getNormalText(""));
            uniTableRow1.Append(uniTableCell11, uniTableCell12, uniTableCell13, uniTableCell14, uniTableCell15);


            TableRow uniTableRow2 = new TableRow();
            uniTableRow2.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell uniTableCell21 = new TableCell();
            uniTableCell21.Append(getTableCellPropCentered("1842"));
            uniTableCell21.Append(getNormalRightText("Uczelnia:"));
            TableCell uniTableCell22 = new TableCell();
            uniTableCell22.Append(getTableCellPropCentered("2661"));
            uniTableCell22.Append(getNormalText(record.College));
            TableCell uniTableCell23 = new TableCell();
            uniTableCell23.Append(getTableCellPropBorderless("283"));
            uniTableCell23.Append(getNormalText(""));
            TableCell uniTableCell24 = new TableCell();
            uniTableCell24.Append(getTableCellPropCentered("1559"));
            uniTableCell24.Append(getNormalRightText("Profil kształcenia:"));
            TableCell uniTableCell25 = new TableCell();
            uniTableCell25.Append(getTableCellPropCentered("2835"));
            uniTableCell25.Append(getNormalText(record.StudyProfile));
            uniTableRow2.Append(uniTableCell21, uniTableCell22, uniTableCell23, uniTableCell24, uniTableCell25);

            TableRow uniTableRow3 = new TableRow();
            uniTableRow3.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell uniTableCell31 = new TableCell();
            uniTableCell31.Append(getTableCellPropCentered("1842"));
            uniTableCell31.Append(getNormalRightText("Wydział:"));
            TableCell uniTableCell32 = new TableCell();
            uniTableCell32.Append(getTableCellPropCentered("2661"));
            uniTableCell32.Append(getNormalText(record.Faculty));
            TableCell uniTableCell33 = new TableCell();
            uniTableCell33.Append(getTableCellPropBorderless("283"));
            uniTableCell33.Append(getNormalText(""));
            TableCell uniTableCell34 = new TableCell();
            uniTableCell34.Append(getTableCellPropCentered("1559"));
            uniTableCell34.Append(getNormalRightText("Forma studiów:"));
            TableCell uniTableCell35 = new TableCell();
            uniTableCell35.Append(getTableCellPropCentered("2835"));
            uniTableCell35.Append(getNormalText(record.Mode));
            uniTableRow3.Append(uniTableCell31, uniTableCell32, uniTableCell33, uniTableCell34, uniTableCell35);

            TableRow uniTableRow4 = new TableRow();
            uniTableRow4.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell uniTableCell41 = new TableCell();
            uniTableCell41.Append(getTableCellPropCentered("1842"));
            uniTableCell41.Append(getNormalRightText("Kierunek:"));
            TableCell uniTableCell42 = new TableCell();
            uniTableCell42.Append(getTableCellPropCentered("2661"));
            uniTableCell42.Append(getNormalText(record.Course));
            TableCell uniTableCell43 = new TableCell();
            uniTableCell43.Append(getTableCellPropBorderless("283"));
            uniTableCell43.Append(getNormalText(""));
            TableCell uniTableCell44 = new TableCell();
            uniTableCell44.Append(getTableCellPropCentered("1559"));
            uniTableCell44.Append(getNormalRightText("Poziom studiów:"));
            TableCell uniTableCell45 = new TableCell();
            uniTableCell45.Append(getTableCellPropCentered("2835"));
            uniTableCell45.Append(getNormalText(record.Level));
            uniTableRow4.Append(uniTableCell41, uniTableCell42, uniTableCell43, uniTableCell44, uniTableCell45);

            TableRow uniTableRow5 = new TableRow();
            uniTableRow5.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell uniTableCell51 = new TableCell();
            uniTableCell51.Append(getTableCellPropCentered("1842"));
            uniTableCell51.Append(getNormalRightText("Specjalność:"));
            TableCell uniTableCell52 = new TableCell();
            uniTableCell52.Append(getTableCellPropCentered("2661"));
            uniTableCell52.Append(getNormalText(record.Specialization));
            TableCell uniTableCell53 = new TableCell();
            uniTableCell53.Append(getTableCellPropBorderless("283"));
            uniTableCell53.Append(getNormalText(""));
            TableCell uniTableCell54 = new TableCell();
            uniTableCell54.Append(getTableCellPropCentered("1559"));
            uniTableCell54.Append(getNormalText(""));
            TableCell uniTableCell55 = new TableCell();
            uniTableCell55.Append(getTableCellPropCentered("2835"));
            uniTableCell55.Append(getNormalText(""));
            uniTableRow5.Append(uniTableCell51, uniTableCell52, uniTableCell53, uniTableCell54, uniTableCell55);

            universityTable.Append(uniTableRow1, uniTableRow2, uniTableRow3, uniTableRow4, uniTableRow5);

            return universityTable;
        }

        private Table getTableWithStudentsInformation(ProposalDocRecord record)
        {
            Table studentsTable = new Table();
            TableProperties studentsTableProperties = new TableProperties(
                new TableBorders(
                    new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 },
                    new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 },
                    new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 }
                ),
                new TableCellMarginDefault(
                    new LeftMargin() { Type = TableWidthUnitValues.Dxa, Width = "30" },
                    new RightMargin() { Type = TableWidthUnitValues.Dxa, Width = "30" }),
                new TableLayout() { Type = new EnumValue<TableLayoutValues>(TableLayoutValues.Fixed) }
            );
            studentsTable.AppendChild<TableProperties>(studentsTableProperties);

            TableRow stdTableRow1 = new TableRow();
            stdTableRow1.Append(new TableRowProperties(new TableRowHeight() { HeightType = HeightRuleValues.Exact, Val = 160 }));
            TableCell stdTableCell11 = new TableCell();
            stdTableCell11.Append(getTableCellPropFilled("1842", "000000"));
            stdTableCell11.Append(getSmallCenteredText(""));
            TableCell stdTableCell12 = new TableCell();
            stdTableCell12.Append(getTableCellPropFilled("3511", "CCCCCC"));
            stdTableCell12.Append(getSmallCenteredText("Imię i nazwisko"));
            TableCell stdTableCell13 = new TableCell();
            stdTableCell13.Append(getTableCellPropFilled("1475", "CCCCCC"));
            stdTableCell13.Append(getSmallCenteredText("Nr albumu"));
            TableCell stdTableCell14 = new TableCell();
            stdTableCell14.Append(getTableCellPropFilled("2351", "CCCCCC"));
            stdTableCell14.Append(getSmallCenteredText("Data i podpis"));
            stdTableRow1.Append(stdTableCell11, stdTableCell12, stdTableCell13, stdTableCell14);

            var students = record.Students.GetEnumerator();
            TableRow stdTableRow2 = new TableRow();
            stdTableRow2.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell stdTableCell21 = new TableCell();
            stdTableCell21.Append(getTableCellPropCentered("1842"));
            stdTableCell21.Append(getNormalRightText("Student:"));
            TableCell stdTableCell22 = new TableCell();
            stdTableCell22.Append(getTableCellPropCentered("3511"));
            stdTableCell22.Append(getNormalText(students.MoveNext() ? students.Current.Id.ToString() : ""));
            TableCell stdTableCell23 = new TableCell();
            stdTableCell23.Append(getTableCellPropCentered("1475"));
            stdTableCell23.Append(getNormalText(""));
            TableCell stdTableCell24 = new TableCell();
            stdTableCell24.Append(getTableCellPropCentered("2351"));
            stdTableCell24.Append(getNormalText(""));
            stdTableRow2.Append(stdTableCell21, stdTableCell22, stdTableCell23, stdTableCell24);

            TableRow stdTableRow3 = new TableRow();
            stdTableRow3.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell stdTableCell31 = new TableCell();
            stdTableCell31.Append(getTableCellPropCentered("1842"));
            stdTableCell31.Append(getNormalRightText("Student:"));
            TableCell stdTableCell32 = new TableCell();
            stdTableCell32.Append(getTableCellPropCentered("3511"));
            stdTableCell32.Append(getNormalText(students.MoveNext() ? students.Current.Id.ToString() : ""));
            TableCell stdTableCell33 = new TableCell();
            stdTableCell33.Append(getTableCellPropCentered("1475"));
            stdTableCell33.Append(getNormalText(""));
            TableCell stdTableCell34 = new TableCell();
            stdTableCell34.Append(getTableCellPropCentered("2351"));
            stdTableCell34.Append(getNormalText(""));
            stdTableRow3.Append(stdTableCell31, stdTableCell32, stdTableCell33, stdTableCell34);

            TableRow stdTableRow4 = new TableRow();
            stdTableRow4.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell stdTableCell41 = new TableCell();
            stdTableCell41.Append(getTableCellPropCentered("1842"));
            stdTableCell41.Append(getNormalRightText("Student:"));
            TableCell stdTableCell42 = new TableCell();
            stdTableCell42.Append(getTableCellPropCentered("3511"));
            stdTableCell42.Append(getNormalText(students.MoveNext() ? students.Current.Id.ToString() : ""));
            TableCell stdTableCell43 = new TableCell();
            stdTableCell43.Append(getTableCellPropCentered("1475"));
            stdTableCell43.Append(getNormalText(""));
            TableCell stdTableCell44 = new TableCell();
            stdTableCell44.Append(getTableCellPropCentered("2351"));
            stdTableCell44.Append(getNormalText(""));
            stdTableRow4.Append(stdTableCell41, stdTableCell42, stdTableCell43, stdTableCell44);

            TableRow stdTableRow5 = new TableRow();
            stdTableRow5.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell stdTableCell51 = new TableCell();
            stdTableCell51.Append(getTableCellPropCentered("1842"));
            stdTableCell51.Append(getNormalRightText("Student:"));
            TableCell stdTableCell52 = new TableCell();
            stdTableCell52.Append(getTableCellPropCentered("3511"));
            stdTableCell52.Append(getNormalText(students.MoveNext() ? students.Current.Id.ToString() : ""));
            TableCell stdTableCell53 = new TableCell();
            stdTableCell53.Append(getTableCellPropCentered("1475"));
            stdTableCell53.Append(getNormalText(""));
            TableCell stdTableCell54 = new TableCell();
            stdTableCell54.Append(getTableCellPropCentered("2351"));
            stdTableCell54.Append(getNormalText(""));
            stdTableRow5.Append(stdTableCell51, stdTableCell52, stdTableCell53, stdTableCell54);

            studentsTable.Append(stdTableRow1, stdTableRow2, stdTableRow3, stdTableRow4, stdTableRow5);

            return studentsTable;
        }

        private Table getTableWithProposalInformation(ProposalDocRecord record)
        {
            Table diplomaTable = new Table();
            TableProperties diplomaTableProperties = new TableProperties(
                new TableBorders(
                    new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 },
                    new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 },
                    new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 },
                    new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Space = 0, Size = 0 }
                ),
                new TableCellMarginDefault(
                    new LeftMargin() { Type = TableWidthUnitValues.Dxa, Width = "30" },
                    new RightMargin() { Type = TableWidthUnitValues.Dxa, Width = "30" }),
                new TableLayout() { Type = new EnumValue<TableLayoutValues>(TableLayoutValues.Fixed) }
            );
            diplomaTable.AppendChild<TableProperties>(diplomaTableProperties);

            TableRow dipTableRow1 = new TableRow();
            dipTableRow1.Append(new TableRowProperties(new TableRowHeight() { HeightType = HeightRuleValues.Exact, Val = 160 }));
            TableCell dipTableCell11 = new TableCell();
            dipTableCell11.Append(getTableCellPropFilled("1842", "000000"));
            dipTableCell11.Append(getSmallCenteredText(""));
            TableCell dipTableCell12 = new TableCell();
            dipTableCell12.Append(getTableCellPropFilled("534", "CCCCCC"));
            dipTableCell12.Append(getSmallCenteredText(""));
            TableCell dipTableCell13 = new TableCell();
            dipTableCell13.Append(getTableCellPropFilled("6804", "CCCCCC"));
            dipTableCell13.Append(getSmallCenteredText(""));
            dipTableRow1.Append(dipTableCell11, dipTableCell12, dipTableCell13);


            TableRow dipTableRow2 = new TableRow();
            dipTableRow2.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell dipTableCell21 = new TableCell();
            dipTableCell21.Append(getTableCellPropCentered("1842"));
            dipTableCell21.Append(getNormalRightText("Tytuł pracy:"));
            TableCell dipTableCell22 = new TableCell();
            dipTableCell22.Append(getTableCellPropCentered("534"));
            dipTableCell22.Append(getNormalText(""));
            TableCell dipTableCell23 = new TableCell();
            dipTableCell23.Append(getTableCellPropCentered("6804"));
            dipTableCell23.Append(getNormalText(record.TopicPolish));
            dipTableRow2.Append(dipTableCell21, dipTableCell22, dipTableCell23);

            TableRow dipTableRow3 = new TableRow();
            dipTableRow3.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell dipTableCell31 = new TableCell();
            dipTableCell31.Append(getTableCellPropCentered("1842"));
            dipTableCell31.Append(getNormalRightText("Wersja angielska \n tytułu:"));
            TableCell dipTableCell32 = new TableCell();
            dipTableCell32.Append(getTableCellPropCentered("534"));
            dipTableCell32.Append(getNormalText(""));
            TableCell dipTableCell33 = new TableCell();
            dipTableCell33.Append(getTableCellPropCentered("6804"));
            dipTableCell33.Append(getNormalText(record.TopicEnglish));
            dipTableRow3.Append(dipTableCell31, dipTableCell32, dipTableCell33);

            TableRow dipTableRow4 = new TableRow();
            dipTableRow4.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell dipTableCell41 = new TableCell();
            dipTableCell41.Append(getTableCellPropCentered("1842"));
            dipTableCell41.Append(getNormalRightText("Dane wyjściowe:"));
            TableCell dipTableCell42 = new TableCell();
            dipTableCell42.Append(getTableCellPropCentered("534"));
            dipTableCell42.Append(getNormalText(""));
            TableCell dipTableCell43 = new TableCell();
            dipTableCell43.Append(getTableCellPropCentered("6804"));
            dipTableCell43.Append(getNormalText(record.OutputData));
            dipTableRow4.Append(dipTableCell41, dipTableCell42, dipTableCell43);

            TableRow dipTableRow5 = new TableRow();
            dipTableRow5.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell dipTableCell51 = new TableCell();
            dipTableCell51.Append(getTableCellPropCentered("1842"));
            dipTableCell51.Append(getNormalRightText("Zakres pracy:"));
            TableCell dipTableCell52 = new TableCell();
            dipTableCell52.Append(getTableCellPropCentered("534"));
            dipTableCell52.Append(getNormalText(""));
            TableCell dipTableCell53 = new TableCell();
            dipTableCell53.Append(getTableCellPropCentered("6804"));
            dipTableCell53.Append(getNormalText(record.Description));
            dipTableRow5.Append(dipTableCell51, dipTableCell52, dipTableCell53);

            TableRow dipTableRow6 = new TableRow();
            dipTableRow6.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell dipTableCell61 = new TableCell();
            dipTableCell61.Append(getTableCellPropCentered("1842"));
            dipTableCell61.Append(getNormalRightText("Termin oddania pracy:"));
            TableCell dipTableCell62 = new TableCell();
            dipTableCell62.Append(getTableCellPropCentered("534"));
            dipTableCell62.Append(getNormalText(""));
            TableCell dipTableCell63 = new TableCell();
            dipTableCell63.Append(getTableCellPropCentered("6804"));
            dipTableCell63.Append(getNormalText(""));
            dipTableRow6.Append(dipTableCell61, dipTableCell62, dipTableCell63);

            TableRow dipTableRow7 = new TableRow();
            dipTableRow7.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell dipTableCell71 = new TableCell();
            dipTableCell71.Append(getTableCellPropCentered("1842"));
            dipTableCell71.Append(getNormalRightText("Promotor:"));
            TableCell dipTableCell72 = new TableCell();
            dipTableCell72.Append(getTableCellPropCentered("534"));
            dipTableCell72.Append(getNormalText(""));
            TableCell dipTableCell73 = new TableCell();
            dipTableCell73.Append(getTableCellPropCentered("6804"));
            dipTableCell73.Append(getNormalText(record.Promoter));
            dipTableRow7.Append(dipTableCell71, dipTableCell72, dipTableCell73);

            TableRow dipTableRow8 = new TableRow();
            dipTableRow8.Append(new TableRowProperties(new TableRowHeight() { Val = 280 }));
            TableCell dipTableCell81 = new TableCell();
            dipTableCell81.Append(getTableCellPropCentered("1842"));
            dipTableCell81.Append(getNormalRightText("Jednostka \n organizacyjna \n promotora:"));
            TableCell dipTableCell82 = new TableCell();
            dipTableCell82.Append(getTableCellPropCentered("534"));
            dipTableCell82.Append(getNormalText(""));
            TableCell dipTableCell83 = new TableCell();
            dipTableCell83.Append(getTableCellPropCentered("6804"));
            dipTableCell83.Append(getNormalText(record.Institute));
            dipTableRow8.Append(dipTableCell81, dipTableCell82, dipTableCell83);

            diplomaTable.Append(dipTableRow1, dipTableRow2, dipTableRow3, dipTableRow4, dipTableRow5, dipTableRow6, dipTableRow7, dipTableRow8);

            return diplomaTable;
        }

        private Table getTableWithSignature()
        {
            Table signatureTable = new Table();
            TableProperties signatureTableProperties = new TableProperties(
                new TableBorders(
                    new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 }
                ),
                new TableJustification() { Val = TableRowAlignmentValues.Right },
                new TableLayout() { Type = new EnumValue<TableLayoutValues>(TableLayoutValues.Fixed) }
            );
            signatureTable.AppendChild<TableProperties>(signatureTableProperties);

            TableRow sigTableRow1 = new TableRow();
            sigTableRow1.Append(new TableRowProperties(new TableRowHeight() { Val = 255 }));
            TableCell sigTableCell11 = new TableCell();
            sigTableCell11.Append(getTableCellPropCentered("3969"));
            sigTableCell11.Append(getSmallCenteredText(""));
            TableCell sigTableCell12 = new TableCell();
            sigTableCell12.AppendChild<TableCellProperties>(new TableCellProperties(new TableCellBorders(new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) })));
            sigTableCell12.Append(getTableCellPropCentered("425"));
            sigTableCell12.Append(getSmallCenteredText(""));
            TableCell sigTableCell13 = new TableCell();
            sigTableCell13.Append(getTableCellPropCentered("3260"));
            sigTableCell13.Append(getSmallCenteredText(""));
            sigTableRow1.Append(sigTableCell11, sigTableCell12, sigTableCell13);


            TableRow sigTableRow2 = new TableRow();
            sigTableRow2.Append(new TableRowProperties(new TableRowHeight() { Val = 255 }));
            TableCell sigTableCell21 = new TableCell();
            sigTableCell21.Append(getTableCellPropCentered("3969"));
            sigTableCell21.Append(getSmallCenteredText("podpis dyrektora/kierownika jednostki organizacyjnej promotora"));
            TableCell sigTableCell22 = new TableCell();
            sigTableCell22.AppendChild<TableCellProperties>(new TableCellProperties(new TableCellBorders(new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) })));
            sigTableCell22.Append(getTableCellPropCentered("425"));
            sigTableCell22.Append(getSmallCenteredText(""));
            TableCell sigTableCell23 = new TableCell();
            sigTableCell23.Append(getTableCellPropCentered("3260"));
            sigTableCell23.Append(getSmallCenteredText("podpis Dziekana"));
            sigTableRow2.Append(sigTableCell21, sigTableCell22, sigTableCell23);

            signatureTable.Append(sigTableRow1, sigTableRow2);

            return signatureTable;
        }

        private Table getTableWithCity(ProposalDocRecord record, string city)
        {
            Table dataTable = new Table();
            TableProperties dataTableProperties = new TableProperties(
                new TableBorders(
                    new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Space = 0, Size = 4 }
                ),
                new TableJustification() { Val = TableRowAlignmentValues.Right },
                new TableLayout() { Type = new EnumValue<TableLayoutValues>(TableLayoutValues.Fixed) }
            );
            dataTable.AppendChild<TableProperties>(dataTableProperties);

            TableRow dataTableRow1 = new TableRow();
            dataTableRow1.Append(new TableRowProperties(new TableRowHeight() { Val = 255 }));
            TableCell dataTableCell11 = new TableCell();
            dataTableCell11.Append(getTableCellPropCentered("3260"));
            dataTableCell11.Append(getSmallCenteredText($"{city}, {record.StartingDate.ToString("yyyy'-'MM'-'dd")}"));
            dataTableRow1.Append(dataTableCell11);


            TableRow dataTableRow2 = new TableRow();
            dataTableRow2.Append(new TableRowProperties(new TableRowHeight() { Val = 255 }));
            TableCell dataTableCell21 = new TableCell();
            dataTableCell21.Append(getTableCellPropCentered("3260"));
            dataTableCell21.Append(getSmallCenteredText("miejscowość, data"));
            dataTableRow2.Append(dataTableCell21);

            dataTable.Append(dataTableRow1, dataTableRow2);

            return dataTable;
        }

    }
}
