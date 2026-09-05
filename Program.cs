using Microsoft.Data.SqlClient;

string conexao = @"Server=.\SQLEXPRESS;Database=Loja;Trusted_Connection=True;TrustServerCertificate=True;";

using SqlConnection conn = new SqlConnection(conexao);

try
{
    conn.Open();

    Console.WriteLine("Conectado ao banco Loja!");
    Console.WriteLine();

    Console.WriteLine("1 - Mostrar produtos");
    Console.WriteLine("2 - Comprar produto");
    Console.WriteLine("3 - Verificar estoque");
    Console.WriteLine("4 - Adicionar produto");
    Console.WriteLine("5 - Remover produto");
    Console.WriteLine("6 - Sair");

    Console.Write("Escolha uma opção: ");
    int opcao = int.Parse(Console.ReadLine()!);

    switch (opcao)
    {
        case 1:
        {
            string sql = "SELECT * FROM Produto";

            using SqlCommand comando = new SqlCommand(sql, conn);
            using SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                Console.WriteLine(
                    $"ID: {leitor["ID"]} | " +
                    $"Produto: {leitor["Nome"]} | " +
                    $"Quantidade: {leitor["Quantidade"]} | " +
                    $"Valor: R$ {leitor["Valor"]}"
                );
            }

            break;
        }

        case 2:
        {
            Console.Write("Digite o ID do produto que deseja comprar: ");
            int id = int.Parse(Console.ReadLine()!);

            string sql = "SELECT Nome, Quantidade, Valor FROM Produto WHERE ID = @ID";

            using SqlCommand comando = new SqlCommand(sql, conn);
            comando.Parameters.AddWithValue("@ID", id);

            using SqlDataReader leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                string nome = leitor["Nome"].ToString()!;
                int quantidade = Convert.ToInt32(leitor["Quantidade"]);
                decimal valor = Convert.ToDecimal(leitor["Valor"]);

                if (quantidade > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Produto encontrado!");
                    Console.WriteLine($"Produto: {nome}");
                    Console.WriteLine($"Valor: R$ {valor:F2}");
                    Console.WriteLine($"Estoque disponível: {quantidade}");
                    Console.WriteLine();

                    Console.Write("Confirmar compra? (S/N): ");
                    string confirmar = Console.ReadLine()!;

                    if (confirmar.ToUpper() == "S")
                    {
                        leitor.Close();

                        string sqlCompra = "UPDATE Produto SET Quantidade = Quantidade - 1 WHERE ID = @ID";

                        using SqlCommand comandoCompra = new SqlCommand(sqlCompra, conn);
                        comandoCompra.Parameters.AddWithValue("@ID", id);

                        comandoCompra.ExecuteNonQuery();

                        Console.WriteLine();
                        Console.WriteLine("Compra realizada com sucesso!");
                        Console.WriteLine($"Produto: {nome}");
                        Console.WriteLine($"Valor pago: R$ {valor:F2}");
                        Console.WriteLine($"Estoque restante: {quantidade - 1}");
                    }
                    else
                    {
                        Console.WriteLine("Compra cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine($"O produto {nome} está sem estoque.");
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }

            break;
        }

        case 3:
        {
            string sql = "SELECT ID, Nome, Quantidade FROM Produto WHERE Quantidade <= 5";

            using SqlCommand comando = new SqlCommand(sql, conn);
            using SqlDataReader leitor = comando.ExecuteReader();

            bool encontrou = false;

            while (leitor.Read())
            {
                encontrou = true;

                int quantidade = Convert.ToInt32(leitor["Quantidade"]);

                if (quantidade == 0)
                {
                    Console.WriteLine(
                        $"ID: {leitor["ID"]} | " +
                        $"Produto: {leitor["Nome"]} | " +
                        $"ESTOQUE: ESGOTADO"
                    );
                }
                else
                {
                    Console.WriteLine(
                        $"ID: {leitor["ID"]} | " +
                        $"Produto: {leitor["Nome"]} | " +
                        $"Estoque: {quantidade} unidades"
                    );
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Todos os produtos possuem estoque suficiente.");
            }

            break;
        }

        case 4:
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite a quantidade: ");
            int quantidade = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o valor: ");
            decimal valor = decimal.Parse(Console.ReadLine()!);

            string sql = "INSERT INTO Produto (Nome, Quantidade, Valor) VALUES (@Nome, @Quantidade, @Valor)";

            using SqlCommand comando = new SqlCommand(sql, conn);

            comando.Parameters.AddWithValue("@Nome", nome);
            comando.Parameters.AddWithValue("@Quantidade", quantidade);
            comando.Parameters.AddWithValue("@Valor", valor);

            comando.ExecuteNonQuery();

            Console.WriteLine();
            Console.WriteLine("Produto adicionado com sucesso!");

            break;
        }

        case 5:
        {
            Console.Write("Digite o ID do produto que deseja remover: ");
            int id = int.Parse(Console.ReadLine()!);

            string sql = "SELECT Nome, Quantidade, Valor FROM Produto WHERE ID = @ID";

            using SqlCommand comando = new SqlCommand(sql, conn);
            comando.Parameters.AddWithValue("@ID", id);

            using SqlDataReader leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                string nome = leitor["Nome"].ToString()!;
                int quantidade = Convert.ToInt32(leitor["Quantidade"]);
                decimal valor = Convert.ToDecimal(leitor["Valor"]);

                Console.WriteLine();
                Console.WriteLine("Produto encontrado!");
                Console.WriteLine($"Produto: {nome}");
                Console.WriteLine($"Quantidade: {quantidade}");
                Console.WriteLine($"Valor: R$ {valor:F2}");
                Console.WriteLine();

                Console.Write("Confirmar remoção? (S/N): ");
                string confirmar = Console.ReadLine()!;

                if (confirmar.ToUpper() == "S")
                {
                    leitor.Close();

                    string sqlDelete = "DELETE FROM Produto WHERE ID = @ID";

                    using SqlCommand comandoDelete = new SqlCommand(sqlDelete, conn);
                    comandoDelete.Parameters.AddWithValue("@ID", id);

                    comandoDelete.ExecuteNonQuery();

                    Console.WriteLine("Produto removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Remoção cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }

            break;
        }

        case 6:
        {
            Console.WriteLine("Saindo...");
            break;
        }

        default:
        {
            Console.WriteLine("Opção inválida.");
            break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine("Erro: " + ex.Message);
}