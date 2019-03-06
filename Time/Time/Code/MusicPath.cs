using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Time.Code
{
    class MusicPath
    {
        static  MusicPath()
        {
            wmp = new WindowsMediaPlayer();
        }
        static WindowsMediaPlayer wmp;
        public static List<string> Get_Paths()
        {

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;

                return Directory.GetFiles(folderName, "*.mp3", SearchOption.TopDirectoryOnly).ToList();
       

            }

            return null;
        }


        public static void Play(string path, int? i)
        {
            Stop();
            if (path != null)
            {

                wmp.URL = path;
                if (i != null)
                    wmp.settings.volume = Convert.ToInt32(i);
                wmp.controls.play();
            }
            
        }

        public static void Volume(int? i)
        {
          
            
                if (i != null)
                    wmp.settings.volume = Convert.ToInt32(i);
               
         

        }


        public static void Stop()
        {
        
            wmp.controls.stop();

        }

      


    }
}
