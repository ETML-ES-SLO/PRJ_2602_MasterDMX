using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_POBJ
{
    public class Device_parameters
    {
        public string Device_Name;
        public int Channel_Number;

        public string[] Channel_Name;
        public int[] Channel_Value;
        public int Starting_Adress;
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
        public int Get_index_value(int page_number, int ChannelNumber)
        {
            int index_value = ((page_number * 4) + ChannelNumber);
            return index_value;
        }

        public int Get_Number_of_page(int ChannelNumber)
        {
            if(ChannelNumber % 4 == 0)
            {
                return (ChannelNumber / 4);
            }
            else
            {
                return ((ChannelNumber / 4) + 1);
            }
            
        }

        public void Change_Channel_Name(string new_Name, int page_number, int ChannelNumber)
        {
            Channel_Name[Get_index_value(page_number, ChannelNumber)] = new_Name;
        }
        public void Change_Channel_Value(int new_Value, int page_number, int ChannelNumber)
        {
            Channel_Value[Get_index_value(page_number, ChannelNumber)] = new_Value;
        }


    }

    public class Project_Memory
    {
        private const int Max_adresse = 511;
        private const bool place_unused = false;
        private const bool place_used = true;

        public bool[] Adress_list = new bool[512];

        public Project_Memory()
        {
            for(var index = 0; index < Max_adresse; index++)
            {
                Adress_list[index] = place_unused;
            }
        }
        private bool Is_place_available(int starting_adress,int ChannelNumber)
        {

            if ((starting_adress + ChannelNumber) > Max_adresse)
            {
                return false;
            }

            for(var index = starting_adress; index < ( starting_adress + ChannelNumber); index++)
            {
                if(Adress_list[index] == place_used)
                {
                    Console.WriteLine("adresse invalide");
                    return false;
                }
            }
            Console.WriteLine("adresse valide");
            return true;

        }
        public bool Fill_Adress_tab(int starting_adress, int ChannelNumber)
        {
            if(!Is_place_available(starting_adress, ChannelNumber))
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
}
