using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace WPF.MarkupExtensions
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window 
    {
        public List<Person> People { get; set; }

        Action<int, int, string> act;
        public Window2()
        {
            InitializeComponent();
            DataContext = this;

            People = new List<Person>() {
                new Person(){Id=1,Name= "Marcus",City= "New York" },
                 new Person(){Id=2,Name= "Ove",City= "Stockholm" },
                  new Person(){Id=3,Name= "Jaidi",City= "Bangkok" }
            };

            act = new Action<int, int, string>(Something);
            act(3, 5, "shit");
        }
        bool showMe;
        public bool ShowMe { get=> showMe;
            set { showMe = value; }
        }



        public bool ShowMeDP
        {
            get { return (bool)GetValue(ShowMeDPProperty); }
            set { SetValue(ShowMeDPProperty, value); }
        }

         public static readonly DependencyProperty ShowMeDPProperty =
            DependencyProperty.Register("ShowMeDP", typeof(bool), typeof(Window2), new PropertyMetadata(false));

        public void Something(int one, int two, string v) {

            
            Debug.WriteLine($"HERERE  {one} and{two} for {v}");
         
    }
    }
}
