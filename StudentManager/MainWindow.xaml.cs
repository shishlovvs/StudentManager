using Microsoft.EntityFrameworkCore;
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

namespace StudentManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
           await using var db = new AppDbContext();
           await db.Database.EnsureCreatedAsync(); //Проверяет, есть ли таблица в БД7
            db.Students.AddAsync(new Student() { 
                Name = "Иммануил Кант", 
                Birthday = DateTime.Now 
            });
            db.Students.AddAsync(new Student()
            {
                Name = "Лев Толстой",
                Birthday = DateTime.Today.AddDays(-1)
            });
            await db.SaveChangesAsync();

            var students = await db.Students.ToListAsync();
            studentsDataGrid.ItemsSource = students;
        }
    }
}
