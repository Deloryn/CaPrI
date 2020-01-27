using Capri.Web.ViewModels.Proposal;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Capri.Services.Settings;

namespace Capri.Services.DiplomaCard
{
    public class TableGetter: ITableGetter
    {
        private readonly ITablePropertiesGetter _tablePropertiesGetter;
        private readonly IParagraphGetter _paragraphGetter;
        private readonly ISystemSettingsGetter _systemSettingsGetter;
        private readonly IStringLocalizer<TableGetter> _localizer;

        public TableGetter(
            ITablePropertiesGetter tablePropertiesGetter,
            IParagraphGetter paragraphGetter,
            ISystemSettingsGetter systemSettingsGetter,
            IStringLocalizer<TableGetter> localizer)
        {
            _tablePropertiesGetter = tablePropertiesGetter;
            _paragraphGetter = paragraphGetter;
            _systemSettingsGetter = systemSettingsGetter;
            _localizer = localizer;
        }

        public Table getTableWithUniversityInformation(ProposalDocRecord record)
        {
            Table universityTable = new Table();
            universityTable.AppendChild<TableProperties>(_tablePropertiesGetter.getHorizontalBorderTableProperties());

            TableRow uniTableRow1 = new TableRow();
            uniTableRow1.Append(new TableRowProperties(new TableRowHeight() { HeightType = HeightRuleValues.Exact, Val = 180 }));
            TableCell uniTableCell11 = new TableCell();
            uniTableCell11.Append(_tablePropertiesGetter.getTableCellPropFilled("1559", "000000"));
            uniTableCell11.Append(_paragraphGetter.getNormalText(""));
            TableCell uniTableCell12 = new TableCell();
            uniTableCell12.Append(_tablePropertiesGetter.getTableCellPropFilled("2802", "CCCCCC"));
            uniTableCell12.Append(_paragraphGetter.getNormalText(""));
            TableCell uniTableCell13 = new TableCell();
            uniTableCell13.Append(_tablePropertiesGetter.getTableCellPropBorderless("283"));
            uniTableCell13.Append(_paragraphGetter.getNormalText(""));
            TableCell uniTableCell14 = new TableCell();
            uniTableCell14.Append(_tablePropertiesGetter.getTableCellPropFilled("1559", "000000"));
            uniTableCell14.Append(_paragraphGetter.getNormalText(""));
            TableCell uniTableCell15 = new TableCell();
            uniTableCell15.Append(_tablePropertiesGetter.getTableCellPropFilled("2977", "CCCCCC"));
            uniTableCell15.Append(_paragraphGetter.getNormalText(""));
            uniTableRow1.Append(uniTableCell11, uniTableCell12, uniTableCell13, uniTableCell14, uniTableCell15);


            TableRow uniTableRow2 = new TableRow();
            uniTableRow2.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell uniTableCell21 = new TableCell();
            uniTableCell21.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            uniTableCell21.Append(_paragraphGetter.getNormalRightText(_localizer["Uczelnia:"]));
            TableCell uniTableCell22 = new TableCell();
            uniTableCell22.Append(_tablePropertiesGetter.getTableCellPropCentered("2802"));
            uniTableCell22.Append(_paragraphGetter.getNormalText(record.College));
            TableCell uniTableCell23 = new TableCell();
            uniTableCell23.Append(_tablePropertiesGetter.getTableCellPropBorderless("283"));
            uniTableCell23.Append(_paragraphGetter.getNormalText(""));
            TableCell uniTableCell24 = new TableCell();
            uniTableCell24.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            uniTableCell24.Append(_paragraphGetter.getNormalRightText(_localizer["Profil kształcenia:"]));
            TableCell uniTableCell25 = new TableCell();
            uniTableCell25.Append(_tablePropertiesGetter.getTableCellPropCentered("2977"));
            uniTableCell25.Append(_paragraphGetter.getNormalText(record.StudyProfile));
            uniTableRow2.Append(uniTableCell21, uniTableCell22, uniTableCell23, uniTableCell24, uniTableCell25);

            TableRow uniTableRow3 = new TableRow();
            uniTableRow3.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell uniTableCell31 = new TableCell();
            uniTableCell31.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            uniTableCell31.Append(_paragraphGetter.getNormalRightText(_localizer["Wydział:"]));
            TableCell uniTableCell32 = new TableCell();
            uniTableCell32.Append(_tablePropertiesGetter.getTableCellPropCentered("2802"));
            uniTableCell32.Append(_paragraphGetter.getNormalText(record.Faculty));
            TableCell uniTableCell33 = new TableCell();
            uniTableCell33.Append(_tablePropertiesGetter.getTableCellPropBorderless("283"));
            uniTableCell33.Append(_paragraphGetter.getNormalText(""));
            TableCell uniTableCell34 = new TableCell();
            uniTableCell34.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            uniTableCell34.Append(_paragraphGetter.getNormalRightText(_localizer["Forma studiów:"]));
            TableCell uniTableCell35 = new TableCell();
            uniTableCell35.Append(_tablePropertiesGetter.getTableCellPropCentered("2977"));
            uniTableCell35.Append(_paragraphGetter.getNormalText(record.Mode));
            uniTableRow3.Append(uniTableCell31, uniTableCell32, uniTableCell33, uniTableCell34, uniTableCell35);

            TableRow uniTableRow4 = new TableRow();
            uniTableRow4.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell uniTableCell41 = new TableCell();
            uniTableCell41.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            uniTableCell41.Append(_paragraphGetter.getNormalRightText(_localizer["Kierunek:"]));
            TableCell uniTableCell42 = new TableCell();
            uniTableCell42.Append(_tablePropertiesGetter.getTableCellPropCentered("2802"));
            uniTableCell42.Append(_paragraphGetter.getNormalText(record.Course));
            TableCell uniTableCell43 = new TableCell();
            uniTableCell43.Append(_tablePropertiesGetter.getTableCellPropBorderless("283"));
            uniTableCell43.Append(_paragraphGetter.getNormalText(""));
            TableCell uniTableCell44 = new TableCell();
            uniTableCell44.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            uniTableCell44.Append(_paragraphGetter.getNormalRightText(_localizer["Poziom studiów:"]));
            TableCell uniTableCell45 = new TableCell();
            uniTableCell45.Append(_tablePropertiesGetter.getTableCellPropCentered("2977"));
            uniTableCell45.Append(_paragraphGetter.getNormalText(record.Level));
            uniTableRow4.Append(uniTableCell41, uniTableCell42, uniTableCell43, uniTableCell44, uniTableCell45);

            TableRow uniTableRow5 = new TableRow();
            uniTableRow5.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell uniTableCell51 = new TableCell();
            uniTableCell51.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            uniTableCell51.Append(_paragraphGetter.getNormalRightText(_localizer["Specjalność:"]));
            TableCell uniTableCell52 = new TableCell();
            uniTableCell52.Append(_tablePropertiesGetter.getTableCellPropCentered("2802"));
            uniTableCell52.Append(_paragraphGetter.getNormalText(record.Specialization));
            TableCell uniTableCell53 = new TableCell();
            uniTableCell53.Append(_tablePropertiesGetter.getTableCellPropBorderless("283"));
            uniTableCell53.Append(_paragraphGetter.getNormalText(""));
            TableCell uniTableCell54 = new TableCell();
            uniTableCell54.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            uniTableCell54.Append(_paragraphGetter.getNormalText(""));
            TableCell uniTableCell55 = new TableCell();
            uniTableCell55.Append(_tablePropertiesGetter.getTableCellPropCentered("2977"));
            uniTableCell55.Append(_paragraphGetter.getNormalText(""));
            uniTableRow5.Append(uniTableCell51, uniTableCell52, uniTableCell53, uniTableCell54, uniTableCell55);

            universityTable.Append(uniTableRow1, uniTableRow2, uniTableRow3, uniTableRow4, uniTableRow5);

            return universityTable;
        }

