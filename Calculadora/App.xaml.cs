namespace Calculadora {

    using Calculadora.Views;

    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new CalculadoraPage();
        }
    }
}