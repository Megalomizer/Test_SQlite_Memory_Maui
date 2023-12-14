using Test_SQlite_Memory_Maui.MVVM.ViewModels;
namespace Test_SQlite_Memory_Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }

}
