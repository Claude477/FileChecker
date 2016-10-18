namespace koe
{
    class Codes
    {
        internal static string doWork(string p)
        {
            return Codes.ReadTxtFile(p);
        }

        
        private static string ReadTxtFile(string FileName)
        {
            Codes.laskuri = 0;
            double total = 0;
            ushort SIZE = 2048;
            double summa = 0; bool sum = false;

            using (System.IO.Stream source = System.IO.File.OpenRead(FileName))
            {
                total = source.Length;
                byte[] buffer = new byte[SIZE]; int bytesRead;
                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0) { formatdata(buffer); }
            }
            //fast work loading buffer work then using formatdata check buffer empty spaces
            //wokring bigfiles too
            summa = (laskuri / total) * 100;
            if(summa > 50)sum = true;
            return " corrupted: " + sum;
            
        }

        //slow for loop

        private static void formatdata(byte[] data)//count bytes if has empty spaces file has corrupted
        {
            int i = 0;//fast for loop
            //System.Threading.Tasks.Parallel.For(0, data.Length, index =>
            //{

            //    if (data[index] == 0) laskuri++;

            //});
            for (i = 0; i != data.Length; )
            {
                if (data[i++] == 0) laskuri++;
                if (data[i++] == 0) laskuri++;
                if (data[i++] == 0) laskuri++;
                if (data[i++] == 0) laskuri++;
            }
            //for (int i = 0, len = data.Length - 1; i < len; i++){                if (data[i++] == 0) laskuri++;            }
        }
        public static int laskuri { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DropImage(object sender, System.Windows.DragEventArgs e)
        {
            System.Array a = (System.Array)e.Data.GetData(System.Windows.DataFormats.FileDrop);//get all object what dropped in filedrop box
            foreach (var item in a)
            {
                listBox1.Items.Add(item + ":" + Codes.doWork(item.ToString()));
            }
        }
    }
}

