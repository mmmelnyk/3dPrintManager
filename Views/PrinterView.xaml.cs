namespace _3dPrintManager.Views
{
    public partial class PrinterView : ContentView
    {
        public static readonly BindableProperty ModuleNameProperty = BindableProperty.Create(nameof(ModuleName), typeof(string), typeof(PrinterView), string.Empty);
        public static readonly BindableProperty EnclosureTemperatureProperty = BindableProperty.Create(nameof(EnclosureTemperature), typeof(string), typeof(PrinterView), string.Empty);
        public static readonly BindableProperty EnclosureHumidityProperty = BindableProperty.Create(nameof(EnclosureHumidity), typeof(string), typeof(PrinterView), string.Empty);

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

        public static readonly BindableProperty IconBackgroundColorProperty =
            BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(PrinterView), Colors.Gray);

        public Color IconBackgroundColor
        {
            get => (Color)GetValue(IconBackgroundColorProperty);
            set => SetValue(IconBackgroundColorProperty, value);
        }

        public static readonly BindableProperty IconImageSourceProperty =
            BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(PrinterView), default(ImageSource));

        public ImageSource IconImageSource
        {
            get => (ImageSource)GetValue(IconImageSourceProperty);
            set => SetValue(IconImageSourceProperty, value);
        }

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

        public Color CardColor
        {
            get => (Color)GetValue(PrinterView.CardColorProperty);
            set => SetValue(PrinterView.CardColorProperty, value);
        }

        public PrinterView()
        {
            InitializeComponent();
        }

        //CardDescription="$"Printer: {data.ModuleName} \nTemperature: {data.Temperature}°C\nHumidity: {data.Humidity}%""/>
    }
}
