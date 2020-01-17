using System;
using System.Windows;

namespace Joe_Automotive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;

            chkOilChange.Content = chkOilChange.Content + "($" + VM.OIL_CHARGES + ")";
            chkLubeChange.Content = chkLubeChange.Content + "($" + VM.LUBE_CHARGES +")";
            chkRadiatorFlush.Content = chkRadiatorFlush.Content + "($" + VM.RADIATOR_CHARGES + ")";
            chkTransFlush.Content = chkTransFlush.Content + "($" + VM.TRANSMISSION_CHARGES + ")";
            chkTireRotation.Content = chkTireRotation.Content + "($" + VM.TIRE_CHARGES + ")";
            chkInspection.Content = chkInspection.Content + "($" + VM.INSPECTION_CHARGES + ")";
            chkMufflerChange.Content = chkMufflerChange.Content + "($" + VM.MUFFLER_CHARGES + ")";
            lblhours.Content = lblhours.Content + "($" + VM.LABOR_CHARGES + ")";
            lblTax.Content = lblTax.Content + "(" + Math.Round(VM.TAX_RATE*100) + "%)";
        }


        private void btnGetCost_Click(object sender, RoutedEventArgs e)
        {
            vm.Calculate();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            vm.ClearAll();
        }
    }
}
