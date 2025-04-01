# -*- coding: utf-8 -*-
import mysql.connector

mydb = mysql.connector.connect(
  host="127.0.0.1",
  user="root",
  password="x"
)

mycursor = mydb.cursor()

sql = "USE cursoapidb"

mycursor.execute(sql)

sql = """
INSERT INTO alunos (NomeCompleto, Email, Telefone, Endereco, Cidade, Estado) 
VALUES 
('João Silva', 'joao.silva@email.com', 11912345678, 'Rua das Flores, 123', 'São Paulo', 'SP'),
('Maria Souza', 'maria.souza@email.com', 21987654321, 'Av. Paulista, 456', 'Rio de Janeiro', 'RJ'),
('Carlos Pereira', 'carlos.pereira@email.com', 31998765432, 'Rua Minas Gerais, 789', 'Belo Horizonte', 'MG'),
('Ana Oliveira', 'ana.oliveira@email.com', 41956781234, 'Rua Paraná, 101', 'Curitiba', 'PR'),
('Fernando Costa', 'fernando.costa@email.com', 51934567890, 'Av. Ipiranga, 321', 'Porto Alegre', 'RS');
"""

mycursor.execute(sql)

mydb.commit()

print("record(s) inserted.")