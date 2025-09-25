namespace _3dPrintManager.Views
{
    public partial class PrinterView : ContentView
    {
        public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(PrinterView), string.Empty);
        public static readonly BindableProperty CardDescriptionProperty = BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(PrinterView), string.Empty);

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

        public string CardTitle
        {
            get => (string)GetValue(PrinterView.CardTitleProperty);
            set => SetValue(PrinterView.CardTitleProperty, value);
        }
        public Color BorderColor
        {
            get => (Color)GetValue(PrinterView.BorderColorProperty);
            set => SetValue(PrinterView.BorderColorProperty, value);
        }
        public string CardDescription
        {
            get => (string)GetValue(PrinterView.CardDescriptionProperty);
            set => SetValue(PrinterView.CardDescriptionProperty, value);
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
