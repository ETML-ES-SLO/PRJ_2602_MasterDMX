using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace projet_POBJ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Prev_Page(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));
            if (page >= 1)
            {
                page--;
                Prev_Page_Channel.BackColor = Color.White;
            }
            else if (page == 0) 
            {
                Prev_Page_Channel.BackColor = Color.Gray;
            }

            Device_1.Clear();
            Value_device_1.Clear();
            Adress_device1.Clear();
            Device_2.Clear();
            Value_device_2.Clear();
            Adress_device2.Clear();
            Device_3.Clear();
            Value_device_3.Clear();
            Adress_device3.Clear();
            Device_4.Clear();
            Value_device_4.Clear();
            Adress_device4.Clear();

            if ((device.Channel_Number - (page * 4)) == 1)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
            }
            else if ((device.Channel_Number - (page * 4)) == 2)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
                Device_2.Text = device.Channel_Name[1 + (page * 4)];
                Value_device_2.Text = (device.Channel_Value[1 + (page * 4)]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + (1 + (page * 4))).ToString();
            }
            else if ((device.Channel_Number - (page * 4)) == 3)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
                Device_2.Text = device.Channel_Name[1 + (page * 4)];
                Value_device_2.Text = (device.Channel_Value[1 + (page * 4)]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + (1 + (page * 4))).ToString();
                Device_3.Text = device.Channel_Name[2 + (page * 4)];
                Value_device_3.Text = (device.Channel_Value[2 + (page * 4)]).ToString();
                Adress_device3.Text = ((device.Starting_Adress) + (2 + (page * 4))).ToString();
            }
            else if ((device.Channel_Number - (page * 4)) == 4)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
                Device_2.Text = device.Channel_Name[1 + (page * 4)];
                Value_device_2.Text = (device.Channel_Value[1 + (page * 4)]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + (1 + (page * 4))).ToString();
                Device_3.Text = device.Channel_Name[2 + (page * 4)];
                Value_device_3.Text = (device.Channel_Value[2 + (page * 4)]).ToString();
                Adress_device3.Text = ((device.Starting_Adress) + (2 + (page * 4))).ToString();
                Device_4.Text = device.Channel_Name[3 + (page * 4)];
                Value_device_4.Text = (device.Channel_Value[3 + (page * 4)]).ToString();
                Adress_device4.Text = ((device.Starting_Adress) + (3 + (page * 4))).ToString();
            }
            else if ((device.Channel_Number - (page * 4)) > 4)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
                Device_2.Text = device.Channel_Name[1 + (page * 4)];
                Value_device_2.Text = (device.Channel_Value[1 + (page * 4)]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + (1 + (page * 4))).ToString();
                Device_3.Text = device.Channel_Name[2 + (page * 4)];
                Value_device_3.Text = (device.Channel_Value[2 + (page * 4)]).ToString();
                Adress_device3.Text = ((device.Starting_Adress) + (2 + (page * 4))).ToString();
                Device_4.Text = device.Channel_Name[3 + (page * 4)];
                Value_device_4.Text = (device.Channel_Value[3 + (page * 4)]).ToString();
                Adress_device4.Text = ((device.Starting_Adress) + (3 + (page * 4))).ToString();
            }
        }

        public bool ft = false;
        private void Next_Page(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));
            int number_of_page = device.Get_Number_of_page(device.Channel_Number)-1;
            if (page < number_of_page)
            {
                page++;
                Next_Page_Channel.BackColor = Color.White;
            }
            else if(page == number_of_page)
            {
                if (ft == false) {
                    ft = true;
                    Next_Page_Channel.BackColor = Color.Gray; 
                }
                else if(ft == true)
                {
                    return;
                }
            }

            Device_1.Clear();
            Value_device_1.Clear();
            Adress_device1.Clear();
            Device_2.Clear();
            Value_device_2.Clear();
            Adress_device2.Clear();
            Device_3.Clear();
            Value_device_3.Clear();
            Adress_device3.Clear();
            Device_4.Clear();
            Value_device_4.Clear();
            Adress_device4.Clear();

            if ((device.Channel_Number - (page * 4)) == 1)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
            }
            else if ((device.Channel_Number - (page * 4)) == 2)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
                Device_2.Text = device.Channel_Name[1 + (page * 4)];
                Value_device_2.Text = (device.Channel_Value[1 + (page * 4)]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + ( 1 + (page * 4))).ToString();
            }
            else if ((device.Channel_Number - (page * 4)) == 3)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
                Device_2.Text = device.Channel_Name[1 + (page * 4)];
                Value_device_2.Text = (device.Channel_Value[1 + (page * 4)]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + (1 + (page * 4))).ToString();
                Device_3.Text = device.Channel_Name[2 + (page * 4)];
                Value_device_3.Text = (device.Channel_Value[2 + (page * 4)]).ToString();
                Adress_device3.Text = ((device.Starting_Adress) + (2 + (page * 4))).ToString();
            }
            else if ((device.Channel_Number - (page * 4)) == 4)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
                Device_2.Text = device.Channel_Name[1 + (page * 4)];
                Value_device_2.Text = (device.Channel_Value[1 + (page * 4)]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + (1 + (page * 4))).ToString();
                Device_3.Text = device.Channel_Name[2 + (page * 4)];
                Value_device_3.Text = (device.Channel_Value[2 + (page * 4)]).ToString();
                Adress_device3.Text = ((device.Starting_Adress) + (2 + (page * 4))).ToString();
                Device_4.Text = device.Channel_Name[3 + (page * 4)];
                Value_device_4.Text = (device.Channel_Value[3 + (page * 4)]).ToString();
                Adress_device4.Text = ((device.Starting_Adress) + (3 + (page * 4))).ToString();
            }
            else if ((device.Channel_Number - (page * 4)) > 4)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
                Device_2.Text = device.Channel_Name[1 + (page * 4)];
                Value_device_2.Text = (device.Channel_Value[1 + (page * 4)]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + (1 + (page * 4))).ToString();
                Device_3.Text = device.Channel_Name[2 + (page * 4)];
                Value_device_3.Text = (device.Channel_Value[2 + (page * 4)]).ToString();
                Adress_device3.Text = ((device.Starting_Adress) + (2 + (page * 4))).ToString();
                Device_4.Text = device.Channel_Name[3 + (page * 4)];
                Value_device_4.Text = (device.Channel_Value[3 + (page * 4)]).ToString();
                Adress_device4.Text = ((device.Starting_Adress) + (3 + (page * 4))).ToString();
            }
        }

        private void Device_1_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

            device.Change_Channel_Name(Device_1.Text, page, 0);

        }

        private void Device_2_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

            device.Change_Channel_Name(Device_2.Text, page, 1);
        }

        private void Device_3_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

            device.Change_Channel_Name(Device_3.Text, page, 2);
        }

        private void Device_4_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

            device.Change_Channel_Name(Device_4.Text, page, 3);
        }

        private void Value_device_1_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));
            int new_value;

            if (!int.TryParse(Value_device_1.Text, out new_value))
            {
                new_value = 0;
                Value_device_1.Text = new_value.ToString();
            }

            if (new_value >= 256)
            {
                new_value = 255;
                Value_device_1.Text = new_value.ToString();
            }
            else if (new_value <= -1)
            {
                new_value = 0;
                Value_device_1.Text = new_value.ToString();
            }
            device.Change_Channel_Value(new_value, page, 0);
        }

        private void Value_device_2_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));
            int new_value;

            if (!int.TryParse(Value_device_2.Text, out new_value))
            {
                new_value = 0;
                Value_device_2.Text = new_value.ToString();
            }

            if (new_value >= 256)
            {
                new_value = 255;
                Value_device_2.Text = new_value.ToString();
            }
            else if (new_value <= -1)
            {
                new_value = 0;
                Value_device_2.Text = new_value.ToString();
            }
            device.Change_Channel_Value(new_value, page, 1);
        }

        private void Value_device_3_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));
            int new_value;

            if (!int.TryParse(Value_device_3.Text, out new_value))
            {
                new_value = 0;
                Value_device_3.Text = new_value.ToString();
            }

            if (new_value >= 256)
            {
                new_value = 255;
                Value_device_3.Text = new_value.ToString();
            }
            else if (new_value <= -1)
            {
                new_value = 0;
                Value_device_3.Text = new_value.ToString();
            }
            device.Change_Channel_Value(new_value, page, 2);
        }

        private void Value_device_4_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));
            int new_value;

            if (!int.TryParse(Value_device_4.Text, out new_value))
            {
                new_value = 0;
                Value_device_4.Text = new_value.ToString();
            }

            if (new_value >= 256)
            {
                new_value = 255;
                Value_device_4.Text = new_value.ToString();
            }
            else if (new_value <= -1)
            {
                new_value = 0;
                Value_device_4.Text = new_value.ToString();
            }

            device.Change_Channel_Value(new_value, page, 3);
        }

        
        const bool Creation = true;
        const bool Validation = false;

        bool mode = Creation;
        string temp_device_name = null;
        int temp_device_channel_number = 0;
        int temp_starting_adress = 0;

        private void New_device_click(object sender, EventArgs e)
        {

            if (mode == Creation)
            {
                mode = Validation;
                New_Validate_device.Text = "Valider";
            }
            else if (mode == Validation)
            {
                if ((temp_device_name == null) || (temp_device_channel_number == 0) || (Program.adress_memory.Fill_Adress_tab(temp_starting_adress,temp_device_channel_number) == false))
                {
                    New_Validate_device.Text = "invalid Value";
                    timer_validate_button.Start();
                }
                else
                {
                    Program.devices.Add(new Device_parameters(temp_device_name, temp_device_channel_number,temp_starting_adress));
                    comboBoxDevice.Items.Add(temp_device_name);
                    Creation_Number_channel.Text = "0";
                    Creation_Device_Name.Text = "";
                    mode = Creation;
                    New_Validate_device.Text = "new Device";
                    
                }
            }
        }

        private void Timer_Validate_button_is_done(object sender, EventArgs e)
        {
            timer_validate_button.Stop();
            New_Validate_device.Text = "Valider";
        }

        private void Device_Name_Changed(object sender, EventArgs e)
        {
            temp_device_name = Creation_Device_Name.Text;
        }

        private void Channel_number_changed(object sender, EventArgs e)
        {
            if (int.TryParse(Creation_Number_channel.Text, out int result))
            {
                temp_device_channel_number = result;
            }

        }

        private void start_adresse_changed(object sender, EventArgs e)
        {
            if (int.TryParse(Creation_starting_adress.Text, out int result))
            {
                temp_starting_adress = result;
            }
        }
        private void Next_page_Device(object sender, EventArgs e)
        {
            
        }

        private void Prev_page_Device(object sender, EventArgs e)
        {

        }
        int page = 0;
        private void Device_Changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

            page = 0;
            Device_1.Clear();
            Value_device_1.Clear();
            Adress_device1.Clear();
            Device_2.Clear();
            Value_device_2.Clear();
            Adress_device2.Clear();
            Device_3.Clear();
            Value_device_3.Clear();
            Adress_device3.Clear();
            Device_4.Clear();
            Value_device_4.Clear();
            Adress_device4.Clear();

            if (device.Channel_Number == 1)
            {
                Device_1.Text = device.Channel_Name[0];
                Value_device_1.Text = (device.Channel_Value[0]).ToString();
                Adress_device1.Text = (device.Starting_Adress).ToString();
            }
            else if (device.Channel_Number == 2)
            {
                Device_1.Text = device.Channel_Name[0];
                Value_device_1.Text = (device.Channel_Value[0]).ToString();
                Adress_device1.Text = (device.Starting_Adress).ToString();
                Device_2.Text = device.Channel_Name[1];
                Value_device_2.Text = (device.Channel_Value[1]).ToString();
                Adress_device2.Text = ((device.Starting_Adress)+1).ToString();
            }
            else if (device.Channel_Number == 3)
            {
                Device_1.Text = device.Channel_Name[0];
                Value_device_1.Text = (device.Channel_Value[0]).ToString();
                Adress_device1.Text = (device.Starting_Adress).ToString();
                Device_2.Text = device.Channel_Name[1];
                Value_device_2.Text = (device.Channel_Value[1]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + 1).ToString();
                Device_3.Text = device.Channel_Name[2];
                Value_device_3.Text = (device.Channel_Value[2]).ToString();
                Adress_device3.Text = ((device.Starting_Adress) + 2).ToString();
            }
            else if (device.Channel_Number == 4)
            {
                Device_1.Text = device.Channel_Name[0];
                Value_device_1.Text = (device.Channel_Value[0]).ToString();
                Adress_device1.Text = (device.Starting_Adress).ToString();
                Device_2.Text = device.Channel_Name[1];
                Value_device_2.Text = (device.Channel_Value[1]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + 1).ToString();
                Device_3.Text = device.Channel_Name[2];
                Value_device_3.Text = (device.Channel_Value[2]).ToString();
                Adress_device3.Text = ((device.Starting_Adress) + 2).ToString();
                Device_4.Text = device.Channel_Name[3];
                Value_device_4.Text = (device.Channel_Value[3]).ToString();
                Adress_device4.Text = ((device.Starting_Adress) + 3).ToString();
            }
            else if (device.Channel_Number > 4)
            {
                Device_1.Text = device.Channel_Name[0+(page*4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = (device.Starting_Adress).ToString();
                Device_2.Text = device.Channel_Name[1 + (page * 4)];
                Value_device_2.Text = (device.Channel_Value[1 + (page * 4)]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + 1).ToString();
                Device_3.Text = device.Channel_Name[2 + (page * 4)];
                Value_device_3.Text = (device.Channel_Value[2 + (page * 4)]).ToString();
                Adress_device3.Text = ((device.Starting_Adress) + 2).ToString();
                Device_4.Text = device.Channel_Name[3 + (page * 4)];
                Value_device_4.Text = (device.Channel_Value[3 + (page * 4)]).ToString();
                Adress_device4.Text = ((device.Starting_Adress) + 3).ToString();
            }
        }

        private void debug(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.adress_memory.Adress_list.Length; i++)
                Console.Write(Program.adress_memory.Adress_list[i] + " ");
            Console.WriteLine();
        }

        private void Send_dmx_to_interface(object sender, EventArgs e)
        {

        }

        private void start_dmx_interface(object sender, EventArgs e)
        {
            try
            {
                OpenDMX.start();                                            //find and connect to devive (first found if multiple)
                if (OpenDMX.status == FT_STATUS.FT_DEVICE_NOT_FOUND)       //update status
                    Console.Write("No Enttec USB Device Found");
                else if (OpenDMX.status == FT_STATUS.FT_OK)
                    Console.Write("Found DMX on USB");
                else
                    Console.Write("Error Opening Device");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                Console.Write("Error Connecting to Enttec USB Device");

            }
        }
    }



}
