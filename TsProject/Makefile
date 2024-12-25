DOCKER_CMD := docker-compose -f docker-compose.yml
CONTAINER_CMD := docker exec -it puerts-env

_:

build:
	${DOCKER_CMD} build

up:
	${DOCKER_CMD} up -d

down:
	${DOCKER_CMD} down

connect:
	${CONTAINER_CMD} sh

compile:
	${CONTAINER_CMD} npm run build:dev