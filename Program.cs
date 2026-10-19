
using System.Runtime.InteropServices;
using Npgsql;

var conectionString = "Host = localhost; Port = 5432 ; Database = shop1_db ; Username = postgres ; Password = 1234";

// try
// {
//     using var conn = new NpgsqlConnection(conectionString);
//     conn.Open();
//     System.Console.WriteLine("Greatful");
// }
// catch(NpgsqlException ex)
// {
//     Console.WriteLine("Ошибка при работе с PostgreSQL. Проверь подключение к базе данных.");
//     Console.WriteLine($"Подробности: {ex.Message}");
// }

using var conn = new NpgsqlConnection(conectionString);
conn.Open();
// var createCommand = new NpgsqlCommand(
//     @"CREATE TABLE IF NOT EXISTS books (
//         id SERIAL PRIMARY KEY,
//         title VARCHAR(200) NOT NULL,
//         published_year INT,
//         total_copies INT NOT NULL DEFAULT 1
//     );",
//     conn
// );
// var command = new NpgsqlCommand("insert into books (title, published_year, total_copies) values ('Clean Code', 2008, 3), ('The Pragmatic Programmer', 1999, 2), ('Refactoring', 1999, 1);" , conn);

// var query = new NpgsqlCommand("SELECT COUNT(*) FROM products;" , conn);
// var count = query.ExecuteScalar();
// System.Console.WriteLine($"Total books in database: {count}");

var cmd = new NpgsqlCommand("select * from products" , conn);

var reader = cmd.ExecuteReader();

while(reader.Read())
{
    System.Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
}