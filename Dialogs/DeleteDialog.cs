using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SortImage
{
    public partial class DeleteDialog : Form
    {
        string deleteSelect = "CANCEL";
        public DeleteDialog()
        {
            InitializeComponent();
        }

        private void DeleteDialog_Load(object sender, EventArgs e)
        {

        }



        public string GetString()
        {
            return deleteSelect;
        }

        private void toBinAll_Click(object sender, EventArgs e)
        {
            deleteSelect = "ALLBIN";
        }

        private void toBinThis_Click(object sender, EventArgs e)
        {
            deleteSelect = "THISBIN";
        }

        private void markDeleteThis_Click(object sender, EventArgs e)
        {
            deleteSelect = "THISMARK";
        }

        private void markDeleteAll_Click(object sender, EventArgs e)
        {
            deleteSelect = "ALLMARK";
        }

        private void deleteCancel_Click(object sender, EventArgs e)
        {
            //deleteSelect = "CANCEL";
        }
    }
}