        public Table getTableWithStudentsInformation(ProposalDocRecord record)
        {
            Table studentsTable = new Table();
            studentsTable.AppendChild<TableProperties>(_tablePropertiesGetter.getHorizontalBorderTableProperties());

            TableRow stdTableRow1 = new TableRow();
            stdTableRow1.Append(new TableRowProperties(new TableRowHeight() { HeightType = HeightRuleValues.Exact, Val = 180 }));
            TableCell stdTableCell11 = new TableCell();
            stdTableCell11.Append(_tablePropertiesGetter.getTableCellPropFilled("1559", "000000"));
            stdTableCell11.Append(_paragraphGetter.getSmallCenteredText(""));
            TableCell stdTableCell12 = new TableCell();
            stdTableCell12.Append(_tablePropertiesGetter.getTableCellPropFilled("3694", "CCCCCC"));
            stdTableCell12.Append(_paragraphGetter.getSmallCenteredText(_localizer["Imię i nazwisko"]));
            TableCell stdTableCell13 = new TableCell();
            stdTableCell13.Append(_tablePropertiesGetter.getTableCellPropFilled("1575", "CCCCCC"));
            stdTableCell13.Append(_paragraphGetter.getSmallCenteredText(_localizer["Nr albumu"]));
            TableCell stdTableCell14 = new TableCell();
            stdTableCell14.Append(_tablePropertiesGetter.getTableCellPropFilled("2351", "CCCCCC"));
            stdTableCell14.Append(_paragraphGetter.getSmallCenteredText(_localizer["Data i podpis"]));
            stdTableRow1.Append(stdTableCell11, stdTableCell12, stdTableCell13, stdTableCell14);

            var students = record.Students.GetEnumerator();
            TableRow stdTableRow2 = new TableRow();
            stdTableRow2.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell stdTableCell21 = new TableCell();
            stdTableCell21.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            stdTableCell21.Append(_paragraphGetter.getNormalRightText(_localizer["Student:"]));
            TableCell stdTableCell22 = new TableCell();
            stdTableCell22.Append(_tablePropertiesGetter.getTableCellPropCentered("3694"));
            stdTableCell22.Append(_paragraphGetter.getNormalText(students.MoveNext() ? students.Current.Id.ToString() : ""));
            TableCell stdTableCell23 = new TableCell();
            stdTableCell23.Append(_tablePropertiesGetter.getTableCellPropCentered("1575"));
            stdTableCell23.Append(_paragraphGetter.getNormalText(""));
            TableCell stdTableCell24 = new TableCell();
            stdTableCell24.Append(_tablePropertiesGetter.getTableCellPropCentered("2351"));
            stdTableCell24.Append(_paragraphGetter.getNormalText(""));
            stdTableRow2.Append(stdTableCell21, stdTableCell22, stdTableCell23, stdTableCell24);

            TableRow stdTableRow3 = new TableRow();
            stdTableRow3.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell stdTableCell31 = new TableCell();
            stdTableCell31.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            stdTableCell31.Append(_paragraphGetter.getNormalRightText(_localizer["Student:"]));
            TableCell stdTableCell32 = new TableCell();
            stdTableCell32.Append(_tablePropertiesGetter.getTableCellPropCentered("3694"));
            stdTableCell32.Append(_paragraphGetter.getNormalText(students.MoveNext() ? students.Current.Id.ToString() : ""));
            TableCell stdTableCell33 = new TableCell();
            stdTableCell33.Append(_tablePropertiesGetter.getTableCellPropCentered("1575"));
            stdTableCell33.Append(_paragraphGetter.getNormalText(""));
            TableCell stdTableCell34 = new TableCell();
            stdTableCell34.Append(_tablePropertiesGetter.getTableCellPropCentered("2351"));
            stdTableCell34.Append(_paragraphGetter.getNormalText(""));
            stdTableRow3.Append(stdTableCell31, stdTableCell32, stdTableCell33, stdTableCell34);

            TableRow stdTableRow4 = new TableRow();
            stdTableRow4.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell stdTableCell41 = new TableCell();
            stdTableCell41.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            stdTableCell41.Append(_paragraphGetter.getNormalRightText(_localizer["Student:"]));
            TableCell stdTableCell42 = new TableCell();
            stdTableCell42.Append(_tablePropertiesGetter.getTableCellPropCentered("3694"));
            stdTableCell42.Append(_paragraphGetter.getNormalText(students.MoveNext() ? students.Current.Id.ToString() : ""));
            TableCell stdTableCell43 = new TableCell();
            stdTableCell43.Append(_tablePropertiesGetter.getTableCellPropCentered("1575"));
            stdTableCell43.Append(_paragraphGetter.getNormalText(""));
            TableCell stdTableCell44 = new TableCell();
            stdTableCell44.Append(_tablePropertiesGetter.getTableCellPropCentered("2351"));
            stdTableCell44.Append(_paragraphGetter.getNormalText(""));
            stdTableRow4.Append(stdTableCell41, stdTableCell42, stdTableCell43, stdTableCell44);

            TableRow stdTableRow5 = new TableRow();
            stdTableRow5.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell stdTableCell51 = new TableCell();
            stdTableCell51.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            stdTableCell51.Append(_paragraphGetter.getNormalRightText(_localizer["Student:"]));
            TableCell stdTableCell52 = new TableCell();
            stdTableCell52.Append(_tablePropertiesGetter.getTableCellPropCentered("3694"));
            stdTableCell52.Append(_paragraphGetter.getNormalText(students.MoveNext() ? students.Current.Id.ToString() : ""));
            TableCell stdTableCell53 = new TableCell();
            stdTableCell53.Append(_tablePropertiesGetter.getTableCellPropCentered("1575"));
            stdTableCell53.Append(_paragraphGetter.getNormalText(""));
            TableCell stdTableCell54 = new TableCell();
            stdTableCell54.Append(_tablePropertiesGetter.getTableCellPropCentered("2351"));
            stdTableCell54.Append(_paragraphGetter.getNormalText(""));
            stdTableRow5.Append(stdTableCell51, stdTableCell52, stdTableCell53, stdTableCell54);

            studentsTable.Append(stdTableRow1, stdTableRow2, stdTableRow3, stdTableRow4, stdTableRow5);

            return studentsTable;
        }

