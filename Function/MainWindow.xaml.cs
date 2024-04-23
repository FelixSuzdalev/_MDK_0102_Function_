using System;
using System.Windows;

namespace Function
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            Time();
        }
        private void Time()
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, e) =>
            {
                Date.Text = DateTime.Now.ToString();
            };
            timer.Start();
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            Main();
        }

        private void Main()
        {
            double a = -10;
            double b = 10;

            double step = Convert.ToDouble(Step.Text);

            while (!double.TryParse(Step.Text, out step) || step <= 0)
            {
                Output.Text = "Ошибка! Введите корректное положительное значение шага.";
                return ;
            }

            if (step > 10 || step < -10)
            {
                Output.Text = "Ошибка! Шаг не может быть больше значения интервала [-10; 10].";
                return;
            }

            double max = double.MinValue;
            double min = double.MaxValue;

            try
            {
                for (double x = a; x <= b; x += step)
                {
                    double y = Function(x);
                    double z = y;
                    if (y > max)
                    {
                        max = y;
                    }

                    if (z < min)
                    {
                        min = z;
                    }
                }

                Output.Text = $"Максимальное значение функции: {max:f2} \nМинимальное значение функции: {min:f2} ";
            }
            catch (OverflowException)
            {
                Output.Text = "Ошибка! Произошло переполнение значения переменной результата.";
            }
        }

        private static double Function(double x)
        {
            return x * x - Math.Sin(3 * x) - 3;
        }
    }
}

