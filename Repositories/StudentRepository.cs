using SQLite;
using Test_SQlite_Memory_Maui.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_SQlite_Memory_Maui.Repositories
{
    public class StudentRepository
    {
        SQLiteConnection connection;
        public string? statusMessage {  get; set; }
        public StudentRepository()
        {
            connection = new SQLiteConnection(
                Constants.DatabasePath,
                Constants.flags);
            connection.CreateTable<Student>();
        }

        #region DataMethods

        /// <summary>
        /// Add a new student to the database or Update an existing student
        /// </summary>
        /// <param name="newStudent"></param>
        public void AddOrUpdate(Student student)
        {
            int result = 0;
            try
            {
                if(student.Id != 0)
                {
                    result = connection.Update(student);
                    statusMessage = $"{result} row(s) updated";
                }
                else
                {
                    result = connection.Insert(student);
                    statusMessage = $"{result} row(s) added";
                }
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }

        /// <summary>
        /// Get a list of all students
        /// </summary>
        /// <returns></returns>
        public List<Student>? GetAll()
        {
            try
            {
                return connection.Table<Student>().ToList();
                // SQL Query kan ook:
                // return connection.Query<Student>("SELECT * FROM Students").ToList();
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        /// <summary>
        /// Get a student by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student? GetStudent(int id)
        {
            try
            {
                return connection.Table<Student>().FirstOrDefault(x => x.Id == id);
            }
            catch(Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        /// <summary>
        /// Delete a student by ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                Student student = GetStudent(id);
                connection.Delete(student);
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }

        #endregion

    }
}