        public Table getTableWithProposalInformation(ProposalDocRecord record)
        {
            Table diplomaTable = new Table();
            diplomaTable.AppendChild<TableProperties>(_tablePropertiesGetter.getHorizontalBorderTableProperties());

            TableRow dipTableRow1 = new TableRow();
            dipTableRow1.Append(new TableRowProperties(new TableRowHeight() { HeightType = HeightRuleValues.Exact, Val = 180 }));
            TableCell dipTableCell11 = new TableCell();
            dipTableCell11.Append(_tablePropertiesGetter.getTableCellPropFilled("1559", "000000"));
            dipTableCell11.Append(_paragraphGetter.getSmallCenteredText(""));
            TableCell dipTableCell12 = new TableCell();
            dipTableCell12.Append(_tablePropertiesGetter.getTableCellPropFilled("534", "CCCCCC"));
            dipTableCell12.Append(_paragraphGetter.getSmallCenteredText(""));
            TableCell dipTableCell13 = new TableCell();
            dipTableCell13.Append(_tablePropertiesGetter.getTableCellPropFilled("7087", "CCCCCC"));
            dipTableCell13.Append(_paragraphGetter.getSmallCenteredText(""));
            dipTableRow1.Append(dipTableCell11, dipTableCell12, dipTableCell13);


            TableRow dipTableRow2 = new TableRow();
            dipTableRow2.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell dipTableCell21 = new TableCell();
            dipTableCell21.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            dipTableCell21.Append(_paragraphGetter.getNormalRightText(_localizer["Tytuł pracy:"]));
            TableCell dipTableCell22 = new TableCell();
            dipTableCell22.Append(_tablePropertiesGetter.getTableCellPropCentered("534"));
            dipTableCell22.Append(_paragraphGetter.getNormalText(""));
            TableCell dipTableCell23 = new TableCell();
            dipTableCell23.Append(_tablePropertiesGetter.getTableCellPropCentered("7087"));
            dipTableCell23.Append(_paragraphGetter.getNormalText(record.TopicPolish));
            dipTableRow2.Append(dipTableCell21, dipTableCell22, dipTableCell23);

            TableRow dipTableRow3 = new TableRow();
            dipTableRow3.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell dipTableCell31 = new TableCell();
            dipTableCell31.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            dipTableCell31.Append(_paragraphGetter.getNormalRightText(_localizer["Wersja angielska tytułu:"]));
            TableCell dipTableCell32 = new TableCell();
            dipTableCell32.Append(_tablePropertiesGetter.getTableCellPropCentered("534"));
            dipTableCell32.Append(_paragraphGetter.getNormalText(""));
            TableCell dipTableCell33 = new TableCell();
            dipTableCell33.Append(_tablePropertiesGetter.getTableCellPropCentered("7087"));
            dipTableCell33.Append(_paragraphGetter.getItalicText(record.TopicEnglish));
            dipTableRow3.Append(dipTableCell31, dipTableCell32, dipTableCell33);

            TableRow dipTableRow4 = new TableRow();
            dipTableRow4.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell dipTableCell41 = new TableCell();
            dipTableCell41.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            dipTableCell41.Append(_paragraphGetter.getNormalRightText(_localizer["Dane wyjściowe:"]));
            TableCell dipTableCell42 = new TableCell();
            dipTableCell42.Append(_tablePropertiesGetter.getTableCellPropCentered("534"));
            dipTableCell42.Append(_paragraphGetter.getNormalText(""));
            TableCell dipTableCell43 = new TableCell();
            dipTableCell43.Append(_tablePropertiesGetter.getTableCellPropCentered("7087"));
            dipTableCell43.Append(_paragraphGetter.getNormalText(record.OutputData));
            dipTableRow4.Append(dipTableCell41, dipTableCell42, dipTableCell43);

            TableRow dipTableRow5 = new TableRow();
            dipTableRow5.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell dipTableCell51 = new TableCell();
            dipTableCell51.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            dipTableCell51.Append(_paragraphGetter.getNormalRightText(_localizer["Zakres pracy:"]));
            TableCell dipTableCell52 = new TableCell();
            dipTableCell52.Append(_tablePropertiesGetter.getTableCellPropCentered("534"));
            dipTableCell52.Append(_paragraphGetter.getNormalText(""));
            TableCell dipTableCell53 = new TableCell();
            dipTableCell53.Append(_tablePropertiesGetter.getTableCellPropCentered("7087"));
            dipTableCell53.Append(_paragraphGetter.getNormalText(record.Description));
            dipTableRow5.Append(dipTableCell51, dipTableCell52, dipTableCell53);

            TableRow dipTableRow6 = new TableRow();
            dipTableRow6.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell dipTableCell61 = new TableCell();
            dipTableCell61.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            dipTableCell61.Append(_paragraphGetter.getNormalRightText(_localizer["Termin oddania pracy:"]));
            TableCell dipTableCell62 = new TableCell();
            dipTableCell62.Append(_tablePropertiesGetter.getTableCellPropCentered("534"));
            dipTableCell62.Append(_paragraphGetter.getNormalText(""));
            TableCell dipTableCell63 = new TableCell();
            dipTableCell63.Append(_tablePropertiesGetter.getTableCellPropCentered("7087"));
            dipTableCell63.Append(_paragraphGetter.getNormalText(
                record.Level.ToLower().Contains("mag") ? 
                _systemSettingsGetter.GetSystemSettings().MasterThesisEndDate.ToString("yyyy'-'MM'-'dd") :
                _systemSettingsGetter.GetSystemSettings().BachelorThesisEndDate.ToString("yyyy'-'MM'-'dd")));
            dipTableRow6.Append(dipTableCell61, dipTableCell62, dipTableCell63);

            TableRow dipTableRow7 = new TableRow();
            dipTableRow7.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell dipTableCell71 = new TableCell();
            dipTableCell71.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            dipTableCell71.Append(_paragraphGetter.getNormalRightText(_localizer["Promotor:"]));
            TableCell dipTableCell72 = new TableCell();
            dipTableCell72.Append(_tablePropertiesGetter.getTableCellPropCentered("534"));
            dipTableCell72.Append(_paragraphGetter.getNormalText(""));
            TableCell dipTableCell73 = new TableCell();
            dipTableCell73.Append(_tablePropertiesGetter.getTableCellPropCentered("7087"));
            dipTableCell73.Append(_paragraphGetter.getNormalText(record.Promoter));
            dipTableRow7.Append(dipTableCell71, dipTableCell72, dipTableCell73);

            TableRow dipTableRow8 = new TableRow();
            dipTableRow8.Append(new TableRowProperties(new TableRowHeight() { Val = 300 }));
            TableCell dipTableCell81 = new TableCell();
            dipTableCell81.Append(_tablePropertiesGetter.getTableCellPropCentered("1559"));
            dipTableCell81.Append(_paragraphGetter.getNormalRightText(_localizer["Jednostka organizacyjna promotora:"]));
            TableCell dipTableCell82 = new TableCell();
            dipTableCell82.Append(_tablePropertiesGetter.getTableCellPropCentered("534"));
            dipTableCell82.Append(_paragraphGetter.getNormalText(""));
            TableCell dipTableCell83 = new TableCell();
            dipTableCell83.Append(_tablePropertiesGetter.getTableCellPropCentered("7087"));
            dipTableCell83.Append(_paragraphGetter.getNormalText(record.Institute));
            dipTableRow8.Append(dipTableCell81, dipTableCell82, dipTableCell83);

            diplomaTable.Append(dipTableRow1, dipTableRow2, dipTableRow3, dipTableRow4, dipTableRow5, dipTableRow6, dipTableRow7, dipTableRow8);

            return diplomaTable;
        }

