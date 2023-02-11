using System.IO;
using Microsoft.VisualBasic.Devices;
using static System.Net.WebRequestMethods;

namespace LAB7
{
    public partial class Form1 : Form
    {
        public class MyList
        {
            public string namel { get; set; }
            public string secondnamel { get; set; }
            public string datel { get; set; }
            public int sizel { get; set; }
            public double wieghtl { get; set; }

            public MyList(string namel, string secondnamel, string datel, int sizel, double wieghtl)
            {
                this.namel = namel;
                this.secondnamel = secondnamel;
                this.datel = datel;
                this.sizel = sizel;
                this.wieghtl = wieghtl;
            }
        }
            
        List<MyList> mylist = new List<MyList>();


        string path = @"F:\Visual Studio\OP\LAB7\Files\";
        (string, string, string, string, string, string) name = ("one.bin","two.bin","three.bin","four.bin","five.bin","six.bin");
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        





//FIRST
        private void buttonWrite1_Click(object sender, EventArgs e)
        {
            TextBoxFirstPageInt.Text += ' ';
            string s = null;
            try
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(path + name.Item1, FileMode.Create)))
                {
                    foreach (char v in TextBoxFirstPageInt.Text)
                    {
                        if(v != ' ')
                        {
                            s += v;
                        }
                        else
                        {
                            bw.Write(int.Parse(s));
                            s = null;
                        }
                        
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void buttonRead1_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(path + name.Item1, FileMode.Open)))
                {
                    while (br.PeekChar() > -1)
                    {
                        TextBoxFirstPageInt.AppendText(br.ReadInt32().ToString() + " ");
                    }
                   
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }



