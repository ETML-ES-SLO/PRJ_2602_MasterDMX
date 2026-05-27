using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;


namespace projet_POBJ
{

    public class OpenDMX

    {

        public static byte[] buffer = new byte[513];
        public static uint handle;
        public static bool done = false;
        public static int bytesWritten = 0;
        public static FT_STATUS status;

        public const byte BITS_8 = 8;
        public const byte STOP_BITS_2 = 2;
        public const byte PARITY_NONE = 0;
        public const UInt16 FLOW_NONE = 0;
        public const byte PURGE_RX = 1;
        public const byte PURGE_TX = 2;
  

        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_Open(UInt32 uiPort, ref uint ftHandle);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_Close(uint ftHandle);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_Read(uint ftHandle, IntPtr lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesReturned);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_Write(uint ftHandle, IntPtr lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesWritten);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_SetDataCharacteristics(uint ftHandle, byte uWordLength, byte uStopBits, byte uParity);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_SetFlowControl(uint ftHandle, char usFlowControl, byte uXon, byte uXoff);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_GetModemStatus(uint ftHandle, ref UInt32 lpdwModemStatus);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_Purge(uint ftHandle, UInt32 dwMask);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_ClrRts(uint ftHandle);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_SetBreakOn(uint ftHandle);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_SetBreakOff(uint ftHandle);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_GetStatus(uint ftHandle, ref UInt32 lpdwAmountInRxQueue, ref UInt32 lpdwAmountInTxQueue, ref UInt32 lpdwEventStatus);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_ResetDevice(uint ftHandle);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_SetDivisor(uint ftHandle, char usDivisor);
        [DllImport("FTD2XX.dll")]
        public static extern FT_STATUS FT_GetDeviceInfo(uint ftHandle, ref FT_DEVICE lpftDevice, ref UInt32 lpdwID, byte[] lpSerialNumber, byte[] lpDescription, IntPtr dummy);

        /*
        public static void start()
        {
            handle = 0;
            status = FT_Open(0, ref handle);
            Thread thread = new Thread(new ThreadStart(writeData));            
            thread.Start();
            setDmxValue(0, 0);  //Set DMX Start Code
        }*/

        public static string deviceDescription = "";

        //----------------------------------------------------------------------------------//
        //-- nom fct :  start()
        //-- description : methode pour se connecter a l'open dmx et detecter en cas d'erreur si
        //-- l'utilisateur n'essaye pas de start le open dmx avec un pro branché
        //----------------------------------------------------------------------------------//
        public static void start()
        {
            handle = 0;
            status = FT_Open(0, ref handle);

            if (status == FT_STATUS.FT_OK)
            {
                // --- BLOC DE DÉTECTION ---
                UInt32 deviceID = 0;
                FT_DEVICE deviceType = FT_DEVICE.FT_DEVICE_UNKNOWN;
                byte[] serNum = new byte[16];
                byte[] desc = new byte[64]; // C'est ici que le nom est stocké

                status = FT_GetDeviceInfo(handle, ref deviceType, ref deviceID, serNum, desc, IntPtr.Zero);

                if (status == FT_STATUS.FT_OK)
                {
                    // Convertit les octets reçus en texte (String)
                    deviceDescription = System.Text.Encoding.ASCII.GetString(desc).TrimEnd('\0');

                    if (deviceDescription.Contains("DMX USB PRO"))
                    {
                        FT_Close(handle); // On libère l'appareil
                        handle = 0;
                        status = FT_STATUS.FT_DEVICE_NOT_FOUND; // On simule une erreur
                        Console.WriteLine("Start d'un OPEN DMX alors qu'un DMX USB PRO est detecter");
                    }
                    else
                    {
                        Console.WriteLine("connection reussi");
                    }
                }
                // -------------------------

                Thread thread = new Thread(new ThreadStart(writeData));
                thread.Start();
                setDmxValue(0, 0);
            }
        }

        public static void setDmxValue(int channel, byte value)
        {
            if (buffer != null)
            {
                buffer[channel+1] = value;
            }
        }

        public static void writeData()
        {
            try
            {
                initOpenDMX();
                if (OpenDMX.status == FT_STATUS.FT_OK)
                {
                    status = FT_SetBreakOn(handle);
                    status = FT_SetBreakOff(handle);
                    bytesWritten = write(handle, buffer, buffer.Length);

                    Thread.Sleep(25);      //give the system time to send the data before sending more 

                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }

        }

        public static int write(uint handle, byte[] data, int length)
        {
            try
            {
                IntPtr ptr = Marshal.AllocHGlobal((int)length);
                Marshal.Copy(data, 0, ptr, (int)length);
                uint bytesWritten = 0;
                status = FT_Write(handle, ptr, (uint)length, ref bytesWritten);
                return (int)bytesWritten;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                return 0;
            }
        }

        public static void initOpenDMX()
        {
            status = FT_ResetDevice(handle);
            status = FT_SetDivisor(handle, (char)12);  // set baud rate
            status = FT_SetDataCharacteristics(handle, BITS_8, STOP_BITS_2, PARITY_NONE);
            status = FT_SetFlowControl(handle, (char)FLOW_NONE, 0, 0);
            status = FT_ClrRts(handle);
            status = FT_Purge(handle, PURGE_TX);
            status = FT_Purge(handle, PURGE_RX);
        }

        public static bool IsDeviceStillConnected()
        {
            // Si le handle est déjà à 0, c'est qu'on n'est pas connecté
            if (handle == 0) return false;

            uint modemStatus = 0;
            // On tente de demander le statut du modem à la puce FTDI
            // Si l'appareil est débranché, la fonction ne renverra pas FT_OK
            status = FT_GetModemStatus(handle, ref modemStatus);

            return (status == FT_STATUS.FT_OK);
        }
        public static void Stop()
        {
            done = true; // Arrête la boucle dans le thread (si tu en as ajouté une)
            if (handle != 0)
            {
                FT_Close(handle);
                handle = 0;
                status = FT_STATUS.FT_DEVICE_NOT_FOUND; // On change le statut
            }
        }

    }

    /// <summary>
    /// Enumaration containing the varios return status for the DLL functions.
    /// </summary>
    public enum FT_STATUS
    {
        FT_OK = 0,
        FT_INVALID_HANDLE,
        FT_DEVICE_NOT_FOUND,
        FT_DEVICE_NOT_OPENED,
        FT_IO_ERROR,
        FT_INSUFFICIENT_RESOURCES,
        FT_INVALID_PARAMETER,
        FT_INVALID_BAUD_RATE,
        FT_DEVICE_NOT_OPENED_FOR_ERASE,
        FT_DEVICE_NOT_OPENED_FOR_WRITE,
        FT_FAILED_TO_WRITE_DEVICE,
        FT_EEPROM_READ_FAILED,
        FT_EEPROM_WRITE_FAILED,
        FT_EEPROM_ERASE_FAILED,
        FT_EEPROM_NOT_PRESENT,
        FT_EEPROM_NOT_PROGRAMMED,
        FT_INVALID_ARGS,
        FT_OTHER_ERROR
    };
    public enum FT_DEVICE : uint
    {
        FT_DEVICE_232BM = 0,
        FT_DEVICE_232AM,
        FT_DEVICE_100AX,
        FT_DEVICE_UNKNOWN,
        FT_DEVICE_2232C,
        FT_DEVICE_232R,
        // ... etc
    }

}