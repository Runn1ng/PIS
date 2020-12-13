using System.Windows.Forms;

namespace PIS.UI
{
    internal class Utils
    {
        public static void ShowError(string message,
            string headerText = "Error")
        {
            MessageBox.Show(
                message,
                headerText,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}