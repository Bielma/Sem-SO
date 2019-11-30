using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem_SO
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        WebClient webClient = new WebClient();
        string destino = "";
        
        //http://download2260.mediafire.com/w0m0lh4dywqg/7rbn5ih73upm43b/Heathens.mp3
        private void Button1_Click(object sender, EventArgs e)
        {

            string url = txtURL.Text;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Todos los archivos|*.*";
            dialog.FileName = txtURL.Text.Substring(txtURL.Text.LastIndexOf("/") + 1);
            
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                destino = dialog.FileName;
                webClient.DownloadFileAsync(new Uri(url), destino);
            }                                                          
        }
        
        private void descargando(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void descardescargaCompletada(object sender, AsyncCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            
            System.Diagnostics.Process.Start(destino);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(descargando);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(descardescargaCompletada);
        }
    }
}
