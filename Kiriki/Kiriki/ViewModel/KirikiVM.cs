
using Kiriki.ViewModel.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiriki.ViewModel
{
    public class KirikiVM : clsVMBase
    {
        #region atributos privados
        private int valorDado1;
        private int valorDado2;
        private String fotoDado1;
        private String fotoDado2;

        private int vidas;
        private string textoBoton;
        private string textoBoton2;
        private bool haTirado;
        private bool comprobarMentira;

        private DelegateCommand miente;
        private DelegateCommand tirar;
        #endregion

        #region propiedades publicas
        public int ValorDado1
        {
            get { return valorDado1; }
            set
            {
                valorDado1 = value;
                NotifyPropertyChanged("ValorDado1");
            }
        }
        public int ValorDado2
        {
            get { return valorDado2; }
            set
            {
                valorDado2 = value;
                NotifyPropertyChanged("ValorDado2");
            }
        }
        public String FotoDado1
        {
            get { return fotoDado1; }
            set
            {
                fotoDado1 = value;
                NotifyPropertyChanged("FotoDado1");
            }
        }
        public String FotoDado2
        {
            get { return fotoDado2; }
            set
            {
                fotoDado2 = value;
                NotifyPropertyChanged("FotoDado2");
            }
        }
        public int Vidas
        {
            get { return vidas; }
            set
            {
                vidas = value;
                NotifyPropertyChanged("Vidas");
            }
        }
        public DelegateCommand Miente
        {
            get { return miente; }
        }
        public DelegateCommand Tirar
        {
            get { return tirar; }
        }

        public string TextoBoton
        {
            get { return textoBoton; }
            set
            {
                textoBoton = value;
                NotifyPropertyChanged("TextoBoton");
            }
        }

        public string TextoBoton2
        {
            get { return textoBoton2; }
            set
            {
                textoBoton2 = value;
                NotifyPropertyChanged("TextoBoton2");
            }
        }
        #endregion

        #region constructores
        public KirikiVM()
        {
            miente = new DelegateCommand(MienteCommandExecute, MienteCommandCanExecute);
            tirar = new DelegateCommand(TirarCommandExecute);
            textoBoton = "Mostrar dados";
            textoBoton2 = "Tirar";
        }
        #endregion

        #region comandos

        public void MienteCommandExecute()
        {
            if (comprobarMentira)
            {
                Vidas--;
                TextoBoton = "Mostrar dados";
                TextoBoton2 = "Tirar";
                comprobarMentira = false;
                FotoDado1 = "interr.png";
                FotoDado2 = "interr.png";

            }
            else
            {
                FotoDado1 = "dado" + valorDado1 + ".png";
                FotoDado2 = "dado" + valorDado2 + ".png";
                TextoBoton = "Miente";
                TextoBoton2 = "No Miente";
                comprobarMentira = true;
            }

        }

        public void TirarCommandExecute()
        {
            if (comprobarMentira)
            {
                Vidas++;
                TextoBoton = "Mostrar dados";
                TextoBoton2 = "Tirar";
                comprobarMentira = false;
                FotoDado1 = "interr.png";
                FotoDado2 = "interr.png";
            }
            else if (haTirado)
            {
                TextoBoton2 = "Pasar turno";
                haTirado = true;


            }
            else
            {
                haTirado = true;
                Random rnd = new Random();
                valorDado1 = rnd.Next(1, 6);
                valorDado2 = rnd.Next(1, 6);
                FotoDado1 = "interr.png";
                FotoDado2 = "interr.png";
                miente.RaiseCanExecuteChanged();
            }
        }

        private bool MienteCommandCanExecute()
        {
            if (valorDado1 != 0 && valorDado2 != 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}