        //SECOND
        private void buttonWrite2_Click(object sender, EventArgs e)
        {
            TextBoxSecondPageDouble.Text += ' ';
            string s = null;
            try
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(path + name.Item2, FileMode.Create)))
                {
                    foreach (char v in TextBoxSecondPageDouble.Text)
                    {
                        if (v != ' ')
                        {
                            s += v;
                        }
                        else
                        {
                            bw.Write(Double.Parse(s));
                            s = null;
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void buttonRead2_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(path + name.Item2, FileMode.Open)))
                {
                    while (br.PeekChar() > -1)
                    {
                        TextBoxSecondPageDouble.AppendText(br.ReadDouble().ToString() + " ");
                    }

                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }



        //TRIRD
        private void buttonWrite3_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(path + name.Item3, FileMode.Create)))
                {
                    bw.Write(Int32.Parse(textCał3.Text));
                    bw.Write(double.Parse(textRze3.Text));
                    bw.Write(textNap3.Text);
                }
                textCał3.Text = "";
                textRze3.Text = "";
                textNap3.Text = "";
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void buttonRead3_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(path + name.Item3, FileMode.Open)))
                {
                    while (br.PeekChar() > -1)
                    {
                        textCał3.Text = br.ReadInt32().ToString();
                        textRze3.Text = br.ReadDouble().ToString();
                        textNap3.Text = br.ReadString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }


        private void buttonClear3_Click(object sender, EventArgs e)
        {
            textCał3.Text = "";
            textRze3.Text = "";
            textNap3.Text = "";
        }


        //FOURTH

        private void buttonWrite4_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(path + name.Item4, FileMode.Create)))
                {
                    bw.Write(textBoxName4.Text);
                    bw.Write(textBoxSecondname4.Text);
                    bw.Write(Int32.Parse(textBoxSize4.Text));
                    bw.Write(Double.Parse(textBoxWeight4.Text));
                    string data = dateTimePicker1.Text;
                    bw.Write(data);
                }
                textBoxName4.Text = "";
                textBoxSecondname4.Text = "";
                textBoxSize4.Text = "";
                textBoxWeight4.Text = "";
                dateTimePicker1.Text = null;
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void buttonRead4_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(path + name.Item4, FileMode.Open)))
                {
                    while (br.PeekChar() > -1)
                    {
                        textBoxName4.Text = br.ReadString();
                        textBoxSecondname4.Text = br.ReadString();
                        textBoxSize4.Text = br.ReadInt32().ToString();
                        textBoxWeight4.Text = br.ReadDouble().ToString();
                        string data = br.ReadString();
                        dateTimePicker1.Text = data;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void buttonClear4_Click(object sender, EventArgs e)
        {
            textBoxName4.Text = "";
            textBoxSecondname4.Text = "";
            textBoxSize4.Text = "";
            textBoxWeight4.Text = "";
            dateTimePicker1.Text = null;
        }

        //FIFTH

        private void buttonWrite5_Click(object sender, EventArgs e)
        {
            int index = 0;
            textBox5.Text += ' ';
            string s = null;
            try
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(path + name.Item5, FileMode.Create)))
                {
                    using (StreamWriter sw = new StreamWriter(@"F:\Visual Studio\OP\LAB7\Files\history.txt", false))
                    {
                        

                        foreach (char v in textBox5.Text)
                        {
                            if (v != ' ')
                            {
                                s += v;
                                if (v == ',')
                                {
                                    index = 1;
                                }
                            }
                            else
                            {
                                if (index == 0)
                                {
                                    bw.Write(int.Parse(s));
                                    sw.WriteLine("0");
                                }
                                else if (index == 1)
                                {
                                    bw.Write(Double.Parse(s));
                                    sw.WriteLine("1");
                                }
                                index = 0;
                                s = null;
                            }

                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void buttonRead5_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(path + name.Item5, FileMode.Open)))
                {
                    using (StreamReader sr = new StreamReader(@"F:\Visual Studio\OP\LAB7\Files\history.txt"))
                    {
                        while (br.PeekChar() > -1)
                        {
                            int index = Int32.Parse(sr.ReadLine());
                            if (index == 1)
                            {
                                textBox5.AppendText(br.ReadDouble().ToString() + " ");

                            }
                            else
                            {
                                textBox5.AppendText(br.ReadInt32().ToString() + " ");
                            }

                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }



        //SIXTH
        private void buttonAdd6_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(path + name.Item6, FileMode.Append)))
                {
                    bw.Write(textBoxName6.Text);
                    bw.Write(textBoxSecondname6.Text);
                    bw.Write(Int32.Parse(textBoxSize6.Text));
                    bw.Write(Double.Parse(textBoxWeight6.Text));
                    string data = dateTimePicker2.Text;
                    bw.Write(data);
                }
                textBoxName6.Text = "";
                textBoxSecondname6.Text = "";
                textBoxSize6.Text = "";
                textBoxWeight6.Text = "";
                dateTimePicker2.Text = null;
            }
            catch
            {
                MessageBox.Show("Error! Enter data.");
            }
        }

        private void buttonRead6_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(path + name.Item6, FileMode.Open)))
                {
                    while (br.PeekChar() > -1)
                    {
                        textBoxAll.Text += br.ReadString() + ", ";
                        textBoxAll.Text += br.ReadString() + ", ";
                        textBoxAll.Text += br.ReadInt32().ToString() + ", ";
                        textBoxAll.Text += br.ReadDouble().ToString() + ", ";
                        textBoxAll.Text += br.ReadString() + Environment.NewLine;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error! File is empty");
            }
        }

        private void buttonClear6_Click(object sender, EventArgs e)
        {
            textBoxAll.Text = "";
        }

        private void buttonDelete6_Click(object sender, EventArgs e)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream(path + name.Item6, FileMode.Create)))
            {
                
               
            }
        }



        private void textBox1_KeyPressInt(object sender, KeyPressEventArgs e)
        {
            char n = e.KeyChar;
            if (!Char.IsDigit(n) && n!= 32 && n!=8 && n!= 127)
            {
                e.Handled = true;
            }
        }

        
        private void textBox_KeyPressDouble(object sender, KeyPressEventArgs e)
        {
            char n = e.KeyChar;
            if (!Char.IsDigit(n) && n != 32 && n != 8 && n != 127 && n != 44)
            {
                e.Handled = true;
            }
        }

       
    }
}
