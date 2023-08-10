using System;
using System.Runtime.InteropServices;
using UI.Enums;

namespace UI
{
    internal class UIManager
    {
        private readonly FormBoard r_FormBoard;

        [DllImport("user32")]
        internal static extern bool AnimateWindow(IntPtr handle, int time, AnimateWindowFlags flag);

        public UIManager()
        {
            FormGameSettings formGameSetting = new FormGameSettings();
            FormGameSettings.InitPackage initPackage = formGameSetting.GetInitPackage();

            if (initPackage != null)
            {
                r_FormBoard = new FormBoard(initPackage);
                AnimateWindow(r_FormBoard.Handle, 1000, AnimateWindowFlags.AW_CENTER);
                r_FormBoard.ShowDialog();
            }
        }
    }
}
