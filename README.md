# Setup

## Create database in docker

```shell
docker run -d --name messaging-postgres -e POSTGRES_PASSWORD=mypass123 -e POSTGRES_USER=myuser -e POSTGRES_DB="Messaging" -v messaging-postgres:/var/lib/postgresql/data -p 5432:5432 postgres
```