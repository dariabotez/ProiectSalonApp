using System;
using Microsoft.Maui.Controls;
using System.IO;
using ProiectSalonApp.Data;
using System.Threading.Tasks;

namespace ProiectSalonApp
{
    public partial class App : Application
    {
        static SalonServicesDatabase database;

        public static SalonServicesDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SalonServicesDatabase(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Services.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            // Subscribe to unhandled exception events
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;

            MainPage = new AppShell();
        }

        // Handle unhandled exceptions for the AppDomain
        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Log the exception, e.ExceptionObject is an object, you may want to cast it to an Exception type
            Exception ex = e.ExceptionObject as Exception;
            LogException(ex);
        }

        // Handle unhandled task exceptions
        private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            // Log the exception
            LogException(e.Exception);
            // Mark the exception as observed to prevent the app from being terminated
            e.SetObserved();
        }

        // Utility method for logging exceptions
        private void LogException(Exception ex)
        {
            // Implement your logging logic here
            // For example, you might log to a file, send to a logging service, etc.
            Console.WriteLine(ex.ToString());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
