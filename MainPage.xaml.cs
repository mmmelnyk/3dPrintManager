using System.Text.Json;
using _3dPrintManager.Models;

namespace _3dPrintManager;

public partial class MainPage : ContentPage
{
    private bool _fanOn = false;
    private bool _ledOn = false;
    private bool _isInitializing = false;

    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://192.168.31.89");
            Console.WriteLine(response);
            var data = JsonSerializer.Deserialize<ModuleData>(response);
            if (data != null)
            {
                _fanOn = data.FanOn;
                _ledOn = data.LedOn;
                _isInitializing = true;
                FanSwitch.IsToggled = data.FanOn;
                LedSwitch.IsToggled = data.LedOn;
                _isInitializing = false;
                DataLabel.Text = $"Printer: {data.ModuleName} \nTemperature: {data.Temperature}°C\nHumidity: {data.Humidity}%";
            }
            else
                DataLabel.Text = "Failed to parse data.";
        }
        catch (Exception ex)
        {
            DataLabel.Text = $"Error: {ex.Message}";
        }
    }

    private async void OnFanToggled(object? sender, EventArgs e)
    {
        if (_isInitializing) return;
        _fanOn = !_fanOn;
        using var httpClient = new HttpClient();
        var request = $"http://192.168.31.89/fan-relay?on={_fanOn.ToString().ToLower()}";
        var response = await httpClient.GetStringAsync(request);
    }
    
    private async void OnLedToggled(object? sender, EventArgs e)
    {
        if (_isInitializing) return;
        _ledOn = !_ledOn;
        using var httpClient = new HttpClient();
        var request = $"http://192.168.31.89/led-relay?on={_ledOn.ToString().ToLower()}";
        var response = await httpClient.GetStringAsync(request);
    }
}
