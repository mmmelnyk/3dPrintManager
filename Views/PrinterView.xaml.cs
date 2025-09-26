namespace _3dPrintManager.Views
{
    public partial class PrinterView : ContentView
    {
        public static readonly BindableProperty ModuleNameProperty = BindableProperty.Create(nameof(ModuleName), typeof(string), typeof(PrinterView), string.Empty);
        public static readonly BindableProperty EnclosureTemperatureProperty = BindableProperty.Create(nameof(EnclosureTemperature), typeof(string), typeof(PrinterView), string.Empty);
        public static readonly BindableProperty EnclosureHumidityProperty = BindableProperty.Create(nameof(EnclosureHumidity), typeof(string), typeof(PrinterView), string.Empty);
        public static readonly BindableProperty FanOnProperty = BindableProperty.Create(nameof(FanOn), typeof(bool), typeof(PrinterView), false);
        public static readonly BindableProperty LedOnProperty = BindableProperty.Create(nameof(LedOn), typeof(bool), typeof(PrinterView), false);
        public static readonly BindableProperty IpProperty = BindableProperty.Create(nameof(Ip), typeof(string), typeof(PrinterView), string.Empty);

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            nameof(BorderColor),
            typeof(Color),
            typeof(PrinterView),
            Colors.Transparent);

        public static readonly BindableProperty CardColorProperty = BindableProperty.Create(
        nameof(CardColor),
        typeof(Color),
        typeof(PrinterView),
        Colors.White);

        public string ModuleName
        {
            get => (string)GetValue(PrinterView.ModuleNameProperty);
            set => SetValue(PrinterView.ModuleNameProperty, value);
        }
        public Color BorderColor
        {
            get => (Color)GetValue(PrinterView.BorderColorProperty);
            set => SetValue(PrinterView.BorderColorProperty, value);
        }
        public string EnclosureTemperature
        {
            get => (string)GetValue(PrinterView.EnclosureTemperatureProperty);
            set => SetValue(PrinterView.EnclosureTemperatureProperty, value);
        }

        public string EnclosureHumidity
        {
            get => (string)GetValue(PrinterView.EnclosureHumidityProperty);
            set => SetValue(PrinterView.EnclosureHumidityProperty, value);
        }

        public bool FanOn
        {
            get => (bool)GetValue(PrinterView.FanOnProperty);
            set => SetValue(PrinterView.FanOnProperty, value);
        }

        public bool LedOn
        {
            get => (bool)GetValue(PrinterView.LedOnProperty);
            set => SetValue(PrinterView.LedOnProperty, value);
        }

        public Color CardColor
        {
            get => (Color)GetValue(PrinterView.CardColorProperty);
            set => SetValue(PrinterView.CardColorProperty, value);
        }

        public string Ip
        {
            get => (string)GetValue(IpProperty);
            set => SetValue(IpProperty, value);
        }

        public PrinterView()
        {
            InitializeComponent();
        }

        private async void OnFanToggled(object? sender, EventArgs e)
        {
            FanOn = !FanOn;
            using var httpClient = new HttpClient();
            var request = $"{Ip}/fan-relay?on={FanOn.ToString().ToLower()}";
            var response = await httpClient.GetStringAsync(request);
        }
        
        private async void OnLedToggled(object? sender, EventArgs e)
        {
            LedOn = !LedOn;
            using var httpClient = new HttpClient();
            var request = $"{Ip}/led-relay?on={LedOn.ToString().ToLower()}";
            var response = await httpClient.GetStringAsync(request);
        }
    }
}
