using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace hexeditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Button o = sender as Button;
            if (o.Name.Equals("button1"))
            {
              
                try
                {
                    editor obj = new editor(@textbox1.Text);
                    string str1 = new string(obj.ConvertChar());
                    textbox3.Text = Convert.ToString(str1);
                    string str2 = obj.ConvertHex();
                    textbox2.Text = str2;
                }
                catch (Exception eobj)
                {
                    textbox5.Text = Convert.ToString(eobj);
                }
            }
            else if(o.Name.Equals("button2"))
            {
                if(textbox2.Text.Contains(textbox4.Text))
                {
                    textbox7.Text = "Index: "+ Convert.ToString(textbox2.Text.IndexOf(textbox4.Text));


                }
                else
                {
                    textbox7.Text = "not found";
                }
            }
            else if (o.Name.Equals("button3"))
            {
                if (textbox3.Text.Contains(textbox6.Text))
                {
                    textbox8.Text = "Index: " + Convert.ToString(textbox2.Text.IndexOf(textbox4.Text));
                }
                else
                {
                    textbox8.Text = "not found";
                }
            }
        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox8_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    class editor
    {
        String name;
        FileStream fs;
        BinaryReader br;
        public editor(string filename)
        {
            name = filename;
            
            fs = new FileStream(name, FileMode.Open);
            
            br = new BinaryReader(fs);
        }
        public long Filelength()
        {
            return fs.Length;
        }
        public string ConvertHex()
        {
            
            fs.Position = 0;
            string opstr="",str;
            for (int i = 0; i < fs.Length; i++)
            {
                
                opstr = opstr +Convert.ToString(br.ReadByte(),16);
                
                
                
            }
            return opstr;
        }
        public char [] ConvertChar()
        {
            fs.Position = 0;
            char[] oparr = new char[fs.Length];
            for (int i = 0; i < fs.Length; i++)
            {
                oparr[i] = Convert.ToChar(br.ReadByte());
                

            }
            return oparr;
        }
    }

}
