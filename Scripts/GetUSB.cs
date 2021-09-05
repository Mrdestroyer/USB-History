using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace USB_History
{
    class GetUSB
    {
        public const string RUTA_REGISTRO = @"SYSTEM\CurrentControlSet\Enum\USBSTOR";
        private List<USB> ListahistoricoUSB;

        public GetUSB()
        {
            this.ListahistoricoUSB = new List<USB>();
            this.getRegistros();
        }
        /*
         * DEVUELVE EL HISTORIAL DE USB QUE SE HAN CONECTADO ANTERIORMENTE
         */
        public List<USB> getHistoryUSB()
        {
            List<RegistryKey> listadoRegistro = this.getRegistros();

            for(var i = 0; i < listadoRegistro.Count; i++)
            {
                USBHistorico histTemp = new USBHistorico();
        
                histTemp.nombreAmigable =  listadoRegistro[i].GetValue("FriendlyName").ToString();
                this.ListahistoricoUSB.Add(histTemp);
            }
            return ListahistoricoUSB;
        }

        /**
         *  DEVUELVE UNA LISTA DE LOS USB CONECTADOS EN EL MOMENTO 
         */
        /*public List<USB> getUSBActivos()
        {

        }*/

        /*
         *  DEVUELVE UNA LISTA DE REGISTROS DEL REGISTRO DE WINDOWS EN USBSTOR
         * */
        private List<RegistryKey> getRegistros()
        {
            List<RegistryKey> registrosUSB = new List<RegistryKey>();

            RegistryKey claveRegistro = Registry.LocalMachine.OpenSubKey(RUTA_REGISTRO);
            String[] nRegistros = claveRegistro.GetSubKeyNames();

            for (var j = 0; j < nRegistros.Length; j++)
            {
                //CREAR CLAVE DE REGISTRO TEMPORAL PARA ACCEDER A LA SUBCARPETA CON LOS VALORES NECESITADOS
                RegistryKey regTemp = Registry.LocalMachine.OpenSubKey(RUTA_REGISTRO + @"\" + nRegistros[j]);
                String[] subRutasTemp = regTemp.GetSubKeyNames();

                RegistryKey temp = Registry.LocalMachine.OpenSubKey(RUTA_REGISTRO + @"\" + nRegistros[j] + @"\" + subRutasTemp[0]);

                registrosUSB.Add(temp);
            }
            ///FOR TEST
            //for (var i = 0; i < registrosUSB.Count; i++)
            //{
            //    MessageBox.Show(registrosUSB[i].GetValue("FriendlyName").ToString());
            //}

            return registrosUSB;
        }
    }
}

