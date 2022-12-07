using SandrasBookingSystem.Models;
using SandrasBookingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SandrasBookingSystem.Commands
{
    public class DeleteBookingCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result = true;
            if (parameter is MainViewModel mvm)
            {
                if (mvm.SelectedBooking == null)
                    result = false;
            }
            CommandManager.InvalidateRequerySuggested();
            return result;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                string ConfirmPassword = mvm.ConfirmPassword;

                StreamReader sr = new StreamReader("..\\..\\..\\Freelancers.txt");
                string newDocument = sr.ReadToEnd();
                sr.Close();

                if (newDocument.Contains(ConfirmPassword))
                {
                    var oldLines = System.IO.File.ReadAllLines("..\\..\\..\\Freelancers.txt");
                    var newLines = oldLines.Where(line => !line.Contains(ConfirmPassword));
                    System.IO.File.WriteAllLines("..\\..\\..\\Freelancers.txt", newLines);
                    MessageBox.Show("Din profil er blevet slettet.");
                }
                else
                {
                    MessageBox.Show("Forkert adgangskode.");
                }
            }
        }

    }
}


