# TODO
### Unfortunately I didn't have time to do the following necessary things
- Unit testing
- Fix docker and docker compose
- Add Migration runner
- 



## Setup

## Create database in docker

```shell
docker run -d --name messaging-postgres -e POSTGRES_PASSWORD=mypass123 -e POSTGRES_USER=myuser -e POSTGRES_DB="Messaging" -v messaging-postgres:/var/lib/postgresql/data -p 5432:5432 postgres
```

## Redis

```shell
docker run --name redis -d -p 6379:6379 -d redis
```

## Rabbitmq

```shell
docker run --name rabbitmq -d -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```