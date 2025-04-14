# -*- coding: utf-8 -*-
import random
from faker import Faker # type: ignore
import mysql.connector

conn = mysql.connector.connect(
  host="127.0.0.1",
  user="root",
  password="x
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
        fake.address().replace("\n", ", "),
        fake.city(),
        fake.estado_sigla(),
    )
    
    cursor.execute(sql, valores)

    niveis = ['Básico', 'Intermediário', 'Avançado']

for _ in range(500):
    sql = """
    INSERT IGNORE INTO cursos (Nome, Descricao, CargaHoraria, Nivel, Preco, Ativo) 
    VALUES (%s, %s, %s, %s, %s, %s)
    """
        
    valores = (
        fake.sentence(nb_words=3),  
        fake.paragraph(nb_sentences=2),  
        random.randint(10, 200),  
        random.choice(niveis),  
        round(random.uniform(49.9, 999.9), 2),  
        random.choice([True, False])  
    )
    cursor.execute(sql, valores)

conn.commit()
cursor.close()
conn.close()

print("record(s) inserted.")


