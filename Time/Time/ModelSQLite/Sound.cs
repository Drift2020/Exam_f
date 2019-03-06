using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.View_model;

namespace Time.ModelSQLite
{
    public class Sound : View_Model_Base
    {
        private string path;
        private string name;
        public int Id { get; set; }
        public string Path
        {
            set
            {
                path = value;
                OnPropertyChanged(nameof(Path));

            }
            get
            {
                return path;
            }
        }

        public string Name
        {
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));

            }
            get
            {
                return name;
            }
        }
    }
}
