using System.Text.Json;
using System.Collections.ObjectModel;
using _3dPrintManager.Models;

namespace _3dPrintManager;

public partial class MainPage : ContentPage
{
    public List<EnclosureModule> enclosureModules;

    private ObservableCollection<EnclosureModuleStatusDto> _enclosureModuleStatusDtos =
        new ObservableCollection<EnclosureModuleStatusDto>();

    public ObservableCollection<EnclosureModuleStatusDto> EnclosureModuleStatusDtos
    {
        get => _enclosureModuleStatusDtos;
        set { _enclosureModuleStatusDtos = value; OnPropertyChanged(); }
    }

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // todo: load ModuleData from db
        enclosureModules = [new EnclosureModule() { Ip = "http://192.168.31.73", EnclosedPrinterModel = "Bambu Lab A1"}, new EnclosureModule() { Ip = "http://192.168.31.73", EnclosedPrinterModel = "Creality CR 10 SE"}];
        DataLabel.Text = "testing 2";
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            if (EnclosureModuleStatusDtos == null)
                EnclosureModuleStatusDtos = new ObservableCollection<EnclosureModuleStatusDto>();

            EnclosureModuleStatusDtos.Clear();

            using var httpClient = new HttpClient();
            foreach (var module in enclosureModules)
            {
                try
                {
                    var response = await httpClient.GetStringAsync(module.Ip);
                    Console.WriteLine(response);
                    DataLabel.Text = response; // or DataLabel.Text += response + "\n";
                    var data = JsonSerializer.Deserialize<EnclosureModuleStatusDto>(response);
                    if (data != null)
                    {
                        EnclosureModuleStatusDtos.Add(data);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching from {module.Ip}: {ex.Message}");
                    DataLabel.Text = $"Error: {ex.Message}";
                }
            }
        }
        catch (Exception ex)
        {
            DataLabel.Text = $"General error: {ex.Message}";
        }
    }
 
    // private async void OnFanToggled(object? sender, EventArgs e)
    // {
    //     if (_isInitializing) return;
    //     _fanOn = !_fanOn;
    //     using var httpClient = new HttpClient();
    //     var request = $"{baseUrl}/fan-relay?on={_fanOn.ToString().ToLower()}";
    //     var response = await httpClient.GetStringAsync(request);
    // }
    
    // private async void OnLedToggled(object? sender, EventArgs e)
    // {
    //     if (_isInitializing) return;
    //     _ledOn = !_ledOn;
    //     using var httpClient = new HttpClient();
    //     var request = $"{baseUrl}/led-relay?on={_ledOn.ToString().ToLower()}";
    //     var response = await httpClient.GetStringAsync(request);
    // }
}
