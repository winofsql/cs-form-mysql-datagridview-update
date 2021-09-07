
namespace cs_form_framework_mysql_datagridview_update
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataMySQL = new System.Windows.Forms.DataGridView();
            this.getList = new System.Windows.Forms.Button();
            this.targetUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataMySQL)).BeginInit();
            this.SuspendLayout();
            // 
            // dataMySQL
            // 
            this.dataMySQL.AllowUserToAddRows = false;
            this.dataMySQL.AllowUserToDeleteRows = false;
            this.dataMySQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMySQL.Location = new System.Drawing.Point(36, 81);
            this.dataMySQL.Name = "dataMySQL";
            this.dataMySQL.RowTemplate.Height = 21;
            this.dataMySQL.Size = new System.Drawing.Size(896, 454);
            this.dataMySQL.TabIndex = 0;
            // 
            // getList
            // 
            this.getList.Location = new System.Drawing.Point(36, 28);
            this.getList.Name = "getList";
            this.getList.Size = new System.Drawing.Size(208, 31);
            this.getList.TabIndex = 1;
            this.getList.Text = "一覧";
            this.getList.UseVisualStyleBackColor = true;
            this.getList.Click += new System.EventHandler(this.button1_Click);
            // 
            // targetUpdate
            // 
            this.targetUpdate.Location = new System.Drawing.Point(282, 28);
            this.targetUpdate.Name = "targetUpdate";
            this.targetUpdate.Size = new System.Drawing.Size(208, 31);
            this.targetUpdate.TabIndex = 2;
            this.targetUpdate.Text = "更新";
            this.targetUpdate.UseVisualStyleBackColor = true;
            this.targetUpdate.Click += new System.EventHandler(this.targetUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 572);
            this.Controls.Add(this.targetUpdate);
            this.Controls.Add(this.getList);
            this.Controls.Add(this.dataMySQL);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataMySQL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataMySQL;
        private System.Windows.Forms.Button getList;
        private System.Windows.Forms.Button targetUpdate;
    }
}

