using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCCLibrary
{

    public class FirstCC : ContentControl
    {
        private const string PART_tb = "PART_tb";
        private const string PART_btn = "PART_btn";

        private Button btnTest;
        protected Button BtnTest

        {
            get => btnTest;
            set
            {
                if (btnTest != null)
                {
                    btnTest.Click -= btn_Click;
                }

                btnTest = GetTemplateChild(nameof(PART_btn)) as Button;

                if (btnTest!=null)
                {
                    btnTest.Click += btn_Click;
                }

            }
        }





        public Brush InnerBorder
        {
            get { return (Brush)GetValue(InnerBorderProperty); }
            set { SetValue(InnerBorderProperty, value); }
        }
        public static readonly DependencyProperty InnerBorderProperty =
            DependencyProperty.Register("InnerBorder", typeof(Brush), typeof(FirstCC), new PropertyMetadata(Brushes.Black));



        static FirstCC()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FirstCC), new FrameworkPropertyMetadata(typeof(FirstCC)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            BtnTest = GetTemplateChild(nameof(PART_btn)) as Button;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (!(GetTemplateChild(nameof(PART_tb)) is TextBlock tb))
            {
                return;
            }
            tb.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
