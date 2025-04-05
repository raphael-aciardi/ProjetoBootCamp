# -*- coding: utf-8 -*-
from faker import Faker # type: ignore
import mysql.connector

conn = mysql.connector.connect(
  host="127.0.0.1",
  user="root",
  password="x"
)

fake = Faker('pt_BR')

cursor = conn.cursor()

sql = "USE cursoapidb"

cursor.execute(sql)

for _ in range(500):
    sql = """
    INSERT IGNORE INTO alunos (NomeCompleto, Email, Telefone, Endereco, Cidade, Estado) 
    VALUES (%s, %s, %s, %s, %s, %s)
    """
    valores = (
        fake.name(),
        fake.email(),
        fake.phone_number(),
        fake.address().replace("\n", ", "),  # Remover quebras de linha
        fake.city(),
        fake.estado_sigla(),
    )
    
    cursor.execute(sql, valores)

conn.commit()
cursor.close()
conn.close()

print("record(s) inserted.")