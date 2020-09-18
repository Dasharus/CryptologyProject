using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISSproject
{
    public partial class freqRadioBut : Form
    {
        BindingList<dataLetter> data = new BindingList<dataLetter>();
        List<dataLetter> dtl = new List<dataLetter>();
        string engLetters = "abcdefghijklmnopqrstuvwxyz";
        string ukrLetters = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";

        public freqRadioBut()
        {
            InitializeComponent();
            Tabble.DataSource = data;
        }
        class dataLetter
        {
            public string Letter { get; set; }
            public int Count { get; set; }
            public double Frequency { get; set; }
            public dataLetter(string l, int c, double f)
            {
                Letter = l;
                Count = c;
                Frequency = f;
            }
            public dataLetter() { }
            public int CompareTo(dataLetter other)
            {
                if (Count == other.Count)
                {
                    return Letter.CompareTo(other.Letter);
                }
                return Count - other.Count;
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TextEntered.Text.Length > 0)
            {
                if ((MessageBox.Show("Would you like yo save your text?", "Warning", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                {
                    SaveFileDialog svf = new SaveFileDialog();
                    svf.Filter = "Text Files (.txt)|*.txt";
                    svf.Title = "Save file...";
                    if (svf.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.StreamWriter sr = new System.IO.StreamWriter(svf.FileName);
                        sr.Write(TextEntered.Text);
                        sr.Close();
                        MessageBox.Show("SAVED!");
                    }
                }
                else
                {
                    TextEntered.Clear();
                }
            }
            else
            {
                TextEntered.Clear();
            }
            Tabble.Rows.Clear();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files ( .txt)|*.txt";
            ofd.Title = "Open a File...";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName);
                TextEntered.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.Unicode);
                try
                {
                    List<int> col_n = new List<int>();
                    foreach (DataGridViewColumn col in Tabble.Columns)
                        if (col.Visible)
                        {
                            col_n.Add(col.Index);
                        }
                    int x = Tabble.RowCount;
                    if (Tabble.AllowUserToAddRows) x--;

                    for (int i = 0; i < x; i++)
                    {
                        for (int y = 0; y < col_n.Count; y++)
                            sw.Write(Tabble[col_n[y], i].Value + "\t");
                        sw.Write(" \r\n");
                    }
                    sw.Close();
                    MessageBox.Show("SAVED!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void CalculatetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uAToolStripMenuItem.Checked == false & eNGToolStripMenuItem.Checked == false)
            {
                MessageBox.Show("ERROR. SELECT A LANGUAGE");
            }
            if (uAToolStripMenuItem.Checked)
            {
                dothis(ukrLetters);
            }
            else
            {
                dothis(engLetters);
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEntered.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEntered.Redo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEntered.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEntered.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEntered.Paste();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEntered.SelectAll();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            if (uAToolStripMenuItem.Checked==false & eNGToolStripMenuItem.Checked==false)
            {
                MessageBox.Show("ERROR. SELECT A LANGUAGE");
            }
            else if (uAToolStripMenuItem.Checked)
            {
                dothis(ukrLetters);
            }
            else
            {
                dothis(engLetters);
            }
        }

        public void dothis(string s)
        {
            Tabble.DataSource = data;
            Tabble.Rows.Clear();
            data.Clear();   
            dtl.Clear();
            try
            {
                if (TextEntered.TextLength == 0)
                { throw new Exception(); }
                File.WriteAllText("Table.txt", string.Empty);
                StreamWriter file = new StreamWriter("Table.txt");
                Tabble.Rows.Clear();
                string strText = TextEntered.Text;

                for (int i = 0; i < s.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < strText.Length; j++)
                    {
                        if (s[i] == strText[j])
                        {
                            count++;
                        }
                    }

                        data.Add(new dataLetter(s[i].ToString(), count,
                           (Convert.ToDouble(count) / Convert.ToDouble(TextEntered.TextLength))));
                        dtl.Add(new dataLetter(s[i].ToString(), count,
                          (Convert.ToDouble(count) / Convert.ToDouble(TextEntered.TextLength))));
                        file.WriteLine(s[i].ToString() + " " + count + " " +
                        (Convert.ToDouble(count) / Convert.ToDouble(TextEntered.TextLength)));
                  
                }

                if (frequencyToolStripMenuItem.Checked)
                {
                    dtl.Sort((dataLetter X, dataLetter Y) => X.Frequency.CompareTo(Y.Frequency));
                    if(higherToolStripMenuItem.Checked)
                    {
                        dtl.Reverse();
                    }
                    Tabble.DataSource = dtl;
                }
                if(alphabetToolStripMenuItem.Checked)
                {
                    if(zaToolStripMenuItem.Checked)
                    {
                        dtl.Reverse();
                    }
                    Tabble.DataSource = dtl;
                }
                file.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Smth wrong. Check!");
            }


        }

        private void UAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uAToolStripMenuItem.Checked = true;
            eNGToolStripMenuItem.Checked = false;
            uaRadioBut.Checked = true;
            engRadioBut.Checked = false;
            label3.Text = "Language: UA";
        }

        private void ENGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uAToolStripMenuItem.Checked = false;
            eNGToolStripMenuItem.Checked = true;
            uaRadioBut.Checked = false;
            engRadioBut.Checked = true;
            label3.Text = "Language: ENG";

        }

        private void UaRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            uAToolStripMenuItem.Checked = true;
            eNGToolStripMenuItem.Checked = false;
            label3.Text = "Language: UA";
        }

        private void EngRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            uAToolStripMenuItem.Checked = false;
            eNGToolStripMenuItem.Checked = true;
            label3.Text = "Language: ENG";
        }

        private void FrequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alphabetToolStripMenuItem.Checked = false;
            frequencyToolStripMenuItem.Checked = true;
            sortbyLabel.Text = "Sort by: Frequency";
            if (uAToolStripMenuItem.Checked == false & eNGToolStripMenuItem.Checked == false)
            {
                MessageBox.Show("ERROR. SELECT A LANGUAGE");
            }
            else if (uAToolStripMenuItem.Checked)
            {
                dothis(ukrLetters);
            }
            else
            {
                dothis(engLetters);
            }


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            Hide();
            frm.ShowDialog();
        }

        private void Task1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void AlphabetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alphabetToolStripMenuItem.Checked = true;
            frequencyToolStripMenuItem.Checked = false;
            sortbyLabel.Text = "Sort by: Alphabet";
            if (uAToolStripMenuItem.Checked == false & eNGToolStripMenuItem.Checked == false)
            {
                MessageBox.Show("ERROR. SELECT A LANGUAGE");
            }
            else if (uAToolStripMenuItem.Checked)
            {
                dothis(ukrLetters);
            }
            else
            {
                dothis(engLetters);
            }
        }

        private void LowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lowerToolStripMenuItem.Checked = true;
            higherToolStripMenuItem.Checked = false;
        }

        private void HigherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lowerToolStripMenuItem.Checked = false;
            higherToolStripMenuItem.Checked = true;
        }

        private void AzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azToolStripMenuItem.Checked = true;
            zaToolStripMenuItem.Checked = false;
        }

        private void ZaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azToolStripMenuItem.Checked = false;
            zaToolStripMenuItem.Checked = true;
        }
    }
}
