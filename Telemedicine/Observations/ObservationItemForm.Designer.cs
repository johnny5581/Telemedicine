﻿namespace Telemedicine.Observations
{
    partial class ObservationItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBodySite = new Telemedicine.Forms.CgLabelComboBox();
            this.cgLabelDateTimeRange1 = new Telemedicine.CgLabelDateTimeRange();
            this.buttonInsert = new Telemedicine.Forms.CgIconButton();
            this.cgFlowLayoutPanel1 = new Telemedicine.Forms.CgFlowLayoutPanel();
            this.textValue = new Telemedicine.Forms.CgLabelTextBox();
            this.textUnit = new Telemedicine.Forms.CgLabelTextBox();
            this.comboItem = new Telemedicine.Forms.CgLabelComboBox();
            this.buttonOk = new Telemedicine.Forms.CgIconButton();
            this.buttonCancel = new Telemedicine.Forms.CgIconButton();
            this.cgFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBodySite
            // 
            this.comboBodySite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBodySite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBodySite.Header = "身體部位";
            this.comboBodySite.Location = new System.Drawing.Point(12, 85);
            this.comboBodySite.Name = "comboBodySite";
            this.comboBodySite.Size = new System.Drawing.Size(273, 31);
            this.comboBodySite.TabIndex = 17;
            // 
            // cgLabelDateTimeRange1
            // 
            this.cgLabelDateTimeRange1.ComponentHeight = 50;
            this.cgLabelDateTimeRange1.EndTimeAvaliable = false;
            this.cgLabelDateTimeRange1.Header = "時間";
            this.cgLabelDateTimeRange1.Location = new System.Drawing.Point(12, 128);
            this.cgLabelDateTimeRange1.Name = "cgLabelDateTimeRange1";
            this.cgLabelDateTimeRange1.Size = new System.Drawing.Size(273, 58);
            this.cgLabelDateTimeRange1.TabIndex = 16;
            this.cgLabelDateTimeRange1.Text = "cgLabelDateTimeRange1";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonInsert.Location = new System.Drawing.Point(47, 374);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(75, 23);
            this.buttonInsert.TabIndex = 15;
            this.buttonInsert.Text = "新增";
            this.buttonInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Visible = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // cgFlowLayoutPanel1
            // 
            this.cgFlowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cgFlowLayoutPanel1.AutoMargin = true;
            this.cgFlowLayoutPanel1.AutoMarginSize = new System.Windows.Forms.Padding(0);
            this.cgFlowLayoutPanel1.AutoResizeChild = true;
            this.cgFlowLayoutPanel1.Controls.Add(this.textValue);
            this.cgFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cgFlowLayoutPanel1.Location = new System.Drawing.Point(12, 192);
            this.cgFlowLayoutPanel1.Name = "cgFlowLayoutPanel1";
            this.cgFlowLayoutPanel1.Size = new System.Drawing.Size(273, 176);
            this.cgFlowLayoutPanel1.TabIndex = 12;
            this.cgFlowLayoutPanel1.WrapContents = false;
            // 
            // textValue
            // 
            this.textValue.Header = "數值";
            this.textValue.Location = new System.Drawing.Point(3, 3);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(233, 30);
            this.textValue.TabIndex = 1;
            // 
            // textUnit
            // 
            this.textUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textUnit.Header = "單位";
            this.textUnit.Location = new System.Drawing.Point(12, 49);
            this.textUnit.Name = "textUnit";
            this.textUnit.ReadOnly = true;
            this.textUnit.Size = new System.Drawing.Size(273, 30);
            this.textUnit.TabIndex = 11;
            // 
            // comboItem
            // 
            this.comboItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboItem.Header = "類別";
            this.comboItem.Location = new System.Drawing.Point(12, 12);
            this.comboItem.Name = "comboItem";
            this.comboItem.Size = new System.Drawing.Size(273, 31);
            this.comboItem.TabIndex = 10;
            this.comboItem.SelectedIndexChanged += new System.EventHandler(this.comboItem_SelectedIndexChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonOk.Location = new System.Drawing.Point(129, 374);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 9;
            this.buttonOk.Text = "確定";
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancel.Location = new System.Drawing.Point(210, 374);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ObservationItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 409);
            this.Controls.Add(this.comboBodySite);
            this.Controls.Add(this.cgLabelDateTimeRange1);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.cgFlowLayoutPanel1);
            this.Controls.Add(this.textUnit);
            this.Controls.Add(this.comboItem);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Name = "ObservationItemForm";
            this.Text = "新增生理數值";
            this.cgFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.CgIconButton buttonOk;
        private Forms.CgIconButton buttonCancel;
        private Forms.CgLabelTextBox textUnit;
        private Forms.CgLabelComboBox comboItem;
        private Forms.CgFlowLayoutPanel cgFlowLayoutPanel1;
        private Forms.CgLabelTextBox textValue;
        private Forms.CgIconButton buttonInsert;
        private CgLabelDateTimeRange cgLabelDateTimeRange1;
        private Forms.CgLabelComboBox comboBodySite;
    }
}