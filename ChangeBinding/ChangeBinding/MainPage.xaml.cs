using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChangeBinding
{
	public partial class MainPage : ContentPage
	{
        private bool _here;
        public bool Here
        {
            get { return _here; }
            set { _here = value; }
        }

        private bool _luck;

        public bool Luck
        {
            get { return _luck; }
            set { _luck = value; }
        }

        public void OnToggle(object sender, EventArgs e)
        {
            if (testSwitcher.IsToggled == true)
            {
                Luck = false;
                var dataTemplate = new DataTemplate(() =>
                {
                    return CreateViewCell(Luck);
                });

                myListView.ItemsSource = test;
                myListView.ItemTemplate = dataTemplate;
            }
            else
            {
                
                var dataTemplate = new DataTemplate(() =>
                {
                    return CreateViewCell(Here);
                });

                myListView.ItemsSource = test;
                myListView.ItemTemplate = dataTemplate;
            }
        }

        List<Test> test;
        public MainPage()
		{
			InitializeComponent();
            test = new List<Test>
        {
            new Test { Text = "this is a test 1 "},
            new Test { Text = "this is a test 2 "},
            new Test { Text = "this is a test 3 "},
          
        };
          
            Here = true;
          var dataTemplate = new DataTemplate(() =>
           {
               return CreateViewCell(Here);
           });

            myListView.ItemsSource = test;
            myListView.ItemTemplate = dataTemplate;
           
           
		}
      
        public ViewCell CreateViewCell(object o)
        {
          
            var viewCell = new ViewCell();
            var stack = new StackLayout { };
            Binding myBinding = new Binding();
            myBinding.Source = o;
            stack.SetBinding(IsVisibleProperty,myBinding);

            var label = new Label {};
            label.SetBinding(Label.TextProperty, "Text");
            stack.Children.Add(label);
            viewCell.View = stack;
         
            return viewCell;

        }
	}
}
