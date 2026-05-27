using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace projet_POBJ
{
    public class Device_parameters
    {
        public string Device_Name;
        public int Channel_Number;

        public string[] Channel_Name;
        public int[] Channel_Value;
        public int Starting_Adress;

        //----------------------------------------------------------------------------------//
        //-- nom fct : Device_parameters (Constructeur)
        //-- paramètre entrée : string deviceName, int ChannelNumber, int StartingAdress
        //-- description : initialise un nouvel appareil avec ses canaux et son adresse de départ
        //----------------------------------------------------------------------------------//
        public Device_parameters(string deviceName, int ChannelNumber, int StartingAdress)
        {
            Device_Name = deviceName;
            Channel_Number = ChannelNumber;
            Starting_Adress = StartingAdress;

            Channel_Name = new string[ChannelNumber];
            Channel_Value = new int[ChannelNumber];

            for (int i = 0; i < ChannelNumber; i++)
            {
                Channel_Name[i] = $"Channel {i + 1}";
                Channel_Value[i] = 0;
            }

        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Get_index_value
        //-- paramètre entrée : int page_number, int ChannelNumber
        //-- paramètre sortie : position dans le tableau
        //-- description : calcule l'index réel dans le tableau en fonction de la page
        //----------------------------------------------------------------------------------//
        public int Get_index_value(int page_number, int ChannelNumber)
        {
            int index_value = ((page_number * 4) + ChannelNumber);
            return index_value;
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Get_Number_of_page
        //-- paramètre entrée : int ChannelNumber
        //-- paramètre sortie : nombre de page calculée
        //-- description : calcule le nombre de pages nécessaires pour afficher tous les canaux
        //----------------------------------------------------------------------------------//
        public int Get_Number_of_page(int ChannelNumber)
        {
            if (ChannelNumber % 4 == 0)
            {
                return (ChannelNumber / 4);
            }
            else
            {
                return ((ChannelNumber / 4) + 1);
            }

        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Change_Channel_Name
        //-- paramètre entrée : string new_Name, int page_number, int ChannelNumber
        //-- description : modifie le nom d'un canal spécifique selon sa page et sa position
        //----------------------------------------------------------------------------------//
        public void Change_Channel_Name(string new_Name, int page_number, int ChannelNumber)
        {
            Channel_Name[Get_index_value(page_number, ChannelNumber)] = new_Name;
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Change_Channel_Value
        //-- paramètre entrée : int new_Value, int page_number, int ChannelNumber
        //-- description : modifie la valeur d'un canal spécifique selon sa page et sa position
        //----------------------------------------------------------------------------------//
        public void Change_Channel_Value(int new_Value, int page_number, int ChannelNumber)
        {
            Channel_Value[Get_index_value(page_number, ChannelNumber)] = new_Value;
        }


    }

    public class Project_Memory
    {
        public const int Max_adresse = 511;
        public const bool place_unused = false;
        public const bool place_used = true;

        public bool[] Adress_list = new bool[512];
        public int[] Value_list = new int[512];

        //----------------------------------------------------------------------------------//
        //-- nom fct : Project_Memory (Constructeur)
        //-- paramètre entrée : aucun
        //-- description : initialise la mémoire du projet en vidant toutes les adresses
        //----------------------------------------------------------------------------------//
        public Project_Memory()
        {
            for (var index = 0; index < Max_adresse; index++)
            {
                Adress_list[index] = place_unused;
                Value_list[index] = 0;
            }
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Is_place_available
        //-- paramètre entrée : int starting_adress, int ChannelNumber
        //-- description : vérifie si une plage d'adresses est libre dans la mémoire
        //----------------------------------------------------------------------------------//
        private bool Is_place_available(int starting_adress, int ChannelNumber)
        {

            if ((starting_adress + ChannelNumber) > Max_adresse)
            {
                return false;
            }

            for (var index = starting_adress; index < (starting_adress + ChannelNumber); index++)
            {
                if (Adress_list[index] == place_used)
                {
                    Console.WriteLine("adresse invalide");
                    return false;
                }
            }
            Console.WriteLine("adresse valide");
            return true;

        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Fill_Adress_tab
        //-- paramètre entrée : int starting_adress, int ChannelNumber
        //-- description : marque une plage d'adresses comme utilisée si elles sont disponibles
        //----------------------------------------------------------------------------------//
        public bool Fill_Adress_tab(int starting_adress, int ChannelNumber)
        {
            if (!Is_place_available(starting_adress, ChannelNumber))
            {
                Console.WriteLine("adresse invalide");
                return false;
            }

            for (var index = starting_adress; index < (starting_adress + ChannelNumber); index++)
            {
                Adress_list[index] = place_used;
            }
            Console.WriteLine("adresse valide");
            return true;

        }

    }

    public class EnttecProManager : IDisposable
    {
        // Constantes du protocole Enttec Pro
        private const byte START_BYTE = 0x7E;
        private const byte END_BYTE = 0xE7;
        private const byte LABEL_SEND_DMX = 6;

        private SerialPort _serialPort;
        private byte[] _dmxBuffer = new byte[512]; // 1 (start code) + 512 canaux


        public bool IsConnected => _serialPort?.IsOpen ?? false;

        /// <summary>
        /// Initialise et ouvre la connexion avec le boîtier.
        /// </summary>
        /// <param name="portName">Ex: "COM3"</param>
        public bool Connect(string portName)
        {
            try
            {
                _serialPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
                _serialPort.Open();
                Console.WriteLine($"[DMX] Connecté sur {portName}");
                for (int i = 0; i < 511; i++)
                {
                    _dmxBuffer[i] = 0;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Impossible d'ouvrir le port {portName} : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Modifie la valeur d'un canal (1 à 512).
        /// </summary>
        public void SetChannel(int channel, byte value)
        {
            //if (channel < 0 || channel > 512) return;
            Console.WriteLine(channel);
            Console.WriteLine(value);
            _dmxBuffer[channel] = value;
        }

        public void SendTest()
        {

            // La taille totale des données est : 1 (le 00 initial) + le nombre de canaux
            short totalDataLength = (short)(_dmxBuffer.Length + 1);

            byte lsb = (byte)(totalDataLength & 0xFF);
            byte msb = (byte)((totalDataLength >> 8) & 0xFF);

            // Construction du paquet
            List<byte> packet = new List<byte>();
            packet.Add(0x7E);        // Start
            packet.Add(0x06);        // Label
            packet.Add(lsb);         // LSB
            packet.Add(msb);         // MSB
            packet.Add(0x00);        // Le "Leading 0" (Start code)
            packet.AddRange(_dmxBuffer); // Tes canaux
            packet.Add(0xE7);        // End

            byte[] finalFrame = packet.ToArray();

            _serialPort.Write(finalFrame, 0, finalFrame.Length);
        }

        private byte[] EncapuslatePacket(byte[] data)
        {
            int dataLength = data.Length;
            byte[] frame = new byte[dataLength + 6];

            frame[0] = START_BYTE;
            frame[1] = LABEL_SEND_DMX;
            frame[2] = (byte)(dataLength & 0xFF);        // LSB
            frame[3] = (byte)((dataLength >> 8) & 0xFF); // MSB

            Array.Copy(data, 0, frame, 4, dataLength);

            frame[frame.Length - 1] = END_BYTE;
            return frame;
        }

        public void Disconnect()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }

        public void Dispose() => Disconnect();
    }
}
