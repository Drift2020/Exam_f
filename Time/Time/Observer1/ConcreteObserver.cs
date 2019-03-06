//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Time.Code;

//namespace Time.Observer1
//{
//    class ConcreteObserver : Observer
//    {
//        private List<My_grean_site> subject;
//        private Convert_Key my_Convert_Key;

//        bool isActiv = false;

//        // Constructor
//        public ConcreteObserver(Convert_Key my_Convert_Key, List<My_grean_site> subject)
//        {
//            this.subject = subject;

//            this.my_Convert_Key = my_Convert_Key;
            
//        }

//        public override void Update(string i)
//        {
//            subject.ForEach(elem => {
//                if (elem.IsActiv)
//                    my_b.Location = new System.Drawing.Point(my_b.Location.X + elem.X,
//                        my_b.Location.Y + elem.Y);

//            });

//        }

      

//        public List<My_grean_site> Subject
//        {
//            get { return subject; }
//            set { subject = value; }
//        }
//    }
//}
