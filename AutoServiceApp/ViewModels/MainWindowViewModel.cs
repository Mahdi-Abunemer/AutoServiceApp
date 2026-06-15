using AutoServiceApp.Services;

namespace AutoServiceApp.ViewModels;

public class MainWindowViewModel
{
    public AutoServiceManager Manager { get; } = new();
    public string Title { get; } = "Auto Service";
}
