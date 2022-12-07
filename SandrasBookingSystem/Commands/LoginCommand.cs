using SandrasBookingSystem.Models;
using SandrasBookingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace SandrasBookingSystem.Commands
{
    public class LoginCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            bool result = true;
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                if (string.IsNullOrEmpty(mvm.LoginEmail) || string.IsNullOrEmpty(mvm.LoginPassword))
                {
                    MessageBox.Show("Alle felter skal udfyldes.");

                }
                else
                {
                    Freelancer user = new Freelancer("", "", "", "", "");
                    user.Email = mvm.LoginEmail;
                    user.Password = mvm.LoginPassword;

                    string UserEmail = user.Email;
                    string UserPassword = user.Password;

                    StreamReader sr = new StreamReader("..\\..\\..\\Freelancers.txt");
                    string newDocument = sr.ReadToEnd(); // læser dokumentet
                    sr.Close(); // Lukker dokumentet igen

                    if (newDocument.Contains(UserEmail) && newDocument.Contains(UserPassword))
                    {
                        var oldLines = File.ReadAllLines("..\\..\\..\\Freelancers.txt");
                     
                        MessageBox.Show("Du er logget ind.");

                        string line;

                        System.IO.StreamReader file =
                            new System.IO.StreamReader("..\\..\\..\\Freelancers.txt");
                        while ((line = file.ReadLine()) != null)
                        {
                            string[] word = line.Split(',');
                            mvm.Freelancers.Add(new Freelancer(word[0], word[1], word[2], word[3], word[4]));

                        }
                        file.Close();

                        string line1;

                        System.IO.StreamReader file1 =
                            new System.IO.StreamReader("..\\..\\..\\Bookings.txt");
                        while ((line1 = file1.ReadLine()) != null)
                        {
                            string[] word = line1.Split(',');
                            mvm.Bookings.Add(new Booking(DateTime.Parse(word[0]), word[1], word[2], word[3], word[4], word[5], word[6]));

                        }
                        file1.Close();

                    }
                    else
                    {
                        MessageBox.Show("Forkert email eller password.");
                    }
                }
            }
               
        }
    }
}
