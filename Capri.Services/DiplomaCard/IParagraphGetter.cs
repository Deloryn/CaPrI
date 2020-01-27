using Capri.Web.ViewModels.Proposal;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capri.Services.DiplomaCard
{
    public interface IParagraphGetter
    {
        Paragraph getTitle(ProposalDocRecord record);
        Paragraph getClause();
        Paragraph getNormalText(string text);
        Paragraph getNormalRightText(string text);
        Paragraph getItalicText(string text);
        Paragraph getSmallCenteredText(string text);
    }
}
