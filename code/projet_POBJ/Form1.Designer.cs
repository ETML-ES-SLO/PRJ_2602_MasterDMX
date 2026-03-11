namespace projet_POBJ
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Value_Box = new System.Windows.Forms.GroupBox();
            this.Value_device_4 = new System.Windows.Forms.TextBox();
            this.Value_device_3 = new System.Windows.Forms.TextBox();
            this.Value_device_2 = new System.Windows.Forms.TextBox();
            this.Value_device_1 = new System.Windows.Forms.TextBox();
            this.Name_Box = new System.Windows.Forms.GroupBox();
            this.Device_4 = new System.Windows.Forms.TextBox();
            this.Device_3 = new System.Windows.Forms.TextBox();
            this.Device_2 = new System.Windows.Forms.TextBox();
            this.Device_1 = new System.Windows.Forms.TextBox();
            this.Next_Page_Channel = new System.Windows.Forms.Button();
            this.Prev_Page_Channel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Creation_starting_adress = new System.Windows.Forms.TextBox();
            this.mettreadresse = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Creation_Number_channel = new System.Windows.Forms.TextBox();
            this.Creation_Device_Name = new System.Windows.Forms.TextBox();
            this.New_Validate_device = new System.Windows.Forms.Button();
            this.timer_validate_button = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.adressbox = new System.Windows.Forms.GroupBox();
            this.Adress_device4 = new System.Windows.Forms.TextBox();
            this.Adress_device3 = new System.Windows.Forms.TextBox();
            this.Adress_device2 = new System.Windows.Forms.TextBox();
            this.Adress_device1 = new System.Windows.Forms.TextBox();
            this.DMX_send_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.Value_Box.SuspendLayout();
            this.Name_Box.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.adressbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.adressbox);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.Value_Box);
            this.groupBox1.Controls.Add(this.Name_Box);
            this.groupBox1.Controls.Add(this.Next_Page_Channel);
            this.groupBox1.Controls.Add(this.Prev_Page_Channel);
            this.groupBox1.Location = new System.Drawing.Point(671, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 320);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Device Channel Manager";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(134, 286);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "debug";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.debug);
            // 
            // Value_Box
            // 
            this.Value_Box.Controls.Add(this.Value_device_4);
            this.Value_Box.Controls.Add(this.Value_device_3);
            this.Value_Box.Controls.Add(this.Value_device_2);
            this.Value_Box.Controls.Add(this.Value_device_1);
            this.Value_Box.Location = new System.Drawing.Point(117, 49);
            this.Value_Box.Name = "Value_Box";
            this.Value_Box.Size = new System.Drawing.Size(87, 200);
            this.Value_Box.TabIndex = 3;
            this.Value_Box.TabStop = false;
            this.Value_Box.Text = "Value";
            // 
            // Value_device_4
            // 
            this.Value_device_4.Location = new System.Drawing.Point(6, 160);
            this.Value_device_4.Name = "Value_device_4";
            this.Value_device_4.Size = new System.Drawing.Size(75, 20);
            this.Value_device_4.TabIndex = 3;
            this.Value_device_4.Validated += new System.EventHandler(this.Value_device_4_text_changed);
            // 
            // Value_device_3
            // 
            this.Value_device_3.Location = new System.Drawing.Point(6, 120);
            this.Value_device_3.Name = "Value_device_3";
            this.Value_device_3.Size = new System.Drawing.Size(75, 20);
            this.Value_device_3.TabIndex = 2;
            this.Value_device_3.Validated += new System.EventHandler(this.Value_device_3_text_changed);
            // 
            // Value_device_2
            // 
            this.Value_device_2.Location = new System.Drawing.Point(6, 80);
            this.Value_device_2.Name = "Value_device_2";
            this.Value_device_2.Size = new System.Drawing.Size(75, 20);
            this.Value_device_2.TabIndex = 1;
            this.Value_device_2.Validated += new System.EventHandler(this.Value_device_2_text_changed);
            // 
            // Value_device_1
            // 
            this.Value_device_1.Location = new System.Drawing.Point(6, 40);
            this.Value_device_1.Name = "Value_device_1";
            this.Value_device_1.Size = new System.Drawing.Size(75, 20);
            this.Value_device_1.TabIndex = 0;
            this.Value_device_1.Validated += new System.EventHandler(this.Value_device_1_text_changed);
            // 
            // Name_Box
            // 
            this.Name_Box.Controls.Add(this.Device_4);
            this.Name_Box.Controls.Add(this.Device_3);
            this.Name_Box.Controls.Add(this.Device_2);
            this.Name_Box.Controls.Add(this.Device_1);
            this.Name_Box.Location = new System.Drawing.Point(9, 49);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.Size = new System.Drawing.Size(87, 200);
            this.Name_Box.TabIndex = 2;
            this.Name_Box.TabStop = false;
            this.Name_Box.Text = "Name";
            // 
            // Device_4
            // 
            this.Device_4.Location = new System.Drawing.Point(6, 160);
            this.Device_4.Name = "Device_4";
            this.Device_4.Size = new System.Drawing.Size(75, 20);
            this.Device_4.TabIndex = 3;
            this.Device_4.Validated += new System.EventHandler(this.Device_4_text_changed);
            // 
            // Device_3
            // 
            this.Device_3.Location = new System.Drawing.Point(6, 120);
            this.Device_3.Name = "Device_3";
            this.Device_3.Size = new System.Drawing.Size(75, 20);
            this.Device_3.TabIndex = 2;
            this.Device_3.Validated += new System.EventHandler(this.Device_3_text_changed);
            // 
            // Device_2
            // 
            this.Device_2.Location = new System.Drawing.Point(6, 80);
            this.Device_2.Name = "Device_2";
            this.Device_2.Size = new System.Drawing.Size(75, 20);
            this.Device_2.TabIndex = 1;
            this.Device_2.Validated += new System.EventHandler(this.Device_2_text_changed);
            // 
            // Device_1
            // 
            this.Device_1.Location = new System.Drawing.Point(6, 40);
            this.Device_1.Name = "Device_1";
            this.Device_1.Size = new System.Drawing.Size(75, 20);
            this.Device_1.TabIndex = 0;
            this.Device_1.Validated += new System.EventHandler(this.Device_1_text_changed);
            // 
            // Next_Page_Channel
            // 
            this.Next_Page_Channel.BackColor = System.Drawing.SystemColors.Control;
            this.Next_Page_Channel.Location = new System.Drawing.Point(193, 286);
            this.Next_Page_Channel.Name = "Next_Page_Channel";
            this.Next_Page_Channel.Size = new System.Drawing.Size(109, 23);
            this.Next_Page_Channel.TabIndex = 1;
            this.Next_Page_Channel.Text = "Next page";
            this.Next_Page_Channel.UseVisualStyleBackColor = false;
            this.Next_Page_Channel.Click += new System.EventHandler(this.Next_Page);
            // 
            // Prev_Page_Channel
            // 
            this.Prev_Page_Channel.BackColor = System.Drawing.SystemColors.Control;
            this.Prev_Page_Channel.Location = new System.Drawing.Point(9, 286);
            this.Prev_Page_Channel.Name = "Prev_Page_Channel";
            this.Prev_Page_Channel.Size = new System.Drawing.Size(119, 23);
            this.Prev_Page_Channel.TabIndex = 0;
            this.Prev_Page_Channel.Text = "Prev page";
            this.Prev_Page_Channel.UseVisualStyleBackColor = false;
            this.Prev_Page_Channel.Click += new System.EventHandler(this.Prev_Page);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Creation_starting_adress);
            this.groupBox2.Controls.Add(this.mettreadresse);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Creation_Number_channel);
            this.groupBox2.Controls.Add(this.Creation_Device_Name);
            this.groupBox2.Controls.Add(this.New_Validate_device);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 320);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device Creation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Start adress";
            // 
            // Creation_starting_adress
            // 
            this.Creation_starting_adress.Location = new System.Drawing.Point(219, 154);
            this.Creation_starting_adress.Name = "Creation_starting_adress";
            this.Creation_starting_adress.Size = new System.Drawing.Size(75, 20);
            this.Creation_starting_adress.TabIndex = 6;
            this.Creation_starting_adress.Validated += new System.EventHandler(this.start_adresse_changed);
            // 
            // mettreadresse
            // 
            this.mettreadresse.AutoSize = true;
            this.mettreadresse.Location = new System.Drawing.Point(58, 68);
            this.mettreadresse.Name = "mettreadresse";
            this.mettreadresse.Size = new System.Drawing.Size(76, 13);
            this.mettreadresse.TabIndex = 5;
            this.mettreadresse.Text = "mettre adresse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Channel Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Device Name";
            // 
            // Creation_Number_channel
            // 
            this.Creation_Number_channel.Location = new System.Drawing.Point(119, 154);
            this.Creation_Number_channel.Name = "Creation_Number_channel";
            this.Creation_Number_channel.Size = new System.Drawing.Size(75, 20);
            this.Creation_Number_channel.TabIndex = 2;
            this.Creation_Number_channel.TextChanged += new System.EventHandler(this.Channel_number_changed);
            // 
            // Creation_Device_Name
            // 
            this.Creation_Device_Name.Location = new System.Drawing.Point(22, 154);
            this.Creation_Device_Name.Name = "Creation_Device_Name";
            this.Creation_Device_Name.Size = new System.Drawing.Size(75, 20);
            this.Creation_Device_Name.TabIndex = 1;
            this.Creation_Device_Name.TextChanged += new System.EventHandler(this.Device_Name_Changed);
            // 
            // New_Validate_device
            // 
            this.New_Validate_device.Location = new System.Drawing.Point(92, 226);
            this.New_Validate_device.Name = "New_Validate_device";
            this.New_Validate_device.Size = new System.Drawing.Size(110, 41);
            this.New_Validate_device.TabIndex = 0;
            this.New_Validate_device.Text = "New Device";
            this.New_Validate_device.UseVisualStyleBackColor = true;
            this.New_Validate_device.Click += new System.EventHandler(this.New_device_click);
            // 
            // timer_validate_button
            // 
            this.timer_validate_button.Interval = 500;
            this.timer_validate_button.Tick += new System.EventHandler(this.Timer_Validate_button_is_done);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxDevice);
            this.groupBox3.Location = new System.Drawing.Point(398, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(227, 319);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Device list";
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Location = new System.Drawing.Point(25, 19);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(185, 21);
            this.comboBoxDevice.TabIndex = 2;
            this.comboBoxDevice.SelectedIndexChanged += new System.EventHandler(this.Device_Changed);
            // 
            // adressbox
            // 
            this.adressbox.Controls.Add(this.Adress_device4);
            this.adressbox.Controls.Add(this.Adress_device3);
            this.adressbox.Controls.Add(this.Adress_device2);
            this.adressbox.Controls.Add(this.Adress_device1);
            this.adressbox.Location = new System.Drawing.Point(221, 49);
            this.adressbox.Name = "adressbox";
            this.adressbox.Size = new System.Drawing.Size(87, 200);
            this.adressbox.TabIndex = 5;
            this.adressbox.TabStop = false;
            this.adressbox.Text = "Adress";
            // 
            // Adress_device4
            // 
            this.Adress_device4.Location = new System.Drawing.Point(6, 160);
            this.Adress_device4.Name = "Adress_device4";
            this.Adress_device4.Size = new System.Drawing.Size(75, 20);
            this.Adress_device4.TabIndex = 3;
            // 
            // Adress_device3
            // 
            this.Adress_device3.Location = new System.Drawing.Point(6, 120);
            this.Adress_device3.Name = "Adress_device3";
            this.Adress_device3.Size = new System.Drawing.Size(75, 20);
            this.Adress_device3.TabIndex = 2;
            // 
            // Adress_device2
            // 
            this.Adress_device2.Location = new System.Drawing.Point(6, 80);
            this.Adress_device2.Name = "Adress_device2";
            this.Adress_device2.Size = new System.Drawing.Size(75, 20);
            this.Adress_device2.TabIndex = 1;
            // 
            // Adress_device1
            // 
            this.Adress_device1.Location = new System.Drawing.Point(6, 40);
            this.Adress_device1.Name = "Adress_device1";
            this.Adress_device1.Size = new System.Drawing.Size(75, 20);
            this.Adress_device1.TabIndex = 0;
            // 
            // DMX_send_button
            // 
            this.DMX_send_button.Location = new System.Drawing.Point(104, 339);
            this.DMX_send_button.Name = "DMX_send_button";
            this.DMX_send_button.Size = new System.Drawing.Size(110, 31);
            this.DMX_send_button.TabIndex = 3;
            this.DMX_send_button.Text = "send_dmx";
            this.DMX_send_button.UseVisualStyleBackColor = true;
            this.DMX_send_button.Click += new System.EventHandler(this.Send_dmx_to_interface);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.start_dmx_interface);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 382);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DMX_send_button);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.Value_Box.ResumeLayout(false);
            this.Value_Box.PerformLayout();
            this.Name_Box.ResumeLayout(false);
            this.Name_Box.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.adressbox.ResumeLayout(false);
            this.adressbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Next_Page_Channel;
        private System.Windows.Forms.Button Prev_Page_Channel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox Value_Box;
        private System.Windows.Forms.TextBox Value_device_4;
        private System.Windows.Forms.TextBox Value_device_3;
        private System.Windows.Forms.TextBox Value_device_2;
        private System.Windows.Forms.TextBox Value_device_1;
        private System.Windows.Forms.GroupBox Name_Box;
        private System.Windows.Forms.TextBox Device_4;
        private System.Windows.Forms.TextBox Device_3;
        private System.Windows.Forms.TextBox Device_2;
        private System.Windows.Forms.TextBox Device_1;
        private System.Windows.Forms.Button New_Validate_device;
        private System.Windows.Forms.Timer timer_validate_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Creation_Number_channel;
        private System.Windows.Forms.TextBox Creation_Device_Name;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.Label mettreadresse;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Creation_starting_adress;
        private System.Windows.Forms.GroupBox adressbox;
        private System.Windows.Forms.TextBox Adress_device4;
        private System.Windows.Forms.TextBox Adress_device3;
        private System.Windows.Forms.TextBox Adress_device2;
        private System.Windows.Forms.TextBox Adress_device1;
        private System.Windows.Forms.Button DMX_send_button;
        private System.Windows.Forms.Button button1;
    }
}

