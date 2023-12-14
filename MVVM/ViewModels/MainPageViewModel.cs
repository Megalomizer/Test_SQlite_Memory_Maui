using PropertyChanged;
using System.Windows.Input;
using Bogus;
using Test_SQlite_Memory_Maui.MVVM.Models;

namespace Test_SQlite_Memory_Maui.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public List<Student> Students {  get; set; }
        public Student? CurrentStudent { get; set; }
        public ICommand? AddOrUpdateCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }
        
        public MainPageViewModel()
        {
            Refresh();
            GenerateNewStudent();

            AddOrUpdateCommand = new Command(async () =>
            {
                App.StudentRepository.AddOrUpdate(CurrentStudent);
                Console.WriteLine(App.StudentRepository.statusMessage);
                GenerateNewStudent();
                Refresh();
            });

            DeleteCommand = new Command(async () =>
            {
                App.StudentRepository.Delete(CurrentStudent.Id);
                Refresh();
                GenerateNewStudent();
            });
        }

        private void GenerateNewStudent()
        {
            CurrentStudent = new Faker<Student>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Address, f => f.Person.Address.Street)
                .Generate();
        }

        private void Refresh()
        {
            Students = App.StudentRepository.GetAll();
        }
    }
}
