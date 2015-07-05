using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SortImage
{
    public partial class NewNode : Form
    {
        
#region Local Variables

        private string mNewNodeName;
      //  private string mNewNodeText;
      //  private string mNewNodeTag;


#endregion


        /// <summary>
        /// Default constructor
        /// </summary>
        public NewNode()
        {
            InitializeComponent();
            txtNewNodeName.Select();
        }



#region Class Properties

        public string NewNodeName
        {
            get
            {
                return mNewNodeName;
            }
            set
            {
                mNewNodeName = value;
            }
        }
        
#endregion



        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtNewNodeName.Text != string.Empty)
            {
                NewNodeName = txtNewNodeName.Text;
            }
            else
            {
                MessageBox.Show("Name the node.");
                return;
            }

            this.Close();
        }



    }
}