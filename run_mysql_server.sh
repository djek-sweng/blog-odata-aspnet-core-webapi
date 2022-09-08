#!/bin/sh

# set variables
YML_FILE="./tools/mysql/docker-compose.yml"

# run docker container
docker compose -f "$YML_FILE" up --remove-orphans
