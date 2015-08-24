namespace ButtonTest
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonEnglish = new System.Windows.Forms.Button();
            this.buttonDanish = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEnglish
            // 
            this.buttonEnglish.Image = global::ButtonTest.Properties.Resources.uk;
            this.buttonEnglish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEnglish.Location = new System.Drawing.Point(20, 20);
            this.buttonEnglish.Name = "buttonEnglish";
            this.buttonEnglish.Size = new System.Drawing.Size(75, 28);
            this.buttonEnglish.TabIndex = 0;
            this.buttonEnglish.Text = "English";
            this.buttonEnglish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEnglish.UseVisualStyleBackColor = true;
            this.buttonEnglish.Click += new System.EventHandler(this.buttonEnglish_Click);
            // 
            // buttonDanish
            // 
            this.buttonDanish.Image = global::ButtonTest.Properties.Resources.dk;
            this.buttonDanish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDanish.Location = new System.Drawing.Point(150, 20);
            this.buttonDanish.Name = "buttonDanish";
            this.buttonDanish.Size = new System.Drawing.Size(75, 28);
            this.buttonDanish.TabIndex = 1;
            this.buttonDanish.Text = "Danish";
            this.buttonDanish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDanish.UseVisualStyleBackColor = true;
            this.buttonDanish.Click += new System.EventHandler(this.buttonDanish_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(85, 68);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 28);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 111);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonDanish);
            this.Controls.Add(this.buttonEnglish);
            this.Name = "Form1";
            this.Text = "Do you speak English?";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEnglish;
        private System.Windows.Forms.Button buttonDanish;
        private System.Windows.Forms.Button buttonOK;
    }
}

