using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using UI.Enums;

namespace UI
{
    internal partial class ButtonBoard : Button
    {
        private static Dictionary<eButtonBoardType, Color> s_ColorMap = new Dictionary<eButtonBoardType, Color>()
        {
            { eButtonBoardType.X, Color.Aqua },
            { eButtonBoardType.O, Color.DarkMagenta },
            { eButtonBoardType.Empty, Color.LightGray },
        };

        internal eButtonBoardType boardType { get; }

        internal int XCoord { get; }

        internal int YCoord { get; }

        internal ButtonBoard(eButtonBoardType i_buttonType, int i_xCoord, int i_yCoord)
            : base()
        {
            BackColor = s_ColorMap[i_buttonType];
            boardType = i_buttonType;
            XCoord = i_xCoord;
            YCoord = i_yCoord;
        }

        internal void Highlight()
        {
            BackColor = Color.FromArgb(173, 216, 230);
        }

        internal void UnHighlight()
        {
            BackColor = s_ColorMap[boardType];
            FlatStyle = FlatStyle.Standard;
            FlatAppearance.BorderSize = 0;
        }

        internal void HighlightHover()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = Color.FromArgb(216, 191, 216);
            FlatAppearance.BorderSize = 5;
        }
    }
}
