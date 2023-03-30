using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_4
{
  
    public partial class Form1 : Form
    {
        Container container = new Container();
        Graphics g;
        CCircleCreation Creation;
        Bitmap map;
        Boolean ctrlpress = false;
        public Form1()
        {
            InitializeComponent();
            map = new Bitmap(paintField.Width, paintField.Height);
            Creation = new CCircleCreation(Graphics.FromImage(map));
        }

        
        private void paintField_Paint(object sender, PaintEventArgs e)
        {
            container.drawCircles();
            paintField.Image = map;
        }

        private void paintField_MouseClick(object sender, MouseEventArgs e)
        {
            container.AddOrSelectShape(Creation.createCCircle(e.Location));
            paintField.Invalidate();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                ctrlpress = true;
                container.ctrlPressed = !container.ctrlPressed;
            }
            if (e.KeyCode == Keys.Delete)
            {
                Graphics.FromImage(map).Clear(Color.LightGray);
                container.delSelected();
            }
        }

        private void CtrlCheck_CheckedChanged(object sender, EventArgs e)
        {
            container.ctrlPressed = !container.ctrlPressed;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control && ctrlpress == true)
            {
                container.ctrlPressed = !container.ctrlPressed;
                ctrlpress = !ctrlpress;
            }
        }

        private void deleteAll_Click(object sender, EventArgs e)
        {
            Graphics.FromImage(map).Clear(Color.LightGray);
            container.delCircles();
        }

        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            container.selectMany = !container.selectMany;
        }

        private void paintField_Click(object sender, EventArgs e)
        {

        }
    }
    
}
