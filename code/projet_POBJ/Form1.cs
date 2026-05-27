using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;




namespace projet_POBJ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool ft = false;
        const bool Creation = true;
        const bool Validation = false;
        bool mode = Creation;
        string temp_device_name = null;
        int temp_device_channel_number = 0;
        int temp_starting_adress = 0;
        int page = 0;
        public bool DMX_device_selected = false;
        public int DMX_which_device_selected = 0;
        //  1 = open dmx
        //  2 = pro

        //----------------------------------------------------------------------------------//
        //-- nom fct : Prev_Page  
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : passe sur la page precedente dans
        //-- les pages des channels du device selectionner 
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void Prev_Page(object sender, EventArgs e)
        {
            //recherche dans la comboBox le device selectionner
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            //recherche l'objet du device selectionner 
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

            //clear de tout les parametres affiché concernant le device selectionné sur l'application 
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

            //dans le cas ou il y a un seul channel
            if ((device.Channel_Number - (page * 4)) == 1)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
            }
            //dans le cas ou il y a deux channels
            else if ((device.Channel_Number - (page * 4)) == 2)
            {
                Device_1.Text = device.Channel_Name[0 + (page * 4)];
                Value_device_1.Text = (device.Channel_Value[0 + (page * 4)]).ToString();
                Adress_device1.Text = ((device.Starting_Adress) + (page * 4)).ToString();
                Device_2.Text = device.Channel_Name[1 + (page * 4)];
                Value_device_2.Text = (device.Channel_Value[1 + (page * 4)]).ToString();
                Adress_device2.Text = ((device.Starting_Adress) + (1 + (page * 4))).ToString();
            }
            //dans le cas ou il y a trois channels
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
            //dans le cas ou il y a quatres channels
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
            //dans le cas ou il y a plus de quatres channels
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

        //----------------------------------------------------------------------------------//
        //-- nom fct : Next_Page  
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : passe sur la page suivante dans
        //-- les pages des channels du device selectionner 
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
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

        //----------------------------------------------------------------------------------//
        //-- nom fct : Device_1_text_changed  
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : lors ce que le texte contenant la premieres device affiché, 
        //-- change les informations relative au channel dans la memoire
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void Device_1_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

            device.Change_Channel_Name(Device_1.Text, page, 0);

        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Device_2_text_changed  
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : lors ce que le texte contenant la deuxieme device affiché, 
        //-- change les informations relative au channel dans la memoire
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void Device_2_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

            device.Change_Channel_Name(Device_2.Text, page, 1);
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Device_3_text_changed  
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : lors ce que le texte contenant la troisième device affiché, 
        //-- change les informations relative au channel dans la memoire
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void Device_3_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

            device.Change_Channel_Name(Device_3.Text, page, 2);
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Device_4_text_changed  
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : lors ce que le texte contenant la dernière device affiché, 
        //-- change les informations relative au channel dans la memoire
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void Device_4_text_changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

            device.Change_Channel_Name(Device_4.Text, page, 3);
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Value_device_1_text_changed 
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : lors ce que la valeur de la premieres device affiché, 
        //-- change les informations relative au channel dans la memoire
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
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
            Program.adress_memory.Value_list[device.Starting_Adress + (page * 4)] = new_value;
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Value_device_2_text_changed 
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : lors ce que la valeur de la premieres device affiché, 
        //-- change les informations relative au channel dans la memoire
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
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
            Program.adress_memory.Value_list[device.Starting_Adress + ((page*4)+1)] = new_value;
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Value_device_3_text_changed 
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : lors ce que la valeur de la premieres device affiché, 
        //-- change les informations relative au channel dans la memoire
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
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
            Program.adress_memory.Value_list[device.Starting_Adress + ((page * 4) + 2)] = new_value;
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Value_device_4_text_changed 
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : lors ce que la valeur de la premieres device affiché, 
        //-- change les informations relative au channel dans la memoire
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
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
            Program.adress_memory.Value_list[device.Starting_Adress + ((page * 4) + 3)] = new_value;
        }


        //----------------------------------------------------------------------------------//
        //-- nom fct : New_device_click
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : entre dans le mode creation lors du première appuie et crée la device
        //-- lors du deuxieme appuie
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
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
                    groupBox1.Enabled = true;
                }
            }
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Timer_Validate_button_is_done
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : lors ce que le timer de validation est terminer re affiche la valeur 
        //-- par defaut sur le bouton
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void Timer_Validate_button_is_done(object sender, EventArgs e)
        {
            timer_validate_button.Stop();
            New_Validate_device.Text = "Valider";
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Device_Name_Changed
        //-- paramètre entrée : object sender, EventArgs e
        //-- dans le mode de creation quand l'utilisateur a entrée une valeur dans le champs
        //-- de texte du nom
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void Device_Name_Changed(object sender, EventArgs e)
        {
            temp_device_name = Creation_Device_Name.Text;
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Device_Name_Changed
        //-- paramètre entrée : object sender, EventArgs e
        //-- dans le mode de creation quand l'utilisateur a entrée une valeur dans le champs
        //-- de texte du nombre de channel
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void Channel_number_changed(object sender, EventArgs e)
        {
            if (int.TryParse(Creation_Number_channel.Text, out int result))
            {
                temp_device_channel_number = result;
            }

        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Device_Name_Changed
        //-- paramètre entrée : object sender, EventArgs e
        //-- dans le mode de creation quand l'utilisateur a entrée une valeur dans le champs
        //-- de texte du de l'adresse de debut
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void start_adresse_changed(object sender, EventArgs e)
        {
            if (int.TryParse(Creation_starting_adress.Text, out int result))
            {
                temp_starting_adress = result;
            }
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Device_Changed
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : lors ce que l'utilisateur a changer de device dans le combobox
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void Device_Changed(object sender, EventArgs e)
        {
            string selectedName = comboBoxDevice.SelectedItem.ToString();
            Device_parameters device = Program.devices.Find(d => d.Device_Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));

            Adress_Box.Enabled = true;
            Value_Box.Enabled = true;
            Name_Box.Enabled = true;


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

        //----------------------------------------------------------------------------------//
        //-- nom fct : debug
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : une liste de tout les channels, s'ils sont utiliser et leur valeur
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void debug(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.adress_memory.Adress_list.Length; i++)
                Console.Write(Program.adress_memory.Adress_list[i] + " ");
            Console.WriteLine();
            for (int i = 0; i < Program.adress_memory.Value_list.Length; i++)
                Console.Write(Program.adress_memory.Value_list[i] + " ");
            Console.WriteLine();
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : Send_dmx_to_interface
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : envoie les données a envoyer en DMX au module connecté correspondant
        //-- date de modification : 6 mai 2026
        //----------------------------------------------------------------------------------//
        private void Send_dmx_to_interface(object sender, EventArgs e)
        {
            if (DMX_which_device_selected == 1)
            {
                if (OpenDMX.status == FT_STATUS.FT_DEVICE_NOT_FOUND)
                    DMX_status.Text = "No Enttec USB Device Found";
                else
                    DMX_status.Text = "Found DMX on USB";
                byte buffer_value;
                Console.WriteLine("inside dmx sender");
                for (int index = 1; index < 511; index++)
                {
                    if (Program.adress_memory.Adress_list[index] == true)
                    {
                        buffer_value = (byte)Program.adress_memory.Value_list[index];
                        Console.WriteLine(index);
                        Console.WriteLine(buffer_value);
                        OpenDMX.setDmxValue(index-1, buffer_value);
                    }
                }
                OpenDMX.writeData();
            }

            if (DMX_which_device_selected == 2)
            {
                byte buffer_value;
                for (int index = 1; index < 511; index++)
                {
                    if (Program.adress_memory.Adress_list[index] == true)
                    {
                        buffer_value = (byte)Program.adress_memory.Value_list[index];
                        Program.DMX_UBS_PRO.SetChannel(index-1, buffer_value);
                    }
                }
                Program.DMX_UBS_PRO.SendTest();
            }
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : start_dmx_interface
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : init du module enttec open dmx
        //-- date de modification : 13 mai 2026
        //----------------------------------------------------------------------------------//
        private void start_dmx_interface(object sender, EventArgs e)
        {
            if (DMX_device_selected == false)
            {
                try
                {
                    OpenDMX.start();                                            //find and connect to devive (first found if multiple)
                    if (OpenDMX.status == FT_STATUS.FT_DEVICE_NOT_FOUND)
                    {
                        DMX_device_selected = false;
                        DMX_which_device_selected = 0;
                        DMX_status.Text = "No Enttec USB Device Found";
                    }       //update status

                    else if (OpenDMX.status == FT_STATUS.FT_OK)
                    {
                        DMX_status.Text = "Found DMX on USB";
                        DMX_device_selected = true;
                        DMX_which_device_selected = 1;
                        DMX_send_button.Enabled = true;
                    }
                    else
                    {
                        DMX_device_selected = false;
                        DMX_which_device_selected = 0;
                        DMX_status.Text = "Error Opening Device";
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                    DMX_status.Text = "Error Connecting to Enttec USB Device";

                }
            }
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : start_dmx_pro
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : init du module enttec dmx usb pro
        //-- date de modification : 13 mai 2026
        //----------------------------------------------------------------------------------//
        private void start_dmx_pro(object sender, EventArgs e)
        {
            if (DMX_device_selected == false)
            {

                if (Program.DMX_UBS_PRO.Connect("COM17"))
                {
                    DMX_device_selected = true;
                    DMX_which_device_selected = 2;
                    DMX_send_button.Enabled = true;
                }
            }
        }

        //----------------------------------------------------------------------------------//
        //-- nom fct : ouvrir_fichier_sauvegarder
        //-- paramètre entrée : object sender, EventArgs e
        //-- description : ouvre l'explorateur de fichier pour que l'utilisateur puisse 
        //-- selectionner le fichier dans le quel les informations sont sauvegarder
        //-- date de modification : 13 mai 2026
        //----------------------------------------------------------------------------------//
        const int WM_DEVICECHANGE = 0x0219;
        private void ouvrir_fichier_sauvegarder(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Dossier de départ (optionnel)
                openFileDialog.InitialDirectory = "c:\\";

                // Filtre pour les extensions (le format est : Nom|*.extension)
                openFileDialog.Filter = "Fichiers DMX (*.)|*.dmx|Tous les fichiers (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                // Affiche la boîte de dialogue et vérifie si l'utilisateur a cliqué sur OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Récupérer le chemin complet du fichier sélectionné
                    string filePath = openFileDialog.FileName;

                    // Lire le contenu du fichier (exemple)
                    string fileContent = File.ReadAllText(filePath);

                    MessageBox.Show("Fichier sélectionné : " + filePath);
                }
            }
        }

        // --- Ajoutez la méthode WndProc ici ---
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            // 0x0219 est le code Windows pour WM_DEVICECHANGE (changement matériel)
            if (m.Msg == WM_DEVICECHANGE)
            {
                Console.WriteLine("le bon code d'erreur est la ");
                if (DMX_which_device_selected == 2)
                {
                    DMX_which_device_selected = 0;
                    DMX_device_selected = false;
                    // On récupère la liste actuelle des ports COM connectés au PC
                    string[] ports = System.IO.Ports.SerialPort.GetPortNames();
                    // On vérifie si notre port est toujours dans la liste
                    bool portExists = ports.Contains("COM17");

                    if (!portExists)
                    {
                        // Action immédiate : On ferme proprement le port côté logiciel
                        Program.DMX_UBS_PRO.Disconnect();

                        // Alerte utilisateur
                        Console.WriteLine("Le boîtier DMX sur COM17 a été débranché !",
                                          "Déconnexion matérielle");
                        DMX_send_button.Enabled = false;


                    }
                }
                else if (DMX_which_device_selected == 1)
                {
                    // Pour l'OpenDMX, on ne regarde pas le port COM, on demande au driver si le handle est encore valide
                    if (!OpenDMX.IsDeviceStillConnected())
                    {
                        OpenDMX.Stop(); // On ferme proprement
                        DMX_which_device_selected = 0;
                        DMX_device_selected = false;
                        Console.WriteLine("OpenDMX débranché");
                        DMX_send_button.Enabled = false;
                    }
                }
            }
        }

        private void App_getting_closed(object sender, FormClosedEventArgs e)
        {
            if (DMX_which_device_selected == 1)
            {
                if (OpenDMX.status == FT_STATUS.FT_DEVICE_NOT_FOUND)
                    DMX_status.Text = "No Enttec USB Device Found";
                else
                    DMX_status.Text = "Found DMX on USB";
                byte buffer_value;
                Console.WriteLine("inside dmx sender");
                for (int index = 1; index < 511; index++)
                {
                    if (Program.adress_memory.Adress_list[index] == true)
                    {
                        buffer_value = (byte)Program.adress_memory.Value_list[index];
                        Console.WriteLine(index);
                        Console.WriteLine(buffer_value);
                        OpenDMX.setDmxValue(index - 1, 0);
                    }
                }
                OpenDMX.writeData();
            }

            if (DMX_which_device_selected == 2)
            {
                byte buffer_value;
                for (int index = 1; index < 511; index++)
                {
                    if (Program.adress_memory.Adress_list[index] == true)
                    {
                        buffer_value = (byte)Program.adress_memory.Value_list[index];
                        Program.DMX_UBS_PRO.SetChannel(index - 1, 0);
                    }
                }
                Program.DMX_UBS_PRO.SendTest();
            }
        }
    }



}
