using SandrasBookingSystem.Models;
using SandrasBookingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace SandrasBookingSystem.Commands
{
    public class RegisterCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result = true;
            return result;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                //if (mvm.RadioButtonFreelancer.IsChecked == true)
                var a = mvm.RadioFreelancer.IsChecked;

                {
                    if (string.IsNullOrEmpty(mvm.FirstName) || string.IsNullOrEmpty(mvm.LastName)
                                || string.IsNullOrEmpty(mvm.Email) ||
                                string.IsNullOrEmpty(mvm.Password) || string.IsNullOrEmpty(mvm.PhoneNumber))
                    {
                        MessageBox.Show("Alle felter skal udfyldes.");
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter("..\\..\\..\\Freelancers.txt", true);
                        sw.Write($"{mvm.FirstName}" + ", ");
                        sw.Write($"{mvm.LastName}" + ", ");
                        sw.Write($"{mvm.Email}" + ", ");
                        sw.Write($"{mvm.PhoneNumber}" + ", ");
                        sw.Write($"{mvm.Password}");
                        sw.WriteLine("");
                        sw.Close();
                        MessageBox.Show("Du er blevet registreret.");

                    }
                    //}
                    //else if (mvm.RadioButtonAgency.IsChecked == false)
                    //{
                    //    if (string.IsNullOrEmpty(mvm.FirstName) || string.IsNullOrEmpty(mvm.LastName)
                    //                || string.IsNullOrEmpty(mvm.Email) ||
                    //                string.IsNullOrEmpty(mvm.Password) || string.IsNullOrEmpty(mvm.PhoneNumber))
                    //    {
                    //        MessageBox.Show("Alle felter skal udfyldes.");
                    //    }
                    //    else
                    //    {
                    //        StreamWriter sw = new StreamWriter("..\\..\\..\\Agencies.txt", true);
                    //        sw.Write($"{mvm.FirstName}" + ", ");
                    //        sw.Write($"{mvm.LastName}" + ", ");
                    //        sw.Write($"{mvm.Email}" + ", ");
                    //        sw.Write($"{mvm.PhoneNumber}" + ", ");
                    //        sw.Write($"{mvm.Password}");
                    //        sw.WriteLine("");
                    //        sw.Close();
                    //        MessageBox.Show("Du er blevet registreret.");
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Angiv om du er freelancer eller bureauansat.");
                    //}
                }

            }
        }
    }
}