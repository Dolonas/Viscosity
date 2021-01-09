using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace Viscosity_WPF
{
    public enum visKUnit : byte { St, sSt, m2sec, mm2sec, inch2sec, ft2sec };
    public enum visDUnit : byte { paSec, P, sP, mm2_s, funt_ft_s, rein };

    public partial class MainWindow : Window
    {
        internal string sourceString = "0";
        internal string outputString = "0";
        internal double sourceValue = 1;
        internal double outputValue = 0;
        public string prevvalue = "";
        public int prevselectionstart = 0;
        public int prevselectionend = 0;

        private Dictionary<int, string> kinematicUnits = new Dictionary<int,string>
        {
            {1, "Ст" },
            {2, "cСт" },
            {3, "м\u00B2/с" },
            {4, "мм\u00B2/с" },
            {5, "дюйм\u00B2/с" },
            {6, "фут\u00B2/с" }
        };
        private Dictionary<int, string> dynamicUnits = new Dictionary<int, string>
        {
            {1, "Па\u00B7с" },
            {2, "Пуаз" },
            {3, "сП" },
            {4, "мм\u00B2/с" },
            {5, "фунт/фут\u00B7с" },
            {6, "Рейн" }
        };
        private Dictionary<int, string> densityUnits = new Dictionary<int, string> 
        {
            {1, "кг/м\u00B3" },
            {2, "г/см\u00B3" }
        };
        
        public MainWindow()
        {
            InitializeComponent();

            SourceValue.Text = sourceValue.ToString();
            OutPutValue.Text = outputValue.ToString();

            SourceUnit.ItemsSource = kinematicUnits;
            SourceUnit.SelectedValuePath = "Key";
            SourceUnit.DisplayMemberPath = "Value";

            OutPutUnit.ItemsSource = kinematicUnits;
            OutPutUnit.SelectedValuePath = "Key";
            OutPutUnit.DisplayMemberPath = "Value";

            DensityUnit.ItemsSource = densityUnits;
            DensityUnit.SelectedValuePath = "Key";
            DensityUnit.DisplayMemberPath = "Value";


            SourceUnit.SelectedIndex = 0;
            OutPutUnit.SelectedIndex = 1;
            DensityUnit.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void SourceValue_Changed(object sender, RoutedEventArgs e)
        {
            var t = (TextBox)sender;

            if (t.Text == "")
            {
                t.Text = "0";
                prevselectionstart = 1;
                prevselectionend = 1;
                t.Select(prevselectionstart, prevselectionend);
            }
            // Сюда положим распарсенное число
            else if (double.TryParse(t.Text, out double number) && number >= 0 && number <= 1)
            {
                prevvalue = t.Text;
                prevselectionstart = t.SelectionStart;
                prevselectionend = t.SelectionLength;
            }
            else
            {
                var savedselectionstart = prevselectionstart; // Сохранение правильных границ select
                var savedselectionend = prevselectionend;
                t.Text = prevvalue; // В WPF в момент записи нового текста обнуляются границы select

                prevselectionstart = savedselectionstart; // Восстановление границ select
                prevselectionend = savedselectionend;
                t.Select(prevselectionstart, prevselectionend);
            }

        }

        private void SourceKinematicMode_Checked(object sender, RoutedEventArgs e)
        {
            if (SourceUnit != null)
            {
                RadioButton radioKinChecked = (RadioButton)sender;
                radioKinChecked.FontWeight = FontWeights.DemiBold;
                RadioButton radioDinUncheked = radioSourseDinamicBotton;
                radioDinUncheked.FontWeight = FontWeights.Normal;
                SourceUnit.ItemsSource = null;
                SourceUnit.ItemsSource = kinematicUnits;
                SourceUnit.SelectedIndex = 0;

            }
                
        }

        private void SourceDinamicMode_Checked(object sender, RoutedEventArgs e)
        {
            if (SourceUnit != null)
            {
                RadioButton radioDinChecked = (RadioButton)sender;
                radioDinChecked.FontWeight = FontWeights.DemiBold;
                RadioButton radioKinUncheked = radioSourseKinematicBotton;
                radioKinUncheked.FontWeight = FontWeights.Normal;
                SourceUnit.ItemsSource = null;
                SourceUnit.ItemsSource = dynamicUnits;
                SourceUnit.SelectedIndex = 0;
            }
                
        }

        private void OutputKinematicMode_Checked(object sender, RoutedEventArgs e)
        {
            if (OutPutUnit != null)
            {
                RadioButton radioKinChecked = (RadioButton)sender;
                radioKinChecked.FontWeight = FontWeights.DemiBold;
                RadioButton radioDinUncheked = radioOutputDinamicBotton;
                radioDinUncheked.FontWeight = FontWeights.Normal;
                OutPutUnit.ItemsSource = null;
                OutPutUnit.ItemsSource = kinematicUnits;
                OutPutUnit.SelectedIndex = 1;
            }
                
        }

        private void OutputDinamicMode_Checked(object sender, RoutedEventArgs e)
        {
            if (OutPutUnit != null)
            {
                RadioButton radioDinChecked = (RadioButton)sender;
                radioDinChecked.FontWeight = FontWeights.DemiBold;
                RadioButton radioKinUncheked = radioOutputKinematicBotton;
                radioKinUncheked.FontWeight = FontWeights.Normal;
                OutPutUnit.ItemsSource = null;
                OutPutUnit.ItemsSource = dynamicUnits;
                OutPutUnit.SelectedIndex = 1;
            }
               
        }
    }
}
