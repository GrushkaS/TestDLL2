using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

using Zulu;
using ZuluLib;
using ZuluCharts;
using ZB;
using ZuluComNetOcx;
using ZuluOcx;
using zulurep;
using zuluui;
using stdole;

namespace TestDLL2
{

    [ComVisible(true)]
    [ProgId("TestDLL2.MainUserControl")]
    public partial class MainUserControl : UserControl
    {
        public MainUserControl()
        {
            InitializeComponent();
        }

        public void ShowForm() { }

        IPluginConnector pluginConnector;

        Document aDoc;
        MapDoc Map;

        Layer ActiveLayer;



        public bool ConnectZuluPlugin(IPluginConnector connector) 
        {
            try
            {
                
                pluginConnector = connector;
                
                aDoc = pluginConnector?.Zulu?.ActiveDocument;
                Map = aDoc?.NativeDoc;          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        public void DisconnectZuluPlugin()
        {           
            pluginConnector.Unlock();
            pluginConnector = null;
            Map = null;
            aDoc = null;
        }

        private void SetCRSProjection(string input)
        {
            ActiveLayer.SetInputCRSProjection(input);
        }

        private void GetValues(string input, out double[] Xcoord, out double[] Ycoord)
        {
            string[] split_text = input.Split(new char[] { ' ', ',', ';' });
            if (split_text.Length >= 8)
            {
                try
                {
                    int n = split_text.Length / 2;
                    Xcoord = new double[n];
                    Ycoord = new double[n];
                    int x = 0;
                    for (int i = 0; i < n; i++)
                    {
                        Xcoord[i] = double.Parse(split_text[x]);
                        Ycoord[i] = double.Parse(split_text[x + 1]);
                        x += 2;
                    }


                    #region debugging
                    /*
                    string what = null;
                    string what2 = null;
                    for(int i = 0; i < split_text.Length; i++)
                    {
                        what2 += split_text[i] + " ";
                    }

                    for (int i = 0; i < Xcoord.Length; i++)
                    {                 
                        what += Xcoord[i].ToString() + ";" + Ycoord[i].ToString() + ". "; 
                    }

                    MessageBox.Show(what2, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(what, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                    #endregion
                }
                catch
                {
                    Xcoord = null;
                    Ycoord = null;
                }
            }
            else
            {
                Xcoord = null;
                Ycoord = null;
            }

        }

        private void Draw(double[] Xcoord, double[] Ycoord)
        {
            int id = ActiveLayer.GetLargestID();
            //int id = ActiveLayer.Elements.Count;
            //int id = 4;
            //int id = ActiveLayer.ElementKeys[ActiveLayer.ElementKeys.Count];
            //int id = ActiveLayer.Selection.ElementKeys.Count;
            //MessageBox.Show("Selected id = " + id.ToString(), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);         
            
            PolyLine pLine = ActiveLayer.Elements.GetElement(id).PolyLine;
            //MessageBox.Show("Selected element = " + ActiveLayer.Elements.GetElement(id).Key.ToString(), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            pLine.Fill(4, ref Xcoord[0], ref Ycoord[0]);
            pLine.AddPoint(Xcoord[0], Ycoord[0]);

            //ActiveLayer.Elements.GetElement(ActiveLayer.ElementKeys[id]).SetPolyLine(pLine);

            #region debug
            MessageBox.Show(ActiveLayer.Elements.GetElement(ActiveLayer.ElementKeys[1]).SetPolyLine(pLine).ToString(), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show(el.SetPolyLine(pLine).ToString(), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            #endregion
        }


        private void ButtonMain_Click(object sender, EventArgs e)
        {
            try
            {
                double[] Xcoord, Ycoord;
                GetValues(TextBoxMain.Text, out Xcoord, out Ycoord);

                if(Xcoord == null) MessageBox.Show("Incorrect input data", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    ActiveLayer = Map?.Layers?.Active;
                    SetCRSProjection("EPSG:32601");

                    Draw(Xcoord, Ycoord);
                }
                
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
