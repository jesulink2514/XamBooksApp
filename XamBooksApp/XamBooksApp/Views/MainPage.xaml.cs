using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamBooksApp.Views
{
    public partial class MainPage : ContentPage
    {
        private Animation _animation;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var startValue = 0;
            var desiredValue = 0.6;

            if (_animation != null)
            {
                ProgressBar.AbortAnimation("Percentage");
            }

            _animation = new Animation(v =>
                {
                    if (v == 0)
                    {
                        ProgressBar.Percentage = 0;
                        return;
                    }

                    ProgressBar.Percentage = (float) (v / 100);
                }, startValue, desiredValue * 100, easing: Easing.SinInOut);

            _animation.Commit(ProgressBar, "Percentage", length: 2000,
                finished: (l, c) => { _animation = null; });
        }
    }
}