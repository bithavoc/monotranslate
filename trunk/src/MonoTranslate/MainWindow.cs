/*
 Copyright (C) 2007 Juan Emilio Gabito
 gabitoju@interntet.com.uy

 This file is part of MonoTranslate.

 MonoTranslate is free software; you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation; either version 2 of the License, or
 (at your option) any later version.

 MonoTranslate is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with MonoTranslate; if not, write to the Free Software
 Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MonoTranslate.Engine;

    public class MainWindow : Form
    {
    
    	private TranslatorEngine engine;
    
    	public MainWindow(TranslatorEngine t)
    	{
    		engine = t;
    		InitializeComponent();    		
    		LoadTranslators();
    	}

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtToTrnTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.transCbox = new System.Windows.Forms.ComboBox();
            this.langPairCbox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.transTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text to translate";
            //this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtToTrnTxt
            // 
            this.txtToTrnTxt.Location = new System.Drawing.Point(12, 36);
            this.txtToTrnTxt.Multiline = true;
            this.txtToTrnTxt.Name = "txtToTrnTxt";
            this.txtToTrnTxt.Size = new System.Drawing.Size(259, 110);
            this.txtToTrnTxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(9, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select translator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(147, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select languages";
            // 
            // transCbox
            // 
            //this.transCbox.FormattingEnabled = true;
            this.transCbox.Location = new System.Drawing.Point(12, 175);
            this.transCbox.Name = "transCbox";
            this.transCbox.Size = new System.Drawing.Size(121, 21);
            this.transCbox.TabIndex = 4;
            this.transCbox.SelectedIndexChanged += new System.EventHandler(this.transCbox_Select);
            // 
            // langPairCbox
            // 
           // this.langPairCbox.FormattingEnabled = true;
            this.langPairCbox.Location = new System.Drawing.Point(150, 175);
            this.langPairCbox.Name = "langPairCbox";
            this.langPairCbox.Size = new System.Drawing.Size(121, 21);
            this.langPairCbox.TabIndex = 5;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Translate";
            // 
            // transTxt
            // 
            this.transTxt.Location = new System.Drawing.Point(12, 247);
            this.transTxt.Multiline = true;
            this.transTxt.Name = "transTxt";
            this.transTxt.ReadOnly = true;
            this.transTxt.Size = new System.Drawing.Size(259, 110);
            this.transTxt.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(12, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Translated text";
            // 
            // Form1
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(287, 366);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.transTxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.langPairCbox);
            this.Controls.Add(this.transCbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToTrnTxt);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MonoTranslate";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

		private void LoadTranslators()
		{
			IEnumerator i = engine.GetTranslators().GetEnumerator();
			while (i.MoveNext())
			{
				this.transCbox.Items.Add((string)i.Current);
			}
		}
		
		private void transCbox_Select(object sender, System.EventArgs e)
		{
			string trans = (string)transCbox.SelectedItem;
			IList l = engine.GetLanguages(trans);
			IEnumerator i = l.GetEnumerator();
			while (i.MoveNext())
			{
				this.langPairCbox.Items.Add((string)i.Current);
			}			 
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtToTrnTxt.Text == "")
				{
					MessageBox.Show("Please, enter a text to translate.", "Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
					return;
				}
				if (this.transCbox.SelectedItem == null)
				{
					MessageBox.Show("Please, select a translator.", "Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
					return;
				}
				if (this.langPairCbox.SelectedItem == null)
				{
					MessageBox.Show("Please, select languages.", "Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
					return;
				}				
				string text = this.txtToTrnTxt.Text;
				string trans = (string)transCbox.SelectedItem;
				string pair = (string)this.langPairCbox.SelectedItem;
			
				string res = engine.Translate(text, pair, trans);
				this.transTxt.Text = res;
			}
			catch (System.Net.WebException ex)
			{
				MessageBox.Show("An error has ocurred. Check your Internet connection.", "Error", MessageBoxButtons.OK , MessageBoxIcon.Error);				
			}
		}

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtToTrnTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox transCbox;
        private System.Windows.Forms.ComboBox langPairCbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox transTxt;
        private System.Windows.Forms.Label label4;
    }
