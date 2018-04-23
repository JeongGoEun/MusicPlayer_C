namespace mp3_server
{
    partial class Server
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_IP = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.label_Port = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.storage_path = new System.Windows.Forms.Label();
            this.pathTxt = new System.Windows.Forms.TextBox();
            this.pathBtn = new System.Windows.Forms.Button();
            this.lb_state = new System.Windows.Forms.Label();
            this.lb_m_list = new System.Windows.Forms.Label();
            this.stateTxt = new System.Windows.Forms.TextBox();
            this.musicList = new System.Windows.Forms.ListView();
            this.m_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BitRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(13, 12);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(28, 12);
            this.label_IP.TabIndex = 0;
            this.label_IP.Text = "IP : ";
            // 
            // txt_IP
            // 
            this.txt_IP.Enabled = false;
            this.txt_IP.Location = new System.Drawing.Point(47, 9);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(183, 21);
            this.txt_IP.TabIndex = 1;
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(247, 12);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(39, 12);
            this.label_Port.TabIndex = 2;
            this.label_Port.Text = "Port : ";
            // 
            // txt_Port
            // 
            this.txt_Port.Enabled = false;
            this.txt_Port.Location = new System.Drawing.Point(283, 9);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(100, 21);
            this.txt_Port.TabIndex = 3;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(412, 7);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(93, 23);
            this.startBtn.TabIndex = 4;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // storage_path
            // 
            this.storage_path.AutoSize = true;
            this.storage_path.Location = new System.Drawing.Point(31, 58);
            this.storage_path.Name = "storage_path";
            this.storage_path.Size = new System.Drawing.Size(142, 12);
            this.storage_path.TabIndex = 0;
            this.storage_path.Text = "MP3 File Storage Path : ";
            // 
            // pathTxt
            // 
            this.pathTxt.Location = new System.Drawing.Point(179, 55);
            this.pathTxt.Name = "pathTxt";
            this.pathTxt.Size = new System.Drawing.Size(183, 21);
            this.pathTxt.TabIndex = 1;
            // 
            // pathBtn
            // 
            this.pathBtn.Location = new System.Drawing.Point(389, 53);
            this.pathBtn.Name = "pathBtn";
            this.pathBtn.Size = new System.Drawing.Size(93, 23);
            this.pathBtn.TabIndex = 4;
            this.pathBtn.Text = "Find Path";
            this.pathBtn.UseVisualStyleBackColor = true;
            this.pathBtn.Click += new System.EventHandler(this.pathBtn_Click);
            // 
            // lb_state
            // 
            this.lb_state.AutoSize = true;
            this.lb_state.Location = new System.Drawing.Point(13, 114);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(57, 12);
            this.lb_state.TabIndex = 0;
            this.lb_state.Text = "서버 상태";
            // 
            // lb_m_list
            // 
            this.lb_m_list.AutoSize = true;
            this.lb_m_list.Location = new System.Drawing.Point(268, 114);
            this.lb_m_list.Name = "lb_m_list";
            this.lb_m_list.Size = new System.Drawing.Size(64, 12);
            this.lb_m_list.TabIndex = 0;
            this.lb_m_list.Text = "Music List";
            // 
            // stateTxt
            // 
            this.stateTxt.Location = new System.Drawing.Point(12, 129);
            this.stateTxt.Multiline = true;
            this.stateTxt.Name = "stateTxt";
            this.stateTxt.Size = new System.Drawing.Size(233, 234);
            this.stateTxt.TabIndex = 5;
            // 
            // musicList
            // 
            this.musicList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_name,
            this.Artist,
            this.PlayTime,
            this.BitRate});
            this.musicList.Location = new System.Drawing.Point(270, 129);
            this.musicList.Name = "musicList";
            this.musicList.Size = new System.Drawing.Size(293, 233);
            this.musicList.TabIndex = 6;
            this.musicList.UseCompatibleStateImageBehavior = false;
            this.musicList.View = System.Windows.Forms.View.Details;
            // 
            // m_name
            // 
            this.m_name.Text = "Music Name";
            this.m_name.Width = 85;
            // 
            // Artist
            // 
            this.Artist.Text = "Artist";
            // 
            // PlayTime
            // 
            this.PlayTime.Text = "Play Time";
            this.PlayTime.Width = 84;
            // 
            // BitRate
            // 
            this.BitRate.Text = "Bit Rate";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 374);
            this.Controls.Add(this.musicList);
            this.Controls.Add(this.stateTxt);
            this.Controls.Add(this.pathBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.pathTxt);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.storage_path);
            this.Controls.Add(this.lb_m_list);
            this.Controls.Add(this.lb_state);
            this.Controls.Add(this.label_IP);
            this.Name = "Server";
            this.Text = "Music Player - Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label storage_path;
        private System.Windows.Forms.TextBox pathTxt;
        private System.Windows.Forms.Button pathBtn;
        private System.Windows.Forms.Label lb_state;
        private System.Windows.Forms.Label lb_m_list;
        private System.Windows.Forms.TextBox stateTxt;
        private System.Windows.Forms.ListView musicList;
        private System.Windows.Forms.ColumnHeader m_name;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader PlayTime;
        private System.Windows.Forms.ColumnHeader BitRate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

