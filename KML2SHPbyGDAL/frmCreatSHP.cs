using KML2SHPbyGDAL.App_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KML2SHPbyGDAL
{
    public partial class frmCreatSHP : Form
    {
        public frmCreatSHP()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_createshp_Click(object sender, EventArgs e)
        {
            string sPath = this.txt_ShpPath.Text;
            if (sPath.Equals(""))
            {
                MessageBox.Show("请选择输出路径！");
                return;
            }
            VectorFile.WriteVectorFile(sPath);
        }

        private void btn_SHPOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "矢量文件|*.shp";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_ShpPath.Text = saveFileDialog1.FileName;
            }
                
        }
    }
}
