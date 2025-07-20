using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookManager.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Data
{
    public class BookRepository
    {
        private readonly string _connectionString;

        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        // [1] 도서 전체 조회
        public List<Book> GetAll()
        {
            var books = new List<Book>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Book";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            Publisher = reader["Publisher"].ToString(),
                            PublishedDate = Convert.ToDateTime(reader["PublishedDate"])
                        });
                    }
                }
            }

            return books;
        }


        // [2] 도서 추가
        public void Add(Book book)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Book (Title, Author, Publisher, PublishedDate)
                               VALUES (@Title, @Author, @Publisher, @PublishedDate)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                    cmd.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // [3] 도서 수정
        public void Update(Book book)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Book SET 
                               Title = @Title,
                               Author = @Author,
                               Publisher = @Publisher,
                               PublishedDate = @PublishedDate
                               WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                    cmd.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
                    cmd.Parameters.AddWithValue("@Id", book.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // [4] 도서 삭제
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Book WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
