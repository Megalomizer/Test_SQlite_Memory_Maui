using Test_SQlite_Memory_Maui.Repositories;

namespace Test_SQlite_Memory_Maui
{
    public partial class App : Application
    {
        public static StudentRepository? StudentRepository {  get; private set; }

        public App(StudentRepository studentRepository)
        {
            InitializeComponent();

            StudentRepository = studentRepository;
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
