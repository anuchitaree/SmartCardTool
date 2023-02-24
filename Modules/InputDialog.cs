using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartCardTool.Modules
{
    public static class InputDialog
    {
        public static DialogResult InputBox(string title, string promptText1, ref string value1, string promptText2, ref string value2, string promptText3, ref string value3)
        {
            Form form = new Form();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();

            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label1.Text = promptText1;
            label2.Text = promptText2;
            label3.Text = promptText3;

            textBox1.Text = value1;
            textBox2.Text = value2;
            textBox3.Text = value3;


            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label1.SetBounds(9, 20, 372, 13);
            textBox1.SetBounds(12, 36, 372, 40);

            label2.SetBounds(9, 60, 372, 13);
            textBox2.SetBounds(12, 76, 372, 40);

            label3.SetBounds(9, 106, 372, 13);
            textBox3.SetBounds(12, 116, 372, 40);

            buttonOk.SetBounds(228, 162, 75, 23);
            buttonCancel.SetBounds(309, 162, 75, 23);

            label1.AutoSize= label2.AutoSize= label3.AutoSize = true;
            textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
            textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;
            textBox3.Anchor = textBox3.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 207);
            form.Controls.AddRange(new Control[] { label1, textBox1, label2, textBox2, label3, textBox3, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label1.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;

            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value1 = textBox1.Text;
            value2 = textBox2.Text;
            value3 = textBox3.Text;

            return dialogResult;
        }



    }
}
