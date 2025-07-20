using BookManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManager.NewFolder
{
    public partial class MainForm : Form
    {
        private BookRepository _repository;

        public MainForm()
        {
            InitializeComponent();

            // 연결 문자열 설정 (자신의 환경에 맞게 수정)
            string connStr = "Server=localhost;Database=BookDB;Trusted_Connection=True;Encrypt;";
            _repository = new BookRepository(connStr);

            LoadBooks(); // 폼 로드시 책 목록 불러오기 (예시)
        }

        private void LoadBooks()
        {
            var books = _repository.GetAll();
            // DataGridView 등 컨트롤에 바인딩하는 코드 작성 예정
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
