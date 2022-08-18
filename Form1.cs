using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppTaker
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public NoteTaker()
        {
            InitializeComponent();
        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");
            PreviousNotes.DataSource = notes;


        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Titlebox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            NoteBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();  
            editing = true;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[PreviousNotes.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {

                Console.WriteLine("");
            }
        }

        private void NewNoteBtn_Click(object sender, EventArgs e)
        {
            Titlebox.Text =  "";
            NoteBox.Text = "";

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(editing)
            {
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Title"] = Titlebox.Text;
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Note"] = NoteBox.Text;
            }
            else
            {
                notes.Rows.Add(Titlebox.Text, NoteBox.Text);
            }

            Titlebox.Text = "";
            NoteBox.Text = "";
            editing = false;
        }

        private void PreviousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Titlebox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            NoteBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
    }
}
