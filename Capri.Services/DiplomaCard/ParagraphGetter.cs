using Capri.Web.ViewModels.Proposal;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Localization;

namespace Capri.Services.DiplomaCard
{
    public class ParagraphGetter: IParagraphGetter
    {
        private readonly IStringLocalizer<ParagraphGetter> _localizer;

        public ParagraphGetter(IStringLocalizer<ParagraphGetter> localizer)
        {
            _localizer = localizer;
        }

        public Paragraph getTitle(ProposalDocRecord record)
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
                        new Text(_localizer["Tytuł"]),
                        new Break(),
                        new Text(_localizer["pracy dyplomowej"] + " " + 
                            (record.Level.ToLower().Contains("mag") ? _localizer["magisterskiej"] : _localizer["inżynierskiej"]))
                    )
            );
        }

        public Paragraph getClause()
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
                    new Text(_localizer["klauzula"])
                )
            );
        }

        public Paragraph getNormalText(string text)
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

        public Paragraph getNormalRightText(string text)
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

        public Paragraph getItalicText(string text)
        {
            return new Paragraph(
                new ParagraphProperties(
                    new SpacingBetweenLines() { After = "0", LineRule = new EnumValue<LineSpacingRuleValues>(LineSpacingRuleValues.Auto), Line = "240" }
                ),
                new Run(
                    new RunProperties(
                        new RunFonts() { ComplexScript = "Times New Roman", Ascii = "Times New Roman", HighAnsi = "Times New Roman" },
                        new FontSize() { Val = "18" },
                        new FontSizeComplexScript() { Val = "18" },
                        new Italic() { Val = new OnOffValue(true) }
                    ),
                    new Text(text)
                )
            );
        }

        public Paragraph getSmallCenteredText(string text)
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
    }
}
