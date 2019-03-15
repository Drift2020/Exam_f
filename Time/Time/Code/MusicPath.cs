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
        public MusicPath()
        {
            wmp = new WindowsMediaPlayer();
        }
        WindowsMediaPlayer wmp;

        public bool isPlay()
        {
           
            switch (wmp.playState)
            {
                case WMPPlayState.wmppsPlaying:
                    return true;
                case WMPPlayState.wmppsUndefined:
                case WMPPlayState.wmppsStopped:
                    return false;
            }
            return true;
        }

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


        public  void Play(string path, int? i)
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

        public  void Volume(int? i)
        {
          
            
                if (i != null)
                    wmp.settings.volume = Convert.ToInt32(i);
               
         

        }


        public  void Stop()
        {
        
            wmp.controls.stop();

        }

      


    }
}
