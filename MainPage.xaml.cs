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
        enclosureModules = [new EnclosureModule() { Ip = "http://192.168.31.73", EnclosedPrinterModel = "Bambu Lab A1"}, new EnclosureModule() { Ip = "http://192.168.31.147", EnclosedPrinterModel = "Creality CR 10 SE"}];
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
                    var data = JsonSerializer.Deserialize<EnclosureModuleStatusDto>(response);
                    if (data != null)
                    {
                        data.Ip = module.Ip;
                        EnclosureModuleStatusDtos.Add(data);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching from {module.Ip}: {ex.Message}");
                    DataLabel.Text = $"Error: {ex.Message}";
                }
            }
            DataLabel.Text = "";
        }
        catch (Exception ex)
        {
            DataLabel.Text = $"General error: {ex.Message}";
        }
    }
}