        public Table getTableWithSignature()
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
            sigTableCell11.Append(_tablePropertiesGetter.getTableCellPropCentered("3969"));
            sigTableCell11.Append(_paragraphGetter.getSmallCenteredText(""));
            TableCell sigTableCell12 = new TableCell();
            sigTableCell12.AppendChild<TableCellProperties>(new TableCellProperties(new TableCellBorders(new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) })));
            sigTableCell12.Append(_tablePropertiesGetter.getTableCellPropCentered("425"));
            sigTableCell12.Append(_paragraphGetter.getSmallCenteredText(""));
            TableCell sigTableCell13 = new TableCell();
            sigTableCell13.Append(_tablePropertiesGetter.getTableCellPropCentered("3260"));
            sigTableCell13.Append(_paragraphGetter.getSmallCenteredText(""));
            sigTableRow1.Append(sigTableCell11, sigTableCell12, sigTableCell13);


            TableRow sigTableRow2 = new TableRow();
            sigTableRow2.Append(new TableRowProperties(new TableRowHeight() { Val = 255 }));
            TableCell sigTableCell21 = new TableCell();
            sigTableCell21.Append(_tablePropertiesGetter.getTableCellPropCentered("3969"));
            sigTableCell21.Append(_paragraphGetter.getSmallCenteredText(_localizer["podpis dyrektora/kierownika jednostki organizacyjnej promotora"]));
            TableCell sigTableCell22 = new TableCell();
            sigTableCell22.AppendChild<TableCellProperties>(new TableCellProperties(new TableCellBorders(new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Nil) })));
            sigTableCell22.Append(_tablePropertiesGetter.getTableCellPropCentered("425"));
            sigTableCell22.Append(_paragraphGetter.getSmallCenteredText(""));
            TableCell sigTableCell23 = new TableCell();
            sigTableCell23.Append(_tablePropertiesGetter.getTableCellPropCentered("3260"));
            sigTableCell23.Append(_paragraphGetter.getSmallCenteredText(_localizer["podpis Dziekana"]));
            sigTableRow2.Append(sigTableCell21, sigTableCell22, sigTableCell23);

            signatureTable.Append(sigTableRow1, sigTableRow2);

            return signatureTable;
        }

        public Table getTableWithCity(ProposalDocRecord record)
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
            dataTableCell11.Append(_tablePropertiesGetter.getTableCellPropCentered("3260"));
            dataTableCell11.Append(_paragraphGetter.getSmallCenteredText($"{_localizer["Poznań"]}, {record.StartingDate.ToString("yyyy'-'MM'-'dd")}"));
            dataTableRow1.Append(dataTableCell11);


            TableRow dataTableRow2 = new TableRow();
            dataTableRow2.Append(new TableRowProperties(new TableRowHeight() { Val = 255 }));
            TableCell dataTableCell21 = new TableCell();
            dataTableCell21.Append(_tablePropertiesGetter.getTableCellPropCentered("3260"));
            dataTableCell21.Append(_paragraphGetter.getSmallCenteredText(_localizer["miejscowość, data"]));
            dataTableRow2.Append(dataTableCell21);

            dataTable.Append(dataTableRow1, dataTableRow2);

            return dataTable;
        }
    }
}
