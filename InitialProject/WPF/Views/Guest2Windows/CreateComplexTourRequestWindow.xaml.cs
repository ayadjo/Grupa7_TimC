using InitialProject.WPF.ViewModels;
using InitialProject.WPF.ViewModels.Guest2ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InitialProject.WPF.Views.Guest2Windows
{
    /// <summary>
    /// Interaction logic for CreateComplexTourRequest.xaml
    /// </summary>
    public partial class CreateComplexTourRequestWindow : Window
    {
        public CreateComplexTourRequestViewModel createComplexTourRequestViewModel;


        public CreateComplexTourRequestWindow(MyTourRequestsViewModel model)
        {
            InitializeComponent();
            createComplexTourRequestViewModel = new CreateComplexTourRequestViewModel(model);
            this.DataContext = createComplexTourRequestViewModel;

            if (DataContext is IClose vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }


        private void LanguageComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LanguageComboBox.SelectedIndex == 0)
            {
                createComplexTourRequestViewModel.Language = "srpski";
            }
            else if (LanguageComboBox.SelectedIndex == 1)
            {
                createComplexTourRequestViewModel.Language = "engleski";
            }
            else if (LanguageComboBox.SelectedIndex == 2)
            {
                createComplexTourRequestViewModel.Language = "italijanski";
            }
            else if (LanguageComboBox.SelectedIndex == 3)
            {
                createComplexTourRequestViewModel.Language = "korejski";
            }
            else if (LanguageComboBox.SelectedIndex == 4)
            {
                createComplexTourRequestViewModel.Language = "japanski";
            }


        }
        
    }
}
