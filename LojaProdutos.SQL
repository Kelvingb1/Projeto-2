-- =========================================
-- BANCO DE DADOS: Loja
-- =========================================

IF DB_ID('Loja') IS NULL
BEGIN
    CREATE DATABASE Loja;
END;
GO

USE Loja;
GO

-- =========================================
-- TABELA DE PRODUTOS
-- =========================================

IF OBJECT_ID('Produto', 'U') IS NULL
BEGIN
    CREATE TABLE Produto
    (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        Nome VARCHAR(30),
        Quantidade INT,
        Valor DECIMAL(10,2)
    );
END;
GO

-- =========================================
-- PRODUTOS INICIAIS
-- =========================================

INSERT INTO Produto (Nome, Quantidade, Valor)
VALUES
('Notebook', 10, 3500.00),
('Monitor', 15, 1200.00),
('Teclado Mecânico', 20, 250.00),
('Mouse Sem Fio', 30, 120.00),
('Smartphone', 8, 2500.00),
('Headset Gamer', 12, 300.00),
('Webcam Full HD', 10, 280.00),
('Tablet', 7, 1800.00),
('Roteador Wi-Fi', 14, 350.00),
('Impressora', 6, 900.00),
('Projetor', 5, 2200.00),
('Smartwatch', 11, 750.00),
('SSD Externo', 9, 600.00),
('HD Externo', 13, 450.00),
('Pen Drive', 25, 80.00),
('Microfone USB', 10, 400.00),
('Controle Gamer', 16, 280.00),
('Smart TV', 5, 3200.00),
('Placa de Vídeo', 4, 4500.00),
('Caixa de Som', 18, 350.00);