using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_GameStoryEdit.Models.ScreenPlay.ISpans
{
    interface ISpan
    {
        List<INote> Notes { get; }
        List<ILiteral> Literals { get; }
        List<IBold> Bolds { get; }
        List<IItalic> Italics { get; }
        List<IUnderline> Underlines { get; }
        List<IHardLineBreak> HardLineBreaks { get; }
    }
}
