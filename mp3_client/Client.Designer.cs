namespace mp3_client
{
    partial class Client
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.get_mp3 = new System.Windows.Forms.GroupBox();
            this.musicList = new System.Windows.Forms.ListView();
            this.MusicName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BitRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.findBtn = new System.Windows.Forms.Button();
            this.musicListBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.downTxt = new System.Windows.Forms.TextBox();
            this.portTxt = new System.Windows.Forms.TextBox();
            this.ipTxt = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.Label();
            this.sv_music_list = new System.Windows.Forms.Label();
            this.down_list = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.Label();
            this.play_mp3 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.nextBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.prevBtn = new System.Windows.Forms.Button();
            this.choiceLabel = new System.Windows.Forms.Label();
            this.playList = new System.Windows.Forms.ListView();
            this.MusicName_p = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist_p = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayTime_p = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BitRate_p = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.play_list = new System.Windows.Forms.Label();
            this.removeBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.get_mp3.SuspendLayout();
            this.play_mp3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // get_mp3
            // 
            this.get_mp3.Controls.Add(this.musicList);
            this.get_mp3.Controls.Add(this.progressBar);
            this.get_mp3.Controls.Add(this.findBtn);
            this.get_mp3.Controls.Add(this.musicListBtn);
            this.get_mp3.Controls.Add(this.connectBtn);
            this.get_mp3.Controls.Add(this.downTxt);
            this.get_mp3.Controls.Add(this.portTxt);
            this.get_mp3.Controls.Add(this.ipTxt);
            this.get_mp3.Controls.Add(this.Port);
            this.get_mp3.Controls.Add(this.sv_music_list);
            this.get_mp3.Controls.Add(this.down_list);
            this.get_mp3.Controls.Add(this.IP);
            this.get_mp3.Location = new System.Drawing.Point(11, 18);
            this.get_mp3.Name = "get_mp3";
            this.get_mp3.Size = new System.Drawing.Size(428, 400);
            this.get_mp3.TabIndex = 0;
            this.get_mp3.TabStop = false;
            this.get_mp3.Text = "Get MP3 File";
            // 
            // musicList
            // 
            this.musicList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MusicName,
            this.Artist,
            this.PlayTime,
            this.BitRate});
            this.musicList.Location = new System.Drawing.Point(8, 226);
            this.musicList.Name = "musicList";
            this.musicList.Size = new System.Drawing.Size(401, 168);
            this.musicList.TabIndex = 3;
            this.musicList.UseCompatibleStateImageBehavior = false;
            this.musicList.View = System.Windows.Forms.View.Details;
            // 
            // MusicName
            // 
            this.MusicName.Text = "Music Name";
            this.MusicName.Width = 156;
            // 
            // Artist
            // 
            this.Artist.Text = "Artist";
            this.Artist.Width = 83;
            // 
            // PlayTime
            // 
            this.PlayTime.Text = "Play Time";
            this.PlayTime.Width = 96;
            // 
            // BitRate
            // 
            this.BitRate.Text = "BIt Rate";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 146);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(403, 23);
            this.progressBar.TabIndex = 3;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(240, 61);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(169, 37);
            this.findBtn.TabIndex = 2;
            this.findBtn.Text = "FindPath";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // musicListBtn
            // 
            this.musicListBtn.Location = new System.Drawing.Point(249, 195);
            this.musicListBtn.Name = "musicListBtn";
            this.musicListBtn.Size = new System.Drawing.Size(160, 25);
            this.musicListBtn.TabIndex = 2;
            this.musicListBtn.Text = "재생 목록에 추가";
            this.musicListBtn.UseVisualStyleBackColor = true;
            this.musicListBtn.Click += new System.EventHandler(this.add_list_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(25, 63);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(158, 37);
            this.connectBtn.TabIndex = 2;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // downTxt
            // 
            this.downTxt.Enabled = false;
            this.downTxt.Location = new System.Drawing.Point(167, 109);
            this.downTxt.Name = "downTxt";
            this.downTxt.Size = new System.Drawing.Size(242, 21);
            this.downTxt.TabIndex = 1;
            // 
            // portTxt
            // 
            this.portTxt.Location = new System.Drawing.Point(240, 34);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(169, 21);
            this.portTxt.TabIndex = 1;
            // 
            // ipTxt
            // 
            this.ipTxt.Location = new System.Drawing.Point(25, 36);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(158, 21);
            this.ipTxt.TabIndex = 1;
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(207, 37);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(27, 12);
            this.Port.TabIndex = 0;
            this.Port.Text = "Port";
            // 
            // sv_music_list
            // 
            this.sv_music_list.AutoSize = true;
            this.sv_music_list.Location = new System.Drawing.Point(6, 201);
            this.sv_music_list.Name = "sv_music_list";
            this.sv_music_list.Size = new System.Drawing.Size(104, 12);
            this.sv_music_list.TabIndex = 0;
            this.sv_music_list.Text = "Server Music List";
            // 
            // down_list
            // 
            this.down_list.AutoSize = true;
            this.down_list.Location = new System.Drawing.Point(6, 112);
            this.down_list.Name = "down_list";
            this.down_list.Size = new System.Drawing.Size(155, 12);
            this.down_list.TabIndex = 0;
            this.down_list.Text = "MP3 File Download Path : ";
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Location = new System.Drawing.Point(1, 39);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(28, 12);
            this.IP.TabIndex = 0;
            this.IP.Text = "IP : ";
            // 
            // play_mp3
            // 
            this.play_mp3.Controls.Add(this.comboBox1);
            this.play_mp3.Controls.Add(this.trackBar1);
            this.play_mp3.Controls.Add(this.nextBtn);
            this.play_mp3.Controls.Add(this.playBtn);
            this.play_mp3.Controls.Add(this.prevBtn);
            this.play_mp3.Controls.Add(this.choiceLabel);
            this.play_mp3.Controls.Add(this.playList);
            this.play_mp3.Controls.Add(this.label1);
            this.play_mp3.Controls.Add(this.play_list);
            this.play_mp3.Controls.Add(this.removeBtn);
            this.play_mp3.Location = new System.Drawing.Point(456, 12);
            this.play_mp3.Name = "play_mp3";
            this.play_mp3.Size = new System.Drawing.Size(439, 400);
            this.play_mp3.TabIndex = 0;
            this.play_mp3.TabStop = false;
            this.play_mp3.Text = "Play MP3 Files";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "설정 안함",
            "한곡 재생",
            "랜덤 재생"});
            this.comboBox1.Location = new System.Drawing.Point(101, 186);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(98, 20);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(81, 55);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(275, 45);
            this.trackBar1.TabIndex = 5;
            // 
            // nextBtn
            // 
            this.nextBtn.Image = global::mp3_client.Properties.Resources.Next;
            this.nextBtn.Location = new System.Drawing.Point(292, 100);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(77, 75);
            this.nextBtn.TabIndex = 4;
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.ImageIndex = 0;
            this.playBtn.ImageList = this.imageList1;
            this.playBtn.Location = new System.Drawing.Point(181, 100);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(77, 75);
            this.playBtn.TabIndex = 4;
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Play");
            this.imageList1.Images.SetKeyName(1, "Pause");
            // 
            // prevBtn
            // 
            this.prevBtn.Image = global::mp3_client.Properties.Resources.Prev;
            this.prevBtn.Location = new System.Drawing.Point(71, 100);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(77, 75);
            this.prevBtn.TabIndex = 4;
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // choiceLabel
            // 
            this.choiceLabel.Location = new System.Drawing.Point(19, 40);
            this.choiceLabel.MaximumSize = new System.Drawing.Size(400, 300);
            this.choiceLabel.Name = "choiceLabel";
            this.choiceLabel.Size = new System.Drawing.Size(400, 12);
            this.choiceLabel.TabIndex = 1;
            this.choiceLabel.Text = "선택 된 곡이 없습니다";
            this.choiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playList
            // 
            this.playList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MusicName_p,
            this.Artist_p,
            this.PlayTime_p,
            this.BitRate_p});
            this.playList.Location = new System.Drawing.Point(60, 232);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(309, 168);
            this.playList.TabIndex = 3;
            this.playList.UseCompatibleStateImageBehavior = false;
            this.playList.View = System.Windows.Forms.View.Details;
            // 
            // MusicName_p
            // 
            this.MusicName_p.Text = "Music Name";
            this.MusicName_p.Width = 89;
            // 
            // Artist_p
            // 
            this.Artist_p.Text = "Artist";
            // 
            // PlayTime_p
            // 
            this.PlayTime_p.Text = "Play Time";
            this.PlayTime_p.Width = 92;
            // 
            // BitRate_p
            // 
            this.BitRate_p.Text = "BIt Rate";
            // 
            // play_list
            // 
            this.play_list.AutoSize = true;
            this.play_list.Location = new System.Drawing.Point(58, 214);
            this.play_list.Name = "play_list";
            this.play_list.Size = new System.Drawing.Size(54, 12);
            this.play_list.TabIndex = 0;
            this.play_list.Text = "Play List";
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(216, 201);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(153, 25);
            this.removeBtn.TabIndex = 2;
            this.removeBtn.Text = "재생 목록에서 삭제";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mode";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 429);
            this.Controls.Add(this.play_mp3);
            this.Controls.Add(this.get_mp3);
            this.Name = "Client";
            this.Text = "Music Player - Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.Load += new System.EventHandler(this.Client_Load);
            this.get_mp3.ResumeLayout(false);
            this.get_mp3.PerformLayout();
            this.play_mp3.ResumeLayout(false);
            this.play_mp3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox get_mp3;
        private System.Windows.Forms.GroupBox play_mp3;
        private System.Windows.Forms.ListView musicList;
        private System.Windows.Forms.ColumnHeader MusicName;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader PlayTime;
        private System.Windows.Forms.ColumnHeader BitRate;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Button musicListBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox downTxt;
        private System.Windows.Forms.TextBox portTxt;
        private System.Windows.Forms.TextBox ipTxt;
        private System.Windows.Forms.Label Port;
        private System.Windows.Forms.Label sv_music_list;
        private System.Windows.Forms.Label down_list;
        private System.Windows.Forms.Label IP;
        private System.Windows.Forms.ListView playList;
        private System.Windows.Forms.ColumnHeader MusicName_p;
        private System.Windows.Forms.ColumnHeader Artist_p;
        private System.Windows.Forms.ColumnHeader PlayTime_p;
        private System.Windows.Forms.ColumnHeader BitRate_p;
        private System.Windows.Forms.Label play_list;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label choiceLabel;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}

