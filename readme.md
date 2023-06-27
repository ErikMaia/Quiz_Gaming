# Gamificação

Isso foi um trabalho relativo a diciplina de TDS Tecnologia em Desenvolvimento de Sistemas pelo professor Everton Coimbra no curso de ciencias da computação na Universidade Federam Tecnologica do Paraná feioto pelo aluno Erik Silva Maia.

## Metodo de instalação 
### Pré-requisitos

Certifique-se de ter o seguinte software instalado em seu sistema:

- Docker
- Docker Compose

### Passo 1: Clonar o Repositório

Clone este repositório para o seu ambiente local utilizando o seguinte comando:

```bash
git clone https://github.com/ErikMaia/gamificacao-02.git tds
```

### Passo 2: Configurar o Docker Compose

Navegue até o diretório raiz do projeto clonado e abra o arquivo `docker-compose.yml` em um editor de texto. Verifique as configurações e ajuste conforme necessário, como as portas e variáveis de ambiente.

### Passo 3: Executar o Docker Compose

No diretório raiz do projeto, execute o seguinte comando para construir e iniciar os contêineres Docker:

```bash
docker-compose up --build -d
```

Isso criará os contêineres necessários para o backend da aplicação, como banco de dados e servidor.
