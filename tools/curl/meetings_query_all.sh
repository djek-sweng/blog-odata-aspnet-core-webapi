#!/bin/sh

curl --location --request GET 'https://localhost:5001/meetings/query'

# info: Microsoft.EntityFrameworkCore.Database.Command[20101]
#       Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
#       SELECT `m`.`Id`, `m`.`CalendarId`, `m`.`Description`, `m`.`Duration`, `m`.`StartAt`, `m`.`Title`
#       FROM `Meetings` AS `m`
