using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SharedLibrary;
using SharedLibrary.Features.PokeApi.Pages;

namespace BlazorWinFormsHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeWebView();   
        }

        private void InitializeWebView()
        {
            var services = new ServiceCollection();

            services.AddLogging();
            services.AddSingleton<IConfiguration>(new ConfigurationBuilder().Build());
            services.AddWindowsFormsBlazorWebView();
            services.AddSharedStuff();

            var view = new BlazorWebView()
            {
                Dock = DockStyle.Fill,
                HostPage = @"wwwroot\index.html",
                Services = services.BuildServiceProvider(),
            };

            view.RootComponents.Add<App>("#app");
            Controls.Add(view);
        }
    }
}