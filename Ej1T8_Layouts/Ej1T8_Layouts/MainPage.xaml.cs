using static System.Net.Mime.MediaTypeNames;

namespace Ej1T8_Layouts
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            fecha.MaximumDate = DateTime.Now;
        }
        

        public void clickGuardar(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nombre.Text))
            {
                nombreerror.Text = "El nombre no puede estar vacio";
            } if (String.IsNullOrEmpty(apellidos.Text))
            {
                apellidoserror.Text = "Los apellidos no pueden estar vacios";

            } else
            {
                nombreerror.Text = "";
                apellidoserror.Text = "";
                Realizado.Text = "Persona guardada correctamente";
            }
        }

        public async void clickBorrar(object sender, EventArgs e)
        {
            nombreerror.Text = "";
            apellidoserror.Text = "";


            bool respuesta = await DisplayAlert("Aviso", "¿Esta seguro de borrar esta persona?", "Si", "No");
            if (respuesta)
            {
                Realizado.Text = "Persona borrada correctamente";
                nombre.Text = "";
                apellidos.Text = "";
            }

        }

        public void clickAñadir(object sender, EventArgs e)
        {

            nombreerror.Text = "";
            apellidoserror.Text = "";

            nombre.Text = string.Empty;
            apellidos.Text = string.Empty;
            fecha.Date = DateTime.Today;

            Realizado.Text = "Persona añadida correctamente";
        }

    }
}