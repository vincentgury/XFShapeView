using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFShapeView;

namespace XFShapeViewSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxPage : ContentPage
    {
        public BoxPage()
        {
            InitializeComponent();
        }

        public void OnMinusTapped(object sender, EventArgs e)
        {
            var counter = (Convert.ToInt32(this.Counter.Text) - 1);
            if (counter < 0) counter = 101 + counter;
            this.Counter.Text = counter.ToString();
        }

        public void OnPlusTapped(object sender, EventArgs e)
        {
            var counter = (Convert.ToInt32(this.Counter.Text) + 1) % 101;
            this.Counter.Text = counter.ToString();
        }

        public void OnNumberTapped(object sender, EventArgs e)
        {
            this.SetCounter(((Label)((ShapeView)sender).Content).Text);
        }

        private void SetCounter(string number)
        {
            var text = string.IsNullOrEmpty(this.Counter.Text) ? "0" : this.Counter.Text;
            this.Counter.Text = Convert.ToInt32(text[this.Counter.Text.Length - 1] + number).ToString();
        }
    }
}