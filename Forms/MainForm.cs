using BookManager.Data;
using BookManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManager.Forms
{
    public partial class MainForm : Form
    {
        private BookRepository _repository;

        public MainForm()
        {
            InitializeComponent();

            // 연결 문자열 설정 (자신의 환경에 맞게 수정)
            string connStr = "Server=localhost;Database=BookDB;Trusted_Connection=True;Encrypt=False;";
            _repository = new BookRepository(connStr);

            LoadBooks(); // 책 불러오기
        }

        private void LoadBooks()
        {
            var books = _repository.GetAll();
            // DataGridView 등 컨트롤에 바인딩하는 코드 작성 예정
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeComponent()
        {
            btnLoad = new Button();
            dataGridView1 = new DataGridView();
            ((ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.BackgroundImageLayout = ImageLayout.None;
            btnLoad.Location = new Point(676, 12);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "btnLoad";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 198);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(758, 243);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // MainForm
            // 
            ClientSize = new Size(782, 453);
            Controls.Add(dataGridView1);
            Controls.Add(btnLoad);
            Name = "MainForm";
            ((ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    List<Book> books = _repository.GetAll();
                    dataGridViewBooks.DataSource = books;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("불러오기 실패: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private Button btnLoad;
        private DataGridView dataGridView1;
    }
}
